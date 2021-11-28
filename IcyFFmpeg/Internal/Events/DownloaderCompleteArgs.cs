using System;

namespace IcyFFmpeg.Internal.Events
{
    public class DownloaderCompleteArgs : EventArgs
    {
        public string Version { get; }
        public string Path { get; }

        public DownloaderCompleteArgs(string Version, string Path)
        {
            this.Version = Version;
            this.Path = Path;
        }
    }
}
