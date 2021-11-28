using System;

namespace IcyFFmpeg.Internal.Events
{
    public class DownloaderErrorArgs: EventArgs
    {
        public string Version { get; }
        public string Path { get; }
        public Exception Exception { get; }

        public DownloaderErrorArgs(string Version, string Path, Exception Exception)
        {
            this.Version = Version;
            this.Path = Path;
            this.Exception = Exception;
        }
    }
}
