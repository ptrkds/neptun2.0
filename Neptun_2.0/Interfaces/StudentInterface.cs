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
        private int countsubject = 0;
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
                    command.cmd = "requestSubmission";
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
                if (subjects[i].getName().Length < 11)
                {
                    Console.SetCursorPosition(cursorpos, pos);
                    Console.Write(subjects[i].getName());
                }
                else if (subjects[i].getName().Length < 21)
                {
                    Console.SetCursorPosition(cursorpos, pos);
                    Console.Write(subjects[i].getName().Remove(10));
                    Console.SetCursorPosition(cursorpos, pos + 1);
                    Console.Write(subjects[i].getName().Remove(0, 10));
                }
                else
                {
                    Console.SetCursorPosition(cursorpos, pos);
                    Console.Write(subjects[i].getName().Remove(10));
                    Console.SetCursorPosition(cursorpos, pos + 1);
                    Console.Write(subjects[i].getName().Remove(0, 10).Remove(10));
                }

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
            position = 1;
            Console.SetCursorPosition(1, 6);
            Console.Write("Adja meg a felvinni kívánt kérvény támáját, és kifejtését!");
            Console.SetCursorPosition(2, 8);
            Console.Write(back + "   ");
            Console.SetCursorPosition(2, 10);
            Console.Write(application + "   ");
            Console.SetCursorPosition(2, 12);
            Console.Write("Az kérvény témája:   ");
            Console.SetCursorPosition(2, 14);
            Console.Write("A kérvény kifejtése: (üssön entert, ha a sor végére ér!):    ");
            String thema = "";
            String text = "";
            int lengthThema = 0;
            int lengthText = 0;
            int rowText = 1;
            List<int> rowslength = new List<int>();            
            requestUnderline(lengthThema, lengthText, rowText);
            do
            {
                input = Console.ReadKey();
                if (position < 3)
                {
                    Console.Write("\b ");
                }
                if (!((input.KeyChar >= 'a' && input.KeyChar <= 'z') || (input.KeyChar >= 'A' && input.KeyChar <= 'Z') || (input.KeyChar >= '0' && input.KeyChar <= '9') || (input.Key == ConsoleKey.Spacebar) || (input.KeyChar == '.')) && input.Key != ConsoleKey.Backspace)
                {
                    Console.Write("\b ");
                }
                if ((input.KeyChar >= 'a' && input.KeyChar <= 'z') || (input.KeyChar >= 'A' && input.KeyChar <= 'Z') || (input.KeyChar >= '0' && input.KeyChar <= '9') || (input.Key == ConsoleKey.Spacebar) || (input.KeyChar == '.'))
                {
                    switch (position)
                    {
                        case 3:
                            lengthThema++;
                            thema += input.KeyChar;
                            break;
                        case 4:
                            lengthText++;
                            text += input.KeyChar;
                            break;
                    }
                }
                if(position == 4 && input.Key == ConsoleKey.Enter)
                {
                    rowslength.Add(lengthText);                    
                    text += " ";
                    lengthText = 0;
                    rowText++;
                }
                if(lengthText == 0 && rowText-1 > 0 && input.Key == ConsoleKey.Backspace && position == 4)
                {
                    rowText--;                    
                    lengthText = rowslength[rowText-1] + 1;               
                }

                if (input.Key == ConsoleKey.Backspace)
                {
                    switch (position)
                    {
                        case 3:
                            if (lengthThema > 0)
                            {
                                thema = thema.Remove(thema.Length - 1);
                                lengthThema--;
                                Console.Write(" ");
                            }
                            break;
                        case 4:
                            if (lengthText > 0)
                            {
                                text = text.Remove(text.Length - 1);
                                lengthText--;
                                Console.Write(" ");
                            }
                            break;
                    }
                }
                if (input.Key == ConsoleKey.DownArrow)
                    position++;
                if (input.Key == ConsoleKey.UpArrow)
                    position--;
                if (position < 1)
                    position = 4;
                if (position > 4)
                    position = 1;
                requestUnderline(lengthThema, lengthText, rowText);
            } while (input.Key != ConsoleKey.Enter || position > 2);
            CMD command = new CMD();
            command.data = new List<string>();
            if (position == 1)
                command.cmd = "exit";
            else
            {
                command.data.Add(thema);
                command.data.Add(text);
            }            
            return command;
        }
        public void requestSubmission_successful()
        {
            subMenuremove(6, countsubject + 2);
            Console.SetCursorPosition(3, 11);
            Console.Write("A kérvény leadása sikeres volt!");
            input = Console.ReadKey();
        }
        public void requestSubmission_unsuccessful()
        {
            subMenuremove(6, countsubject + 2);
            Console.SetCursorPosition(3, 11);
            Console.Write("A kérvény leadása sikertelen volt!");
            input = Console.ReadKey();
        }
        private void requestUnderline(int lengthThema, int lengthText, int rowText)
        {
            if (position != 1)
            {
                Console.SetCursorPosition(2, 9);
                Console.Write(new string(' ', Console.WindowWidth));
            }
            if (position != 2)
            {

                Console.SetCursorPosition(2, 11);
                Console.Write(new string(' ', Console.WindowWidth));
            }
            if (position == 1)
            {
                for (int i = 0; i < back.Length; i++)
                {
                    Console.SetCursorPosition(2 + i, 9);
                    Console.Write("-");
                }
                Console.SetCursorPosition(4 + back.Length, 8);
            }
            if (position == 2)
            {
                for (int i = 0; i < application.Length; i++)
                {
                    Console.SetCursorPosition(2 + i, 11);
                    Console.Write("-");
                }
                Console.SetCursorPosition(4 + application.Length, 10);
            }
            switch (position)
            {
                case 3:
                    Console.SetCursorPosition(22 + lengthThema, 12);
                    break;
                case 4:
                    Console.SetCursorPosition(3 + lengthText, 14+rowText);
                    break;
            }
        }
        public CMD selectSubject(List<short_subject> subjects)
        {
            CMD command = new CMD();
            command.data = new List<string>();
            command = registerOrDeregiseterSubject(subjects, true);
            return command;
        }
        public void regForSubject_successful()
        {
            subMenuremove(6, countsubject+2);
            Console.SetCursorPosition(3, 11);
            Console.Write("A tárgy felvétele sikeres volt!");
            input = Console.ReadKey();
        }
        public void regForSubject_unsuccessful()
        {
            subMenuremove(6, countsubject + 2);
            Console.SetCursorPosition(3, 11);
            Console.Write("A tárgy felvétele sikertelen volt!");
            input = Console.ReadKey();
        }
        public void deregister_successful()
        {
            subMenuremove(6, countsubject + 2);
            Console.SetCursorPosition(3, 11);
            Console.Write("A tárgy leadása sikeres volt!");
            input = Console.ReadKey();
        }
        public void deregister_unsuccessful()
        {
            subMenuremove(6, countsubject + 2);
            Console.SetCursorPosition(3, 11);
            Console.Write("A tárgy leadása sikertelen volt!");
            input = Console.ReadKey();
        }

        private CMD registerOrDeregiseterSubject(List<short_subject> subjects, Boolean register)
        {
            position = 1;
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(i * 4, 4);
                Console.Write("____");
            }
            Console.SetCursorPosition(3, 6);
            if(register)
                Console.Write("Adja meg, hogy melyik tantárgyat szeretné felvenni:");
            else
                Console.Write("Adja meg, hogy melyik tantárgyról szeretne leiratkozni:");
            Console.SetCursorPosition(5, 8);
            Console.Write(back + "   ");
            countsubject = subjects.Count;
            subMainUnderline(countsubject, 0);
            for (int i = 0; i < subjects.Count; i++)
            {
                Console.SetCursorPosition(5, 10 + i);
                Console.Write(subjects[i].id + "   " + subjects[i].name + "   ");

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
                    position = countsubject + 1;
                if (position > countsubject + 1)
                    position = 1;
                subMainUnderline(countsubject, 0);
            } while (input.Key != ConsoleKey.Enter);
            CMD command = new CMD();
            command.data = new List<string>();
            if (position == 1)
                command.cmd = "exit";
            else
            {
                command.data.Add(subjects[position - 2].id);
            }
            return command;
        }

        public CMD deregisterSubjectMenu(List<short_subject> subjects)
        {
            CMD command = new CMD();
            command.data = new List<string>();
            command = registerOrDeregiseterSubject(subjects, false);
            return command;
        }
        public Boolean areYouSure(string name = "")
        {
            subMenuremove(10, countsubject);
            Console.SetCursorPosition(3, 6);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.Write("Biztosan le szeretnéd adni a/az " + name + " tanrágyat?");
            subAreYouSure();
            if (position == 1)
                return true;
            else
                return false;
        }

    }
}
