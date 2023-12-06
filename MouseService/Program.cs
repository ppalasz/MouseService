using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MouseService
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if DEBUG
            // Uruchom jako zwykła aplikacja konsolowa
            MouseMoveService myService = new MouseMoveService();
            myService.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else
            // Uruchom jako usługa
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new MouseMoveService()
            };
            ServiceBase.Run(ServicesToRun);
#endif



        }
    }
}
