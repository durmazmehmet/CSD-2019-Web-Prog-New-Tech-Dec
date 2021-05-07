using Microsoft.AspNetCore.Http;
using System;
using System.Runtime.CompilerServices;

namespace CSD.Extensions.ColorfulConsoleLog
{
    public static class LogToConsole
    {
        //TODO: Kod listesi oluştur
        //TODO: Renk kodları custom olabilsin

        private string Msg { get; set; } = $"\x1b[32mLOG\x1b[0m :";

        public LogToConsole() => ConsoleEnableVT100.Enable();

        public LogToConsole(string LogDescription = "") => Msg += $"({LogDescription})";

        public LogToConsole Action([CallerMemberName] string MemberName = "", string ActionDescription = "")
        {
            Msg += $" \x1b[31m{MemberName}\x1b[0m {ActionDescription ?? "is called"}";
            return this;
        }

        public LogToConsole Stamp(string format = "dd.MM.yyyy - HH:mm:ss")
        {
            Msg += $" \x1b[36m{DateTime.Now.ToString(format)}\x1b[0m";
            return this;
        }

        public LogToConsole RemoteInfo(ConnectionInfo connectionInfo)
        {
            Msg += $" \x1b[35mRemote: \x1b[0m{connectionInfo.RemoteIpAddress}:{connectionInfo.RemotePort}";
            return this;
        }

        public LogToConsole HostInfo(ConnectionInfo connectionInfo)
        {
            Msg += $" \x1b[34mHost: \x1b[0m{connectionInfo.LocalIpAddress}:{connectionInfo.LocalPort}";
            return this;
        }

        public LogToConsole WriteLine()
        {
            Console.WriteLine(Msg);
            Msg = "     ";
            return this;
        }

        public LogToConsole Write()
        {
            Console.Write(Msg);
            Msg = "";
            return this;
        }
    }
}
