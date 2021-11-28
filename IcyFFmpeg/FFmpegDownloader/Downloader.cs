using IcyFFmpeg.Internal;
using IcyFFmpeg.Internal.Events;
using IcyFFmpeg.Types;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IcyFFmpeg.FFmpegDownloader
{
    public class Downloader
    {
        /// <summary>
        /// Raised when Downloader finishes downloading executable
        /// </summary>
        public event EventHandler<DownloaderCompleteArgs> Complete;
        /// <summary>
        /// Raised when Downloader failed downloading executable
        /// </summary>
        public event EventHandler<DownloaderErrorArgs> Error;
        /// <summary>
        /// Raised when Downloader is making progress on downloading executable
        /// </summary>
        public event EventHandler<DownloaderProgressArgs> Progress;

        private json_download Info = JsonSerializer.Deserialize<json_download>(new WebClient().DownloadString("https://ffbinaries.com/api/v1/version/latest"));

        /// <summary>
        /// Gets the latest FFmpeg version
        /// </summary>
        /// <returns></returns>
        public string GetVersion() => Info.version;

        /// <summary>
        /// Gets the FFmpeg download url for the given OperatingSystem
        /// </summary>
        public string GetUrl(Enums.OperatingSystem OperatingSystem)
        {
            switch (OperatingSystem){
                case Enums.OperatingSystem.windows_32:
                    return Info.bin.windows_32.ffmpeg;
                case Enums.OperatingSystem.windows_64:
                    return Info.bin.windows_64.ffmpeg;
                case Enums.OperatingSystem.linux_32:
                    return Info.bin.linux_32.ffmpeg;
                case Enums.OperatingSystem.linux_64:
                    return Info.bin.linux_64.ffmpeg;
                case Enums.OperatingSystem.linux_armhf:
                    return Info.bin.linux_armhf.ffmpeg;
                case Enums.OperatingSystem.linux_arm64:
                    return Info.bin.linux_arm64.ffmpeg;
                case Enums.OperatingSystem.osx_64:
                    return Info.bin.osx_64.ffmpeg;
                default: throw Exceptions.MissingOsInfo;
            }
        }
        /// <summary>
        /// Downloads the latest FFmpeg build
        /// </summary>
        /// <param name="OperatingSystem">The OperatingSystem for the executable (Use 'IcyFFmpeg.FFmpegDownloader.OperatingSystem.Get()' to get the current OS)</param>
        /// <param name="Path">The Path the executable gets downloaded</param>
        /// <returns></returns>
        public async Task Latest(Enums.OperatingSystem OperatingSystem, string Path)
        {
            WebClient wc = new();
            wc.DownloadFileCompleted += (s, e) =>
            {
                if (e.Error != null) Error.Invoke(this, new(Info.version, Path, e.Error));
            };
            wc.DownloadProgressChanged += (s, e) => Progress.Invoke(this, new(Info.version, Path, e.ProgressPercentage));

            try
            {
                using (FileStream fs = new(Path, FileMode.CreateNew))
                using (ZipArchive ar = new(new MemoryStream(await wc.DownloadDataTaskAsync(GetUrl(OperatingSystem)))))
                {
                    await ar.Entries.Where(z => z.Name.ToLower().Contains("ffmpeg")).First().Open().CopyToAsync(fs);
                }
                Complete.Invoke(this, new(Info.version, Path));
            }
            catch (Exception ex) { Error.Invoke(this, new(Info.version, Path, ex)); }
        }
    }

    internal class json_download
    {
        public json_download_bin bin { get; set; } = new();
        public string version { get; set; }
    }
    internal class json_download_bin
    {
        [JsonPropertyName("windows-32")]
        public json_download_bin_windows_32 windows_32 { get; set; } = new();
        [JsonPropertyName("windows-64")]
        public json_download_bin_windows_64 windows_64 { get; set; } = new();
        [JsonPropertyName("linux-32")]
        public json_download_bin_linux_32 linux_32 { get; set; } = new ();
        [JsonPropertyName("linux-64")]
        public json_download_bin_linux_32 linux_64 { get; set; } = new ();
        [JsonPropertyName("linux-armhf")]
        public json_download_bin_linux_32 linux_armhf { get; set; } = new ();
        [JsonPropertyName("linux-arm64")]
        public json_download_bin_linux_32 linux_arm64 { get; set; } = new ();
        [JsonPropertyName("osx-64")]
        public json_download_bin_linux_32 osx_64 { get; set; } = new ();
    }
    internal class json_download_bin_windows_32
    { public string ffmpeg { get; set; } public string ffprobe { get; set; } }
    internal class json_download_bin_windows_64
    { public string ffmpeg { get; set; } public string ffprobe { get; set; } }
    internal class json_download_bin_linux_32
    { public string ffmpeg { get; set; } public string ffprobe { get; set; } }
    internal class json_download_bin_linux_64
    { public string ffmpeg { get; set; } public string ffprobe { get; set; } }
    internal class json_download_bin_linux_armhf
    { public string ffmpeg { get; set; } public string ffprobe { get; set; } }
    internal class json_download_bin_linux_arm64
    { public string ffmpeg { get; set; } public string ffprobe { get; set; } }
    internal class json_download_bin_linux_osx_64
    { public string ffmpeg { get; set; } public string ffprobe { get; set; } }
}
