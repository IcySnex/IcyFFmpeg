using IcyFFmpeg.Types;
using System;

namespace IcyFFmpeg.Internal.Events
{
    public class EngineCompleteArgs : EventArgs
    {
        public Input Input { get; }
        public string Output { get; }

        public EngineCompleteArgs(Input Input, string Output)
        {
            this.Input = Input;
            this.Output = Output;
        }
    }
}
