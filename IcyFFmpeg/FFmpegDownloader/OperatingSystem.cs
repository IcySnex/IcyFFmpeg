using IcyFFmpeg.Internal;
using IcyFFmpeg.Types;
using System.Runtime.InteropServices;

namespace IcyFFmpeg.FFmpegDownloader
{
    public class OperatingSystem
    {
        /// <summary>
        /// Get the OperatingSystem the program is running currently
        /// </summary>
        /// <returns></returns>
        public static Enums.OperatingSystem Get()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                switch (RuntimeInformation.OSArchitecture)
                {
                    case Architecture.X64:
                        return Enums.OperatingSystem.windows_64;
                    case Architecture.X86:
                        return Enums.OperatingSystem.windows_32;
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return Enums.OperatingSystem.osx_64;
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                switch (RuntimeInformation.OSArchitecture)
                {
                    case Architecture.X64:
                        return Enums.OperatingSystem.linux_64;
                    case Architecture.X86:
                        return Enums.OperatingSystem.linux_32;
                    case Architecture.Arm:
                        return Enums.OperatingSystem.linux_armhf;
                    case Architecture.Arm64:
                        return Enums.OperatingSystem.linux_arm64;
                }
            }
            throw Exceptions.MissingOsInfo;
        }
    }
}
