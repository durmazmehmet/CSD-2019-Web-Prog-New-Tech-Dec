using System;
using System.Runtime.InteropServices;


namespace CSD.Extensions.ColorfulConsoleLog
{
    public static class ConsoleEnableVT100
    {
        private const int STD_INPUT_HANDLE = -10;
        private const int STD_OUTPUT_HANDLE = -11;
        private const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;
        private const uint DISABLE_NEWLINE_AUTO_RETURN = 0x0008;
        private const uint ENABLE_VIRTUAL_TERMINAL_INPUT = 0x0200;

        [DllImport("kernel32.dll")]
        private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll")]
        private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();

        public static void Enable()
        {
            var iStdIn = GetStdHandle(STD_INPUT_HANDLE);
            var iStdOut = GetStdHandle(STD_OUTPUT_HANDLE);

            if (!GetConsoleMode(iStdIn, out uint inConsoleMode))
                throw new Exception("failed to get input console mode");

            if (!GetConsoleMode(iStdOut, out uint outConsoleMode))
                throw new Exception("failed to get output console mode");

            inConsoleMode |= ENABLE_VIRTUAL_TERMINAL_INPUT;
            outConsoleMode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING | DISABLE_NEWLINE_AUTO_RETURN;

            if (!SetConsoleMode(iStdIn, inConsoleMode))
                throw new Exception($"failed to set input console mode, error code: {GetLastError()}");
            
            if (!SetConsoleMode(iStdOut, outConsoleMode))
                throw new Exception($"failed to set output console mode, error code: {GetLastError()}");
        }
    }
}