using System;

namespace IcyFFmpeg.Internal.Events
{
    public class DownloaderProgressArgs : EventArgs
    {
        public string Version { get; }
        public string Path { get; }
        public int Percentage { get; }

        public DownloaderProgressArgs(string Version, string Path, int Percentage)
        {
            this.Version = Version;
            this.Path = Path;
            this.Percentage = Percentage;
        }
    }
}
