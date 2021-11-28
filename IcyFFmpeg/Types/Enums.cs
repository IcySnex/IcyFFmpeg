using System;
namespace IcyFFmpeg.Types
{
    public class Enums
    {
        public enum OperatingSystem
        {
            windows_32,
            windows_64,
            linux_32,
            linux_64,
            linux_armhf,
            linux_arm64,
            osx_64
        }
        public static string GetOperatingSystem(OperatingSystem OperatingSystem) => OperatingSystem.ToString().Replace("_", "-");

        public enum Input 
        { 
            File,
            Stream 
        };

        public enum VideoFormat 
        {
            _3gp,
            Mp4,
            Mov,
            Mkv,
            Avi,
            Mpeg,
            Mpegts,
            Svcd,
            Vob,
            M2ts,
            Mxf,
            Webm,
            Gxf,
            Flv,
            Ogg,
            Wmv,
            Asf,
            Rm
        };
        public static string GetVideoFormat(VideoFormat VideoFormat) => $".{VideoFormat.ToString().Replace("_", "").ToLower()}";
        public static string GetVideoFormats = string.Join(", .", Enum.GetNames(typeof(VideoFormat))).Replace("_", "").ToLower();

        public enum HardwareAccelerate
        {
            None,
            cuda,
            cuvid,
            dxva2,
            qsv,
            d3d11va
        }
    }
}
