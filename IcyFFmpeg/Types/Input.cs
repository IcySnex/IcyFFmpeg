using IcyFFmpeg.Internal;
using System.IO;

namespace IcyFFmpeg.Types
{
    public class Input
    {
        public Enums.Input? Type { get; set; } = null;
        public string File { get; set; } = null;
        public Stream Stream { get; set; } = null;

        public Input(string File, bool IgnoreFormat = false)
        {
            if (string.IsNullOrWhiteSpace(File) | !System.IO.File.Exists(File)) throw Exceptions.FileDoesNotExist(File);
            if (!IgnoreFormat && string.IsNullOrWhiteSpace(Path.GetExtension(File)) | !Enums.GetVideoFormats.Contains(Path.GetExtension(File))) throw Exceptions.FormatNotSupported(Path.GetExtension(File));
            Type = Enums.Input.File;
            this.File = File;
        }
        public Input(Stream Stream)
        {
            if (Stream == null) throw Exceptions.StreamIsNullOrEmpty; if (Stream.Length <= 0) throw Exceptions.StreamIsNullOrEmpty;
            Type = Enums.Input.Stream;
            this.Stream = Stream;
        }

        public static Input FromFile(string File, bool IgnoreFormat = false) => new(File, IgnoreFormat);
        public static Input FromStream(Stream Stream) => new(Stream);
    }
}
