using IcyFFmpeg.Types;
using System;

namespace IcyFFmpeg.Internal.Events
{
    public class EngineDataArgs : EventArgs
    {
        public Input Input { get; }
        public string Output { get; }
        public string Data { get; }

        public EngineDataArgs(Input Input, string Output, string Data)
        {
            this.Input = Input;
            this.Output = Output;
            this.Data = Data;
        }
    }
}
