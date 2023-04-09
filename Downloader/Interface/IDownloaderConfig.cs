namespace Downloader.Interface
{
    public interface IDownloaderConfig
    {
        string GetExeFilePath();
        string exePath { get; }
        bool DependencyConfig();
        int retry { get; set; }
    }
}
