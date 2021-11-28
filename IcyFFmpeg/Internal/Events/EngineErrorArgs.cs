using IcyFFmpeg.Types;
using System;

namespace IcyFFmpeg.Internal.Events
{
    public class EngineErrorArgs : EventArgs
    {
        public Input Input { get; }
        public string Output { get; }
        public Exception Exception { get; }

        public EngineErrorArgs(Input Input, string Output, Exception Exception)
        {
            this.Input = Input;
            this.Output = Output;
            this.Exception = Exception;
        }
    }
}
