namespace Downloader.Config
{
    public interface IConfig
    {
        string GetExeFilePath();
        string exePath { get; }
        bool DependencyConfig();
    }
}
