using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class TeacherInterface : Interface
    {
        private String timeTable = "Órarend";
        private String filter = "Szűrés";
        private String studentBlock = "Tanuló letiltása";
        private String demand = "Igények";
        private String demandSubmission = "Igény felvitele";
        private String demandChange = "Igény modosítása";
        private String yes = "Igen";
        private String no = "Nem";
        private int countsubject = 0;
        private int countusers = 0;
        public CMD TeacherMainMenu()
        {
            //WriteMenu
            position = 1;
            Console.Clear();
            Console.SetCursorPosition(1, 2);
            Console.Write(timeTable);
            Console.SetCursorPosition(15, 2);
            Console.Write(filter);
            Console.SetCursorPosition(27, 2);
            Console.Write(studentBlock);
            Console.SetCursorPosition(50, 2);
            Console.Write(demand);
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
                    command.cmd = "filter";
                    break;
                case 3:
                    command.cmd = "studentBlock";
                    break;
                case 4:
                    command.cmd = "demand";
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
                    for (int i = 0; i < filter.Length; i++)
                    {
                        Console.SetCursorPosition(15 + i, 3);
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(16 + filter.Length, 2);
                    break;
                case 3:
                    for (int i = 0; i < studentBlock.Length; i++)
                    {
                        Console.SetCursorPosition(27 + i, 3);
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(28 + studentBlock.Length, 2);
                    break;
                case 4:
                    for (int i = 0; i < demand.Length; i++)
                    {
                        Console.SetCursorPosition(50 + i, 3);
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(51 + demand.Length, 2);
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

        public CMD demandMenu()
        {
            position = 1;
            Console.SetCursorPosition(36, 4);
            Console.Write("_________________|_________________");
            Console.SetCursorPosition(36, 5);
            Console.Write("|                |                |");
            Console.SetCursorPosition(28, 6);
            Console.Write(demandSubmission);
            Console.SetCursorPosition(46, 6);
            Console.Write(demandChange);
            Console.SetCursorPosition(65, 6);
            Console.Write(back);            
            demandMenuUnderline();
            do
            {
                input = Console.ReadKey();
                if (input.Key == ConsoleKey.RightArrow)
                    position++;
                if (input.Key == ConsoleKey.LeftArrow)
                    position--;
                if (position < 1)
                    position = 3;
                if (position > 3)
                    position = 1;
                demandMenuUnderline();
            } while (input.Key != ConsoleKey.Enter);

            CMD command = new CMD();
            switch (position)
            {
                case 1:
                    command.cmd = "demandSubmission";
                    break;
                case 2:
                    command.cmd = "demandChange";
                    break;
                case 3:
                    command.cmd = "back";
                    break;
            }
            return command;
        }
        private void demandMenuUnderline()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(i * 4, 7);
                Console.Write("    ");
            }
            switch (position)
            {
                case 1:
                    for (int i = 0; i < demandSubmission.Length; i++)
                    {
                        Console.SetCursorPosition(28 + i, 7);
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(29 + demandSubmission.Length, 6);
                    break;
                case 2:
                    for (int i = 0; i < demandChange.Length; i++)
                    {
                        Console.SetCursorPosition(46 + i, 7);
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(47 + demandChange.Length, 6);
                    break;
                case 3:
                    for (int i = 0; i < back.Length; i++)
                    {
                        Console.SetCursorPosition(65 + i, 7);
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(66 + back.Length, 6);
                    break;
            }
        }
        public CMD timeTableView(List<string> timetable)
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
            for(int i=8;i<20;i+=2)
            {
                Console.SetCursorPosition(3, 2 + i);
                Console.Write(i + ":00 - " + (i+1) + ":30");
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
            do
            {
                input = Console.ReadKey();
            } while (input.Key != ConsoleKey.Enter);
            CMD command = new CMD();
            return command;
        }
        public CMD selectSubject(List<short_subject> subject)
        {
            subMenuremove(10, countusers);
            position = 1;
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(i * 4, 4);
                Console.Write("____");
            }
            Console.SetCursorPosition(3, 6);
            Console.Write("Adja meg, hogy melyik tantárgyról szeretne diákot letiltani:");
            Console.SetCursorPosition(5, 8);
            Console.Write(back + "   ");
            countsubject = subject.Count;
            subMainUnderline(countsubject);
            for (int i = 0; i < subject.Count; i++)
            {
                Console.SetCursorPosition(5, 10 + i);
                Console.Write(subject[i].name + "   ");
                
            }
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
                subMainUnderline(countsubject);
            } while (input.Key != ConsoleKey.Enter);
            CMD command = new CMD();
            command.data = new List<string>();
            if (position == 1)
                command.cmd = "exit";
            else
                command.data.Add(subject[position-2].id);
            return command;
        }
        private void subMainUnderline(int max)
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
                Console.SetCursorPosition(2, 10 + position - 2);
                Console.Write("->");
            }
        }
        public CMD selectStudent(List<short_user> users)
        {
            subMenuremove(10, countsubject);
            position = 1;
            Console.SetCursorPosition(3, 6);
            Console.Write("Adja meg, hogy melyik diákot szeretné letiltani:              ");
            countusers = users.Count;
            subMainUnderline(countusers);            
            for (int i = 0; i < users.Count; i++)
            {
                Console.SetCursorPosition(5, 10 + i);
                Console.Write(users[i].id + "  " + users[i].name + "   ");                
            }
            do
            {
                input = Console.ReadKey();
                if (input.Key == ConsoleKey.DownArrow)
                    position++;
                if (input.Key == ConsoleKey.UpArrow)
                    position--;
                if (position < 1)
                    position = countusers + 1;
                if (position > countusers + 1)
                    position = 1;
                subMainUnderline(countusers);
            } while (input.Key != ConsoleKey.Enter);
            CMD command = new CMD();
            command.data = new List<string>();
            if (position == 1)
                command.cmd = "exit";
            else
            {
                command.data.Add(users[position - 2].id);
                command.data.Add(users[position - 2].name);
            }
            return command;
        }
        public void studentBlock_successful()
        {
            subMenuremove(10, countusers);
            position = 1;
            subMainUnderline(0);
            Console.SetCursorPosition(3, 6);
            Console.Write("A tanuló letiltása a tantárgyról sikeres volt!  ");
            Console.SetCursorPosition(3, 8);
            Console.Write(new string(' ', Console.WindowWidth));
            input = Console.ReadKey();
        }
        public void studentBlock_unsuccessful()
        {
            subMenuremove(10, countusers);
            position = 1;
            subMainUnderline(0);
            Console.SetCursorPosition(3, 6);
            Console.Write("A tanuló letiltása a tantárgyról sikertelen volt!");
            Console.SetCursorPosition(3, 8);
            Console.Write(new string(' ', Console.WindowWidth));
            input = Console.ReadKey();
        }
        public Boolean areYouSure(string name = "")
        {
            subMenuremove(10, countusers);
            Console.SetCursorPosition(3, 6);
            Console.Write("Biztosan le szeretné tiltani " + name + "-t?              ");
            position = 1;
            Console.SetCursorPosition(3, 8);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(3, 8);
            Console.Write(yes);
            Console.SetCursorPosition(12, 8);
            Console.Write(no);
            areYouSureUnderline();
            do
            {
                input = Console.ReadKey();
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
            if (position == 1)
                return true;
            else
                return false;
        }
        private void areYouSureUnderline()
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
                    Console.SetCursorPosition(13 + back.Length, 8);
                    break;
            }
        }

        private void subMenuremove(int where, int length)
        {
            for(int i=where;i<where+length;i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.SetCursorPosition(j * 4, i);
                    Console.Write("    ");
                }
            }
        }
    }
}
