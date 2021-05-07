using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;

namespace CSD.Extensions.ColorfulConsoleLog
{
    public interface ILogToConsole
    {
        LogToConsole Action([CallerMemberName] string MemberName = "", string ActionDescription = "");
        LogToConsole HostInfo(ConnectionInfo connectionInfo);
        LogToConsole RemoteInfo(ConnectionInfo connectionInfo);
        LogToConsole Stamp(string format = "dd.MM.yyyy - HH:mm:ss");
        LogToConsole Write();
        LogToConsole WriteLine();
    }
}