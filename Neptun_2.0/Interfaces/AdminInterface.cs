using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class AdminInterface : Interface
    {
        private String demandSubmission = "Igény elbírálása";
        private String requestMaintenance = "Karbantartás";
        private String requestJudgement = "Kérvény elbírálása";
        private int countdemand = 0;
        private int countrequest = 0;
        public CMD AdminMainMenu()
        {
            //WriteMenu
            position = 1;
            Console.Clear();
            Console.SetCursorPosition(1, 2);
            Console.Write(demandSubmission);
            Console.SetCursorPosition(23, 2);
            Console.Write(requestMaintenance);
            Console.SetCursorPosition(40, 2);
            Console.Write(requestJudgement);
            Console.SetCursorPosition(62, 2);
            Console.Write(logOut);
            MainMenuunderline();

            //Action
            do
            {
                input = Console.ReadKey();
                Console.Write("\b ");
                if (input.Key == ConsoleKey.RightArrow)
                    position++;
                if (input.Key == ConsoleKey.LeftArrow)
                    position--;
                if (position < 1)
                    position = 4;
                if (position > 4)
                    position = 1;
                MainMenuunderline();
            } while (input.Key != ConsoleKey.Enter); 
            
            //return           
            CMD command = new CMD();
            switch (position)
            {
                case 1:
                    command.cmd = "demandSubmission";
                    break;
                case 2:
                    command.cmd = "requestMaintenance";
                    break;
                case 3:
                    command.cmd = "requestJudgement";
                    break;
                case 4:
                    command.cmd = "logout";
                    break;
            }
            return command;
        }
        
        private void MainMenuunderline()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(i*4, 3);
                Console.Write("    ");
            }
            switch (position)
            {
                case 1 :
                    for (int i = 0; i < demandSubmission.Length; i++)
                    {
                        Console.SetCursorPosition(1 + i, 3);
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(2 + demandSubmission.Length, 2);
                    break;
                case 2 :
                    for (int i = 0; i < requestMaintenance.Length; i++)
                    {
                        Console.SetCursorPosition(23 + i, 3);
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(24 + requestMaintenance.Length, 2);
                    break;
                case 3 :
                    for (int i = 0; i < requestJudgement.Length; i++)
                    {
                        Console.SetCursorPosition(40 + i, 3);
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(41 + requestJudgement.Length, 2);
                    break;
                case 4:
                    for (int i = 0; i < logOut.Length; i++)
                    {
                        Console.SetCursorPosition(62 + i, 3);
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(63 + logOut.Length, 2);
                    break;
            }
        }
        public CMD selectDemand(List<Demand> demands)
        {
            position = 1;
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(i * 4, 4);
                Console.Write("____");
            }
            Console.SetCursorPosition(3, 6);
            Console.Write("Válassza ki, melyik igényt akarja elbírálni:");
            Console.SetCursorPosition(5, 8);
            Console.Write(back + "   ");
            countdemand = demands.Count;
            DemandorRequestUnderline(countdemand);
            for (int i = 0; i < countdemand; i++)
            {
                Console.SetCursorPosition(5, 10 + i);
                Console.Write(demands[i].getOwner() + "   " + demands[i].getSubjectName() + "   " + demands[i].getRoomId() + "  " + demands[i].getDay()+ "  " + demands[i].getStartTime() + "  " + demands[i].getEndTime() + "   ");
            }
            Console.SetCursorPosition(8 + back.Length, 8);
            do
            { 
                input = Console.ReadKey();
                if (input.Key == ConsoleKey.DownArrow)
                position++;
                if (input.Key == ConsoleKey.UpArrow)
                    position--;
                if (position < 1)
                    position = countdemand + 1;
                if (position > countdemand +1)
                    position = 1;
                DemandorRequestUnderline(countdemand);
            } while (input.Key != ConsoleKey.Enter);             
            
            CMD command = new CMD();
            command.data = new List<string>();
            if (position == 1)
                command.cmd = "exit";
            else            
                command.data.Add(demands[position - 2].getId());                            
            return command;
        }
        private void DemandorRequestUnderline(int max)
        {
            Console.Write("\b\b\b   ");
            if (position == 1)
            {
                for (int i = 0; i < back.Length; i++)
                {
                    Console.SetCursorPosition(5 + i, 9);
                    Console.Write("-");
                }
                Console.SetCursorPosition(8 + back.Length, 8);
            }
            else
            {                
                if (position == 2 || position == max + 1)
                {
                    for (int i = 0; i < back.Length; i++)
                    {
                        Console.SetCursorPosition(5 + i, 9);
                        Console.Write(" ");
                    }
                }
                Console.SetCursorPosition(2, 10+position-2);
                Console.Write("->");                
            }
        }

        public CMD judgeDemand()
        {
            subMenuremove(10, countdemand);
            Console.SetCursorPosition(3, 6);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(3, 6);
            Console.Write("El szeretné fogadni ezt az igényt?");
            position = 1;
            Console.SetCursorPosition(3, 8);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(3, 8);
            Console.Write(yes);
            Console.SetCursorPosition(12, 8);
            Console.Write(no);
            Console.SetCursorPosition(21, 8);
            Console.Write(back);
            judgeDemandOrRequestUnderline();
            do
            {
                input = Console.ReadKey();
                Console.Write("\b ");
                if (input.Key == ConsoleKey.RightArrow)
                    position++;
                if (input.Key == ConsoleKey.LeftArrow)
                    position--;
                if (position < 1)
                    position = 3;
                if (position > 3)
                    position = 1;
                judgeDemandOrRequestUnderline();
            } while (input.Key != ConsoleKey.Enter);

            CMD command = new CMD();
            switch(position)
            {
                case 1:
                    command.cmd = "True";
                    break;
                case 2:
                    command.cmd = "False";
                    break;
                case 3:
                    command.cmd = "exit";
                    break;
            }
            return command;
        }
        private void judgeDemandOrRequestUnderline()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(i * 4, 9);
                Console.Write("    ");
            }
            switch (position)
            {
                case 1:
                    for (int i = 0; i < yes.Length; i++)
                    {
                        Console.SetCursorPosition(3 + i, 9);
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(4 + yes.Length, 8);
                    break;
                case 2:
                    for (int i = 0; i < no.Length; i++)
                    {
                        Console.SetCursorPosition(12 + i, 9);
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(13 + no.Length, 8);
                    break;
                case 3:
                    for (int i = 0; i < back.Length; i++)
                    {
                        Console.SetCursorPosition(21 + i, 9);
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(22 + back.Length, 8);
                    break;
            }
        }
        public void demand_accept()
        {
            subMenuremove(6, countdemand + 4);
            Console.SetCursorPosition(3, 11);
            Console.Write("Az igényt elfogadta!");
            input = Console.ReadKey();
        }
        public void demand_decline()
        {
            subMenuremove(6, countdemand + 4);
            Console.SetCursorPosition(3, 11);
            Console.Write("Az igényt elutasította!");
            input = Console.ReadKey();
        }

        public CMD requestMaintenanceMenu()
        {
            position = 1;
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(i * 4, 4);
                Console.Write("____");
            }
            Console.SetCursorPosition(3, 6);
            Console.Write("Biztosan törölni szeretné a tanárok igényeit, és a diákok kérvényeit?");
            Console.SetCursorPosition(3, 8);
            Console.Write(yes);
            Console.SetCursorPosition(12, 8);
            Console.Write(no);
            areYouSureUnderline();
            do
            {
                input = Console.ReadKey();
                Console.Write("\b ");
                if (input.Key == ConsoleKey.RightArrow)
                    position++;
                if (input.Key == ConsoleKey.LeftArrow)
                    position--;
                if (position < 1)
                    position = 2;
                if (position > 2)
                    position = 1;
                areYouSureUnderline();
            } while (input.Key != ConsoleKey.Enter);
            CMD command = new CMD();
            if(position==1)
            {
                command.cmd = "True";
            }
            if (position == 1)
            {
                command.cmd = "exit";
            }
            return command;
        }
        public void maintenance_successful()
        {
            subMenuremove(6, countdemand + 4);
            Console.SetCursorPosition(3, 11);
            Console.Write("Az igények és a kérvények törlése sikeres volt!");
            input = Console.ReadKey();
        }
        public void maintenance_unsuccessful()
        {
            subMenuremove(6, countdemand + 4);
            Console.SetCursorPosition(3, 11);
            Console.Write("Az igények és a kérvények törlése sikertelen volt!");
            input = Console.ReadKey();
        }
        public CMD selectRequest(List<Request> requests)
        {
            position = 1;
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(i * 4, 4);
                Console.Write("____");
            }
            Console.SetCursorPosition(3, 6);
            Console.Write("Válassza ki, melyik kérvényt akarja elbírálni:");
            Console.SetCursorPosition(5, 8);
            Console.Write(back + "   ");
            countrequest = requests.Count;
            DemandorRequestUnderline(countrequest);
            for (int i = 0; i < countrequest; i++)
            {
                Console.SetCursorPosition(5, 10 + i);
                Console.Write(requests[i].getId() + "   " + requests[i].getOwner() + "   " + requests[i].getSubject() + "   ");
            }
            Console.SetCursorPosition(8 + back.Length, 8);
            do
            {
                input = Console.ReadKey();
                if (input.Key == ConsoleKey.DownArrow)
                    position++;
                if (input.Key == ConsoleKey.UpArrow)
                    position--;
                if (position < 1)
                    position = countrequest + 1;
                if (position > countrequest + 1)
                    position = 1;
                DemandorRequestUnderline(countrequest);
            } while (input.Key != ConsoleKey.Enter);

            CMD command = new CMD();
            command.data = new List<string>();
            if (position == 1)
                command.cmd = "exit";
            else
                command.data.Add(requests[position - 2].getId());
            return command;
        }

        public CMD judgeRequest(Request request)
        {
            subMenuremove(10, countrequest);
            Console.SetCursorPosition(3, 6);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(3, 6);
            Console.Write("El szeretné fogadni a következő kérvényt?");
            position = 1;
            Console.SetCursorPosition(3, 8);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(3, 8);
            Console.Write(yes);
            Console.SetCursorPosition(12, 8);
            Console.Write(no);
            Console.SetCursorPosition(21, 8);
            Console.Write(back);
            Console.SetCursorPosition(1, 10);
            Console.Write(request.getSubject());
            Console.SetCursorPosition(1, 12);
            Console.Write(request.getText());
            judgeDemandOrRequestUnderline();
            do
            {
                input = Console.ReadKey();
                Console.Write("\b ");
                if (input.Key == ConsoleKey.RightArrow)
                    position++;
                if (input.Key == ConsoleKey.LeftArrow)
                    position--;
                if (position < 1)
                    position = 3;
                if (position > 3)
                    position = 1;
                judgeDemandOrRequestUnderline();
            } while (input.Key != ConsoleKey.Enter);

            CMD command = new CMD();
            switch (position)
            {
                case 1:
                    command.cmd = "True";
                    break;
                case 2:
                    command.cmd = "False";
                    break;
                case 3:
                    command.cmd = "exit";
                    break;
            }
            return command;
        }
        public void request_accept()
        {
            subMenuremove(6, countrequest + 4);
            Console.SetCursorPosition(3, 11);
            Console.Write("A kérvényt elfogadta!");
            input = Console.ReadKey();
        }
        public void request_decline()
        {
            subMenuremove(6, countrequest + 4);
            Console.SetCursorPosition(3, 11);
            Console.Write("A kérvényt elutasította!");
            input = Console.ReadKey();
        }
    }
}
