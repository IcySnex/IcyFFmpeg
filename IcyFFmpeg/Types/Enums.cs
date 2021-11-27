using System;
namespace IcyFFmpeg.Types
{
    public class Enums
    {
        public enum Input { File, Stream };
        public static string GetVideoFormat(VideoFormat VideoFormat) => $".{VideoFormat.ToString().Replace("_", "").ToLower()}";
        public static string GetVideoFormats = string.Join(", .", Enum.GetNames(typeof(VideoFormat))).Replace("_", "").ToLower();
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
    }
}
