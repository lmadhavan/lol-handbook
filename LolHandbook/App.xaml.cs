using LolHandbook.Pages;
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
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
        }

        public static void Navigate(Type pageType, object parameter)
        {
            App app = (App)Current;
            app.Frame.Navigate(pageType, parameter, new DrillInNavigationTransitionInfo());
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
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (Frame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                Frame = new Frame();

                Frame.CacheSize = 1;
                Frame.Navigated += OnNavigated;
                Frame.NavigationFailed += OnNavigationFailed;

                Frame.ContentTransitions = new TransitionCollection();
                Frame.ContentTransitions.Add(new NavigationThemeTransition());

                SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
                Window.Current.CoreWindow.PointerPressed += OnPointerPressed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }
            }

            if (e.PrelaunchActivated == false)
            {
                if (Frame.Content == null)
                {
                    Frame.Navigate(typeof(MainPage));
                }

                // Ensure the current window is active
                Window.Current.Activate();
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
    }
}
