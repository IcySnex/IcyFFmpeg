using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace IcyFFmpeg.Internal
{
    public class Process
    {
        public async Task<string> Execute(string file, string arguemnts, CancellationToken cancel)
        {
            System.Diagnostics.Process proc = CreateProcess(file, arguemnts);
            proc.ErrorDataReceived += (sender, eventArgs) =>
            {
                Debug.WriteLine(eventArgs.Data);
            };


            return "";
        }
        public async Task<Stream> ExecuteStream()
        {
            return null;
        }

        public System.Diagnostics.Process CreateProcess(string file, string arguemnts) => new System.Diagnostics.Process
        {
            StartInfo = new ProcessStartInfo
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = arguemnts,
                FileName = file
            },
            EnableRaisingEvents = true
        };
    }
}
