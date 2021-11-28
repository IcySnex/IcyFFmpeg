using IcyFFmpeg.Internal;
using IcyFFmpeg.Internal.Events;
using IcyFFmpeg.Types;
using System;
using System.Diagnostics;
using System.IO;

namespace IcyFFmpeg
{
    public class Engine
    {
        /// <summary>
        /// Raised when engine has completed a task
        /// </summary>
        public event EventHandler<EngineCompleteArgs> Complete;
        /// <summary>
        /// Raised when engine recieves data from a task
        /// </summary>
        public event EventHandler<EngineDataArgs> Data;
        /// <summary>
        /// Raised when engine failed processing a task
        /// </summary>
        public event EventHandler<EngineErrorArgs> Error;
        /// <summary>
        /// Raised when engine is making progress on a task
        /// </summary>
        public event EventHandler<EngineProgressArgs> Progress;

        /// <summary>
        /// Local path to FFmpeg executable
        /// </summary>
        public string FFmpegExecutable { get; set; }
        /// <summary>
        /// Overwrites output file if it already exists else it throws
        /// </summary>
        public bool Overwrite { get; set; }
        /// <summary>
        /// Number of threads that can be used (Multi-Threading)
        /// </summary>
        public int Threads { get; set; }
        /// <summary>
        /// Allows Hardware Acceleration (GPU)
        /// </summary>
        public Enums.HardwareAccelerate HardwareAccelerate { get; set; } = Enums.HardwareAccelerate.None;
        /// <summary>
        /// Hides the default FFmpeg banner
        /// </summary>
        public bool HideBanner { get; set; } = true;

        /// <summary>
        /// Creates a new FFmpeg engine
        /// </summary>
        /// <param name="EngineOptions">General options for engine</param>
        public Engine(EngineOptions EngineOptions)
        {
            FFmpegExecutable = EngineOptions.FFmpegExecutable;
            Overwrite = EngineOptions.Overwrite;
            Threads = EngineOptions.Threads;
            HardwareAccelerate = EngineOptions.HardwareAccelerate;
            HideBanner = EngineOptions.HideBanner;
        }
        /// <summary>
        /// Creates a new FFmpeg engine
        /// </summary>
        /// <param name="FFmpegExecutable">Local path to FFmpeg executable</param>
        /// <param name="Threads">Number of threads that can be used (Multi-Threading)</param>
        /// <param name="HardwareAccelerate">Allows Hardware Acceleration (GPU)</param>
        /// <param name="HideBanner">Hides the default FFmpeg banner</param>
        public Engine(string FFmpegExecutable, bool Overwrite = false, int Threads = 0, Enums.HardwareAccelerate HardwareAccelerate = Enums.HardwareAccelerate.None, bool HideBanner = true)
        {
            if (!File.Exists(FFmpegExecutable)) throw Exceptions.FFmpegExecutableDoesNotExist(FFmpegExecutable);
            this.FFmpegExecutable = FFmpegExecutable;
            this.Overwrite = Overwrite;
            this.Threads = Threads;
            this.HardwareAccelerate = HardwareAccelerate;
            this.HideBanner = HideBanner;
        }

        /// <summary>
        /// Convert a video to another video format
        /// </summary>
        /// <param name="Input">Input media (Local File or Stream)</param>
        /// <param name="Ouput">Ouput path where converted video gets saved</param>
        /// <param name="ExciplitVideoFormat">Exciplit video format (Null for auto)</param>
        public void ConvertVideo(Input Input, string Ouput, Enums.VideoFormat? ExciplitVideoFormat = null)
        {
            switch (Input.Type)
            {
                case Enums.Input.File:
                    Debug.WriteLine("file");
                    break;
                case Enums.Input.Stream:
                    Debug.WriteLine("stream");
                    break;
                default: throw Exceptions.InputIsNull;             
            }
        }
    }

    public class EngineOptions
    {
        /// <summary>
        /// Local path to FFmpeg executable
        /// </summary>
        public string FFmpegExecutable { get; set; }
        /// <summary>
        /// Overwrites output file if it already exists else it throws
        /// </summary>
        public bool Overwrite { get; set; }
        /// <summary>
        /// Number of threads that can be used (Multi-Threading)
        /// </summary>
        public int Threads { get; set; }
        /// <summary>
        /// Allows Hardware Acceleration (GPU)
        /// </summary>
        public Enums.HardwareAccelerate HardwareAccelerate { get; set; }
        /// <summary>
        /// Hides the default FFmpeg banner
        /// </summary>
        public bool HideBanner { get; set; }

        /// <summary>
        /// Creates new general options for FFmpeg engine
        /// </summary>
        /// <param name="FFmpegExecutable">Local path to FFmpeg executable</param>
        /// <param name="Threads">Number of threads that can be used (Multi-Threading)</param>
        /// <param name="HardwareAccelerate">Allows Hardware Acceleration (GPU)</param>
        /// <param name="HideBanner">Hides the default FFmpeg banner</param>
        public EngineOptions(string FFmpegExecutable, bool Overwrite, int Threads, Enums.HardwareAccelerate HardwareAccelerate, bool HideBanner)
        {
            if (!File.Exists(FFmpegExecutable)) throw Exceptions.FFmpegExecutableDoesNotExist(FFmpegExecutable);
            this.FFmpegExecutable = FFmpegExecutable;
            this.Overwrite = Overwrite;
            this.Threads = Threads;
            this.HardwareAccelerate = HardwareAccelerate;
            this.HideBanner = HideBanner;
        }
    }
}
