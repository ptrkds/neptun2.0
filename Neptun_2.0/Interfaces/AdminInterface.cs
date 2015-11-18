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
        private int countjudgement = 0;
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
        public CMD selectDemand(List<String> demands)
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
            DemandorJudgementUnderline(countdemand);
            for (int i = 0; i < countdemand; i++)
            {
                Console.SetCursorPosition(5, 10 + i);
                Console.Write(demands[i] + "   ");
            }

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
                DemandorJudgementUnderline(countdemand);
            } while (input.Key != ConsoleKey.Enter);             
            
            CMD command = new CMD();
            command.data = new List<string>();
            if (position == 1)
                command.cmd = "exit";
            else            
                command.data.Add(demands[position - 2]);                            
            return command;
        }
        private void DemandorJudgementUnderline(int max)
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
        public CMD requestMaintenanceMenu()
        {
            CMD command = new CMD();
            return command;
        }
        private void requestUnderline()
        {

        }
        public CMD requestJudgementMenu()
        {
            CMD command = new CMD();
            return command;
        }
    }
}
