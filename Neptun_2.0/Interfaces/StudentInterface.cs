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
        public CMD timeTableView(List<Subject> subjects)
        {
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(i * 4, 4);
                Console.Write("____");
            }
            Console.SetCursorPosition(3, 6);
            Console.Write(back);
            for (int i = 0; i < back.Length; i++)
            {
                Console.SetCursorPosition(3 + i, 7);
                Console.Write("-");
            }
            Console.SetCursorPosition(3 + back.Length, 6);
            for (int i = 8; i < 20; i += 2)
            {
                Console.SetCursorPosition(3, 2 + i);
                Console.Write(i + ":00 - " + (i + 2) + ":00");
            }
            Console.SetCursorPosition(20, 8);
            Console.Write("Hétfő");
            Console.SetCursorPosition(32, 8);
            Console.Write("Kedd");
            Console.SetCursorPosition(44, 8);
            Console.Write("Szerda");
            Console.SetCursorPosition(56, 8);
            Console.Write("Csütörtök");
            Console.SetCursorPosition(68, 8);
            Console.Write("Péntek");
            int pos = 0;
            string current = "";
            for (int i = 0; i < subjects.Count; i++)
            {
                switch (subjects[i].getDay())
                {
                    case "Hetfo":
                        cursorpos = 20;
                        break;
                    case "Kedd":
                        cursorpos = 32;
                        break;
                    case "Szerda":
                        cursorpos = 44;
                        break;
                    case "Csutortok":
                        cursorpos = 56;
                        break;
                    case "Pentek":
                        cursorpos = 68;
                        break;
                }

                current = subjects[i].getStartTime().Remove(subjects[i].getStartTime().Length - 3);
                pos = Int32.Parse(current) + 2;
                Console.SetCursorPosition(cursorpos, pos);
                Console.Write(subjects[i].getName());

            }
            Console.SetCursorPosition(4 + back.Length, 6);

            do
            {
                input = Console.ReadKey();
            } while (input.Key != ConsoleKey.Enter);
            CMD command = new CMD();
            return command;
        }
        public CMD requestSubmissionMenu()
        {
            CMD command = new CMD();
            return command;
        }
        private void requestUnderline()
        {

        }
        public CMD registerForSubjectMenu(List<Subject> subjects)
        {
            CMD command = new CMD();
            return command;
        }
        private void subjectUnderline()
        {

        }
        public CMD deregisterSubjectMenu(List<Subject> subjects)
        {
            CMD command = new CMD();
            return command;
        }
    }
}
