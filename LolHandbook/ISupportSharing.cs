using Windows.ApplicationModel.DataTransfer;

namespace LolHandbook
{
    public interface ISupportSharing
    {
        void OnDataRequested(DataRequest request);
    }
}
