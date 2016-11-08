using LolHandbook.BackgroundTasks;
using LolHandbook.Views;
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation.Metadata;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace LolHandbook
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            this.Resuming += OnResuming;

            if (ApiInformation.IsPropertyPresent("Windows.UI.Xaml.Application", "RequiresPointerMode"))
            {
                this.RequiresPointerMode = ApplicationRequiresPointerMode.WhenRequested;
            }
        }

        public static void Navigate(Type pageType, object parameter)
        {
            Navigate(pageType, parameter, new DrillInNavigationTransitionInfo());
        }

        public static void Navigate(Type pageType, object parameter, NavigationTransitionInfo navigationTransitionInfo)
        {
            App app = (App)Current;
            app.Frame.Navigate(pageType, parameter, navigationTransitionInfo);
        }

        private Frame Frame
        {
            get
            {
                return Window.Current.Content as Frame;
            }

            set
            {
                Window.Current.Content = value;
            }
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            EnsureLaunched();

            if (!e.PrelaunchActivated)
            {
                if (Frame.Content == null)
                {
                    Frame.Navigate(typeof(MainPage));
                }

                Window.Current.Activate();
            }

            CheckPatchVersionTask.Register();
        }

        protected override void OnActivated(IActivatedEventArgs args)
        {
            base.OnActivated(args);

            if (args.Kind == ActivationKind.ToastNotification)
            {
                OnToastNotificationActivated();
            }
        }

        private void OnToastNotificationActivated()
        {
            EnsureLaunched();

            if (Frame.CurrentSourcePageType != typeof(MainPage))
            {
                Frame.Navigate(typeof(MainPage));
            }

            MainPage mainPage = (MainPage)Frame.Content;
            mainPage.Refresh().ConfigureAwait(false);

            Window.Current.Activate();
        }

        private void EnsureLaunched()
        {
            if (Frame == null)
            {
                this.Frame = new Frame();

                Frame.Navigated += OnNavigated;
                Frame.NavigationFailed += OnNavigationFailed;

                Frame.ContentTransitions = new TransitionCollection();
                Frame.ContentTransitions.Add(new NavigationThemeTransition());

                SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
                Window.Current.CoreWindow.PointerPressed += OnPointerPressed;
                DataTransferManager.GetForCurrentView().DataRequested += OnDataRequested;
            }
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = Frame.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }

        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

        private void OnPointerPressed(CoreWindow sender, PointerEventArgs args)
        {
            if (args.CurrentPoint.Properties.IsXButton1Pressed)
            {
                if (Frame.CanGoBack)
                {
                    Frame.GoBack();
                }
            }
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            ISupportSharing page = Frame.Content as ISupportSharing;
            if (page != null)
            {
                page.OnDataRequested(args.Request);
            }
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        private void OnResuming(object sender, object e)
        {
            ISupportResuming page = Frame.Content as ISupportResuming;
            if (page != null)
            {
                page.Resume().ConfigureAwait(false);
            }
        }
    }
}
