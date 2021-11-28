using IcyFFmpeg.Internal;
using System.IO;

namespace IcyFFmpeg.Types
{
    public class Input
    {
        /// <summary>
        /// Input type for input media (do not change)
        /// </summary>
        public Enums.Input? Type { get; } = null;
        /// <summary>
        /// Local file for the input media
        /// </summary>
        public string File { get; } = null;
        /// <summary>
        /// Stream for the input media
        /// </summary>
        public Stream Stream { get; } = null;

        /// <summary>
        /// Creates a new input media
        /// </summary>
        /// <param name="File">Local file for input media</param>
        /// <param name="IgnoreExtention">Ignore the file extention</param>
        public Input(string File, bool IgnoreExtention = false)
        {
            if (string.IsNullOrWhiteSpace(File) | !System.IO.File.Exists(File)) throw Exceptions.FileDoesNotExist(File);
            if (!IgnoreExtention && string.IsNullOrWhiteSpace(Path.GetExtension(File)) | !Enums.GetVideoFormats.Contains(Path.GetExtension(File))) throw Exceptions.FormatNotSupported(Path.GetExtension(File));
            Type = Enums.Input.File;
            this.File = File;
        }
        /// <summary>
        /// Creates a new input media
        /// </summary>
        /// <param name="Stream">Stream for the input media</param>
        public Input(Stream Stream)
        {
            if (Stream == null) throw Exceptions.StreamIsNullOrEmpty; if (Stream.Length <= 0) throw Exceptions.StreamIsNullOrEmpty;
            Type = Enums.Input.Stream;
            this.Stream = Stream;
        }

        /// <summary>
        /// Creates a new input media
        /// </summary>
        /// <param name="File">Local file for input media</param>
        /// <param name="IgnoreExtention">Ignore the file extention</param>
        public static Input FromFile(string File, bool IgnoreExtention = false) => new(File, IgnoreExtention);
        /// <summary>
        /// Creates a new input media
        /// </summary>
        /// <param name="Stream">Stream for the input media</param>
        public static Input FromStream(Stream Stream) => new(Stream); 
    }
}
