using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyElementsRPG.Server.GameServer.ExceptionFactory
{
    public static class ExceptionFactory
    {
        public static void HandleException(Exception e)
        {

        }

        

        public static void HandleFatalException(Exception e)
        {
            //Close the server application
            Process.GetCurrentProcess().Kill();
        }
    }
}
