using IcyFFmpeg.Types;
using System;

namespace IcyFFmpeg.Internal.Events
{
    public class EngineProgressArgs : EventArgs
    {
        public Input Input { get; }
        public string Output { get; }
        public int Percentage { get; }
        public long Frame { get; }
        public double Fps { get; }
        public long SizeKB { get; }
        public TimeSpan Duration { get; }

        public EngineProgressArgs(Input Input, string Output, int Percentage, long Frame, double Fps, long SizeKB, TimeSpan Duration)
        {
            this.Input = Input;
            this.Output = Output;
            this.Percentage = Percentage;
            this.Frame = Frame;
            this.Fps = Fps;
            this.SizeKB = SizeKB;
            this.Duration = Duration;
        }
    }
}
