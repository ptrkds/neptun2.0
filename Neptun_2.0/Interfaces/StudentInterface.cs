using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class StudentInterface : Interface
    {
        private String timeTable = "Órarend";
        private String requestSubmission = "Kérvény leadás";
        private String registerForSubject = "Tárgy felvétel";
        private String deregisterSubject = "Tárgy leadás";
        public CMD StudentMainMenu()
        {
            //WriteMenu
            position = 1;
            Console.Clear();
            Console.SetCursorPosition(1, 2);
            Console.Write(timeTable);
            Console.SetCursorPosition(12, 2);
            Console.Write(requestSubmission);
            Console.SetCursorPosition(31, 2);
            Console.Write(registerForSubject);
            Console.SetCursorPosition(50, 2);
            Console.Write(deregisterSubject);
            Console.SetCursorPosition(65, 2);
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
                    position = 5;
                if (position > 5)
                    position = 1;
                MainMenuunderline();
            } while (input.Key != ConsoleKey.Enter);

            //return           
            CMD command = new CMD();
            switch (position)
            {
                case 1:
                    command.cmd = "timeTable";
                    break;
                case 2:
                    command.cmd = "requestSubmissione";
                    break;
                case 3:
                    command.cmd = "registerForSubject";
                    break;
                case 4:
                    command.cmd = "deregisterSubject";
                    break;
                case 5:
                    command.cmd = "logout";
                    break;
            }
            return command;
        }

        private void MainMenuunderline()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(i * 4, 3);
                Console.Write("    ");
            }
            switch (position)
            {
                case 1:
                    for (int i = 0; i < timeTable.Length; i++)
                    {
                        Console.SetCursorPosition(1 + i, 3);
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(2 + timeTable.Length, 2);
                    break;
                case 2:
                    for (int i = 0; i < requestSubmission.Length; i++)
                    {
                        Console.SetCursorPosition(12 + i, 3);
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(13 + requestSubmission.Length, 2);
                    break;
                case 3:
                    for (int i = 0; i < registerForSubject.Length; i++)
                    {
                        Console.SetCursorPosition(31 + i, 3);
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(32 + registerForSubject.Length, 2);
                    break;
                case 4:
                    for (int i = 0; i < deregisterSubject.Length; i++)
                    {
                        Console.SetCursorPosition(50 + i, 3);
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(51 + deregisterSubject.Length, 2);
                    break;
                case 5:
                    for (int i = 0; i < logOut.Length; i++)
                    {
                        Console.SetCursorPosition(65 + i, 3);
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(66 + logOut.Length, 2);
                    break;
            }
        }
    }
}
