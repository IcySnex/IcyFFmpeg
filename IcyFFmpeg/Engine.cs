using IcyFFmpeg.Internal;
using IcyFFmpeg.Types;
using System;
using System.Diagnostics;

namespace IcyFFmpeg
{
    public class Engine
    {
        public Engine()
        {
        }

        public void ConvertTo(Input Input)
        {
            switch (Input.Type)
            {
                case null:
                    Debug.WriteLine("null");
                    break;
                case Enums.Input.File:
                    Debug.WriteLine("file");
                    break;
                case Enums.Input.Stream:
                    Debug.WriteLine("stream");
                    break;
            }
        }
    }
}
