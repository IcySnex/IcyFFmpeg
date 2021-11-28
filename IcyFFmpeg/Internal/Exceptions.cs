using System;

namespace IcyFFmpeg.Internal
{
    public class Exceptions
    {
        public static Exception FileDoesNotExist(string File) => new Exception("Given file does not exist.", new Exception($"\"{File}\""));
        public static Exception StreamIsNullOrEmpty = new Exception("Given stream is null or empty.");
        public static Exception FormatNotSupported(string Format) => new Exception("Given format is not supported.", new Exception($"\"{Format}\""));
        public static Exception InputIsNull = new Exception("Input media is null.");
        public static Exception FFmpegExecutableDoesNotExist(string FFmpegExecutable) => new Exception("Given FFmpeg Executable does not exist.", new Exception($"\"{FFmpegExecutable}\""));
        public static Exception MissingOsInfo = new Exception("Missing operating system type and or architecture.");
        
    }
}
