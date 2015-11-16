using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class AdminInterface : Interface
    {
        public CMD AdminMainMenu()
        {
            String demandSubmission = "Igény elbírálása";
            String requestMaintenance = "Karbantartás";
            String requestJudgement = "Kérvény elbírálása";
            Console.SetCursorPosition(2, 4);
            Console.Write(demandSubmission);
            Console.SetCursorPosition(20, 4);
            Console.Write(requestMaintenance);
            Console.SetCursorPosition(38, 4);
            Console.Write(requestJudgement);
            Console.SetCursorPosition(56, 4);
            Console.Write(logOut);

            CMD command = new CMD();
            return command;
        }
    }
}
