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
        private String filtering = "Szűrés";
        private int countsubject = 0;
        private int countusers = 0;
        private int countrooms = 0;
        private int countdemands = 0;
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
                Console.Write("\b ");
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
                    Console.SetCursorPosition(65 + logOut.Length, 2);
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
                Console.Write("\b ");
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
        public CMD demandSubmissionMenu(List<ClassRoom> rooms, string selected_room="", string defstart="", string defend="")
        {
            if (selected_room == "")
            {
                position = 1;
                for (int i = 0; i < 20; i++)
                {
                    Console.SetCursorPosition(i * 4, 9);
                    Console.Write("____");
                }
                Console.SetCursorPosition(1, 11);
                Console.Write("Adja meg, hogy melyik termet szeretné igényelni egy új tantárgy felvitelére:");
                Console.SetCursorPosition(5, 13);
                Console.Write(back + "   ");
                countrooms = rooms.Count;                
                for (int i = 0; i < countrooms; i++)
                {
                    Console.SetCursorPosition(5, 15 + i);
                    Console.Write(rooms[i].getId() + "   ");
                }
                subMainUnderline(countrooms, 5);
                do
                {
                    input = Console.ReadKey();
                    if (input.Key == ConsoleKey.DownArrow)
                        position++;
                    if (input.Key == ConsoleKey.UpArrow)
                        position--;
                    if (position < 1)
                        position = countrooms + 1;
                    if (position > countrooms + 1)
                        position = 1;
                    subMainUnderline(countrooms, 5);
                } while (input.Key != ConsoleKey.Enter);
            }
            CMD command = new CMD();
            command.data = new List<string>();
            if (selected_room == "")
            {
                if (position == 1)
                    command.cmd = "exit";
                else
                    command.data.Add(rooms[position - 2].getId());
            }
            else
                command.data.Add(selected_room);
            String subjectID = "";
            String subjectName = "";
            String day = "";
            String start = defstart;
            String end = defend;
            if (command.cmd != "exit")
            {
                List<String> list;
                list = new List<string>();
                list = demandSubMenu(subjectID, subjectName, day, start, end);
                subjectID = list[0];
                subjectName = list[1];
                day = list[2];
                start = list[3];
                end = list[4];
            }
            String subjectDay="";
            switch(day)
            {
                case "1":
                    subjectDay = "Hetfo";
                    break;
                case "2":
                    subjectDay = "Kedd";
                    break;
                case "3":
                    subjectDay = "Szerda";
                    break;
                case "4":
                    subjectDay = "Csutortok";
                    break;
                case "5":
                    subjectDay = "Pentek";
                    break;
            }
            if(position==1)                
                    command.cmd = "exit";
            else
            {
                command.data.Add(subjectID);
                command.data.Add(subjectName);
                command.data.Add(subjectDay);
                command.data.Add(start+":00");
                command.data.Add(end+":00");
            }   
            return command;
        }

        public CMD demandChangeMenu(List<Demand> demands)
        {
            position = 1;
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(i * 4, 9);
                Console.Write("____");
            }
            Console.SetCursorPosition(1, 11);
            Console.Write("Adja meg, hogy melyik igényt szeretné megváltoztatni:");
            Console.SetCursorPosition(5, 13);
            Console.Write(back + "   ");
            countdemands = demands.Count;
            for (int i = 0; i < countdemands; i++)
            {
                Console.SetCursorPosition(5, 15 + i);
                Console.Write(demands[i].getSubjectId() + "   " + demands[i].getSubjectName() + "   ");
            }
            subMainUnderline(countdemands, 5);
            do
            {
                input = Console.ReadKey();
                if (input.Key == ConsoleKey.DownArrow)
                    position++;
                if (input.Key == ConsoleKey.UpArrow)
                    position--;
                if (position < 1)
                    position = countdemands + 1;
                if (position > countdemands + 1)
                    position = 1;
                subMainUnderline(countdemands, 5);
            } while (input.Key != ConsoleKey.Enter);
            CMD command = new CMD();
            command.data = new List<string>();
            if (position == 1)
                command.cmd = "exit";
            else
            {
                int demandNumb = position - 2;
                command.data.Add(demands[demandNumb].getId()); 
            }
            return command;
        }
        public CMD demandChangeSubMenu(Demand demand, List<ClassRoom> rooms)
        { 
            
            position = 1;
            subMenuremove(15, countdemands);
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(i * 4, 9);
                Console.Write("____");
            }
            Console.SetCursorPosition(1, 11);
            Console.Write("Adja meg, melyik termet szeretné igényelni a/az " + demand.getRoomId() + " helyett:");
            Console.SetCursorPosition(5, 13);
            Console.Write(back + "   ");
            countrooms = rooms.Count;
            for (int i = 0; i < countrooms; i++)
            {
                Console.SetCursorPosition(5, 15 + i);
                Console.Write(rooms[i].getId() + "   ");
            }
            subMainUnderline(countrooms, 5);
            do
            {
                input = Console.ReadKey();
                if (input.Key == ConsoleKey.DownArrow)
                    position++;
                if (input.Key == ConsoleKey.UpArrow)
                    position--;
                if (position < 1)
                    position = countrooms + 1;
                if (position > countrooms + 1)
                    position = 1;
                subMainUnderline(countrooms, 5);
            } while (input.Key != ConsoleKey.Enter);
            CMD command = new CMD();
            command.data = new List<string>();            
            if (position == 1)
                command.cmd = "exit";
            else
                command.data.Add(rooms[position - 2].getId());
            String day = "";
            switch(demand.getDay())
            {
                case "Hetfo":
                    day = "1";
                    break;
                case "Kedd":
                    day = "2";
                    break;
                case "Szerda":
                    day = "3";
                    break;
                case "Csutortok":
                    day = "4";
                    break;
                case "Pentek":
                    day = "5";
                    break;
            }
            String subjectID = "";
            String subjectName = "";            
            String start = "";
            String end = "";
            if (command.cmd != "exit")
            {
                List<String> list;
                list = new List<string>();
                list = demandSubMenu(demand.getSubjectId(), demand.getSubjectName(), day, demand.getStartTime(), demand.getEndTime());
                subjectID = list[0];
                subjectName = list[1];
                day = list[2];
                start = list[3];
                end = list[4];
            }
            String subjectDay = "";
            switch (day)
            {
                case "1":
                    subjectDay = "Hetfo";
                    break;
                case "2":
                    subjectDay = "Kedd";
                    break;
                case "3":
                    subjectDay = "Szerda";
                    break;
                case "4":
                    subjectDay = "Csutortok";
                    break;
                case "5":
                    subjectDay = "Pentek";
                    break;
            }
            if (position == 1)
                command.cmd = "exit";
            else
            {
                command.data.Add(subjectID);
                command.data.Add(subjectName);
                command.data.Add(subjectDay);
                command.data.Add(start + ":00");
                command.data.Add(end + ":00");
            }
            return command;
        }

        private List<String> demandSubMenu(String subjectID, String subjectName, String day, String start, String end)
        {
            List<String> list;

            subMenuremove(15, countrooms);
            position = 1;
            Console.SetCursorPosition(1, 11);
            Console.Write("Adja meg, a tárgy ID-jét, nevét, és hogy melyik nap mikor kezdődjön, végződjön!  ");
            Console.SetCursorPosition(2, 13);
            Console.Write(back + "   ");
            Console.SetCursorPosition(2, 15);
            Console.Write(application + "   ");
            Console.SetCursorPosition(2, 17);
            Console.Write("Tantárgy ID-je:   " + subjectID);
            Console.SetCursorPosition(2, 19);
            Console.Write("Tantárgy neve:    " + subjectName);
            Console.SetCursorPosition(2, 21);
            Console.Write("Melyik napon legyen (számot írjon: 1 - Hétfő ... 5 - Péntek): " + day);
            Console.SetCursorPosition(2, 23);
            if(start != "")
            {
                start = start.Remove(start.Length - 3);
            }
            Console.Write("Mikor kezdődjön (Csak 8, 10,...,18 számokat írjon be, Pl: 8->8:00): " + start);
            Console.SetCursorPosition(2, 24);
            if (start != "")
            {
                end = end.Remove(end.Length - 3);
            }
            Console.Write("Óra vége (Rendszerben 2 órásak az órák. Pl: kezdés: 8 -> vége: 10): " + end);
            int lengthID = subjectID.Length;
            int lengthName = subjectName.Length;
            int lengthDay = day.Length;
            int lengthStart = start.Length;
            int lengthEnd = end.Length;
            demandUnderline(lengthID, lengthName, lengthDay, lengthStart, lengthEnd);
            do
            {
                input = Console.ReadKey();
                if (position < 3)
                {
                    Console.Write("\b ");
                }
                if (!((input.KeyChar >= 'a' && input.KeyChar <= 'z') || (input.KeyChar >= 'A' && input.KeyChar <= 'Z') || (input.KeyChar >= '0' && input.KeyChar <= '9') || (input.Key == ConsoleKey.Spacebar)) && input.Key != ConsoleKey.Backspace)
                {
                    Console.Write("\b ");
                }
                if (((input.KeyChar >= 'a' && input.KeyChar <= 'z') || (input.KeyChar >= 'A' && input.KeyChar <= 'Z') || (input.KeyChar >= '0' && input.KeyChar <= '9') || (input.Key == ConsoleKey.Spacebar)))
                {
                    switch (position)
                    {
                        case 3:
                            lengthID++;
                            subjectID += input.KeyChar;
                            break;
                        case 4:
                            lengthName++;
                            subjectName += input.KeyChar;
                            break;
                        case 5:
                            lengthDay++;
                            day += input.KeyChar;
                            break;
                        case 6:
                            lengthStart++;
                            start += input.KeyChar;
                            break;
                        case 7:
                            lengthEnd++;
                            end += input.KeyChar;
                            break;
                    }
                }
                if (input.Key == ConsoleKey.Backspace)
                {
                    switch (position)
                    {
                        case 3:
                            if (lengthID > 0)
                            {
                                subjectID = subjectID.Remove(subjectID.Length - 1);
                                lengthID--;
                                Console.Write(" ");
                            }
                            break;
                        case 4:
                            if (lengthName > 0)
                            {
                                subjectName = subjectName.Remove(subjectName.Length - 1);
                                lengthName--;
                                Console.Write(" ");
                            }
                            break;
                        case 5:
                            if (lengthDay > 0)
                            {
                                day = day.Remove(day.Length - 1);
                                lengthDay--;
                                Console.Write(" ");
                            }
                            break;
                        case 6:
                            if (lengthStart > 0)
                            {
                                start = start.Remove(start.Length - 1);
                                lengthStart--;
                                Console.Write(" ");
                            }
                            break;
                        case 7:
                            if (lengthEnd > 0)
                            {
                                end = end.Remove(end.Length - 1);
                                lengthEnd--;
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
                    position = 7;
                if (position > 7)
                    position = 1;
                demandUnderline(lengthID, lengthName, lengthDay, lengthStart, lengthEnd);
            } while (input.Key != ConsoleKey.Enter || position > 2);

            list = new List<string>();
            list.Add(subjectID);
            list.Add(subjectName);
            list.Add(day);
            list.Add(start);
            list.Add(end);
            return list;
        }

        public void demandSubmission_successful()
        {
            subMenuremove(11,14);            
            Console.SetCursorPosition(3, 11);
            Console.Write("Az igény felvitele sikeres volt!");            
            input = Console.ReadKey();
        }
        public void demandSubmission_unsuccessful()
        {
            subMenuremove(11, 14);
            Console.SetCursorPosition(3, 11);
            Console.Write("Az igény felvitele sikertelen volt!");
            input = Console.ReadKey();
        }
        public void demandChange_successful()
        {
            subMenuremove(11, 14);
            Console.SetCursorPosition(3, 11);
            Console.Write("Az igény módosítása sikeres volt!");
            input = Console.ReadKey();
        }
        public void demandChange_unsuccessful()
        {
            subMenuremove(11, 14);
            Console.SetCursorPosition(3, 11);
            Console.Write("Az igény módosítása sikertelen volt!");
            input = Console.ReadKey();
        }

        private void demandUnderline(int ID, int name, int day, int start, int end)
        {
            if (position != 1)
            {
                Console.SetCursorPosition(2, 14);
                Console.Write(new string(' ', Console.WindowWidth));
            }
            if (position != 2)
            {

                Console.SetCursorPosition(2, 16);
                Console.Write(new string(' ', Console.WindowWidth));
            }
            if (position == 1)
            {
                for (int i = 0; i < back.Length; i++)
                {
                    Console.SetCursorPosition(2 + i, 14);
                    Console.Write("-");
                }
                Console.SetCursorPosition(4 + back.Length, 13);
            }
            if (position == 2)
            {
                for (int i = 0; i < application.Length; i++)
                {
                    Console.SetCursorPosition(2 + i, 16);
                    Console.Write("-");
                }
                Console.SetCursorPosition(4 + application.Length, 15);
            }            
            switch(position)
            {
                case 3:
                    Console.SetCursorPosition(20+ID, 17);
                    break;
                case 4:
                    Console.SetCursorPosition(20 + name, 19);
                    break;
                case 5:
                    Console.SetCursorPosition(64 + day, 21);
                    break;
                case 6:
                    Console.SetCursorPosition(70 + start, 23);
                    break;
                case 7:
                    Console.SetCursorPosition(70 + end, 24);
                    break;
            }           

        }
       
        public CMD selectFilterTime()
        {
            position = 1;
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(i * 4, 4);
                Console.Write("____");
            }
            Console.SetCursorPosition(3, 6);            
            Console.Write("Adja meg, milyen időpont szerint szeretne szűri termekre:");
            Console.SetCursorPosition(2, 8);
            Console.Write(back + "   ");
            Console.SetCursorPosition(2, 10);
            Console.Write(filtering + "   ");                       
            Console.SetCursorPosition(2, 12);            
            Console.Write("Mikor kezdődjön (Csak 8, 10,...,18 számokat írjon be, Pl: 8->8:00): ");
            Console.SetCursorPosition(2, 14);
            Console.Write("Óra vége (Rendszerben 2 órásak az órák. Pl: kezdés: 8 -> vége: 10): ");

            String start = "";
            String end = "";
            int lengthStart = 0;
            int lengthEnd = 0;
            selectFilterUnderline(lengthStart, lengthEnd);
            do
            {
                input = Console.ReadKey();
                if (position < 3)
                {
                    Console.Write("\b ");
                }
                if (!((input.KeyChar >= 'a' && input.KeyChar <= 'z') || (input.KeyChar >= 'A' && input.KeyChar <= 'Z') || (input.KeyChar >= '0' && input.KeyChar <= '9') || (input.Key == ConsoleKey.Spacebar)) && input.Key != ConsoleKey.Backspace)
                {
                    Console.Write("\b ");
                }
                if (((input.KeyChar >= 'a' && input.KeyChar <= 'z') || (input.KeyChar >= 'A' && input.KeyChar <= 'Z') || (input.KeyChar >= '0' && input.KeyChar <= '9') || (input.Key == ConsoleKey.Spacebar)))
                {
                    switch (position)
                    {
                        case 3:
                            lengthStart++;
                            start += input.KeyChar;
                            break;
                        case 4:
                            lengthEnd++;
                            end += input.KeyChar;
                            break;
                    }
                }
                if (input.Key == ConsoleKey.Backspace)
                {
                    switch (position)
                    {
                        case 3:
                            if (lengthStart > 0)
                            {
                                start = start.Remove(start.Length - 1);
                                lengthStart--;
                                Console.Write(" ");
                            }
                            break;
                        case 4:
                            if (lengthEnd > 0)
                            {
                                end = end.Remove(end.Length - 1);
                                lengthEnd--;
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
                selectFilterUnderline(lengthStart, lengthEnd);
            } while (input.Key != ConsoleKey.Enter || position > 2) ;      
            CMD command = new CMD();
            command.data = new List<string>();
            if(position == 1)
            {
                command.cmd = "exit";
            }
            else
            {
                command.data.Add(start + ":00");
                command.data.Add(end + ":00");
            }
            return command;
        }

        public CMD filterSelectClass(List<ClassRoom> rooms)
        {
            position = 1;
            subMenuremove(6, 12);
            Console.SetCursorPosition(1, 6);
            Console.Write("Adja meg, hogy melyik termet szeretné választani, amit lefoglalhat:");
            Console.SetCursorPosition(5, 8);
            Console.Write(back + "   ");
            countrooms = rooms.Count;
            for (int i = 0; i < countrooms; i++)
            {
                Console.SetCursorPosition(5, 10 + i);
                Console.Write(rooms[i].getId() + "   ");
            }
            subMainUnderline(countrooms, 0);
            do
            {
                input = Console.ReadKey();
                if (input.Key == ConsoleKey.DownArrow)
                    position++;
                if (input.Key == ConsoleKey.UpArrow)
                    position--;
                if (position < 1)
                    position = countrooms + 1;
                if (position > countrooms + 1)
                    position = 1;
                subMainUnderline(countrooms, 0);
            } while (input.Key != ConsoleKey.Enter);    
            CMD command = new CMD();
            command.data = new List<string>();
            if (position == 1)
                    command.cmd = "exit";
            else
            {
                command.data.Add(rooms[position - 2].getId());
                subMenuremove(4, 6+ countrooms);
                position = 1;
                for (int i = 0; i < 20; i++)
                {
                    Console.SetCursorPosition(i * 4, 8);
                    Console.Write("____");
                }
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
            }
            
            return command;
        }
        private void selectFilterUnderline(int start, int end)
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
                for (int i = 0; i < filtering.Length; i++)
                {
                    Console.SetCursorPosition(2 + i, 11);
                    Console.Write("-");
                }
                Console.SetCursorPosition(4 + filtering.Length, 10);
            }
            switch (position)
            {                
                case 3:
                    Console.SetCursorPosition(70 + start, 12);
                    break;
                case 4:
                    Console.SetCursorPosition(70 + end, 14);
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
            for(int i=8;i<20;i+=2)
            {
                Console.SetCursorPosition(3, 2 + i);
                Console.Write(i + ":00 - " + (i+2) + ":00");
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
            int pos=0;
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
                else if(subjects[i].getName().Length < 21)
                {
                    Console.SetCursorPosition(cursorpos, pos);
                    Console.Write(subjects[i].getName().Remove(10));
                    Console.SetCursorPosition(cursorpos, pos+1);
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
                Console.Write("\b ");
                Console.SetCursorPosition(4 + back.Length, 6);
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
            subMainUnderline(countsubject,0);            
            for (int i = 0; i < subject.Count; i++)
            {
                Console.SetCursorPosition(5, 10 + i);
                Console.Write(subject[i].name + "   ");
                
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
                command.data.Add(subject[position-2].id);
            return command;
        }
        
        public CMD selectStudent(List<short_user> users)
        {
            subMenuremove(10, countsubject);
            position = 1;
            Console.SetCursorPosition(3, 6);
            Console.Write("Adja meg, hogy melyik diákot szeretné letiltani:              ");
            countusers = users.Count;
            subMainUnderline(countusers,0);            
            for (int i = 0; i < users.Count; i++)
            {
                Console.SetCursorPosition(5, 10 + i);
                Console.Write(users[i].id + "  " + users[i].name + "   ");                
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
                    position = countusers + 1;
                if (position > countusers + 1)
                    position = 1;
                subMainUnderline(countusers,0);
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
            subMainUnderline(0,0);
            Console.SetCursorPosition(3, 6);
            Console.Write("A tanuló letiltása a tantárgyról sikeres volt!  ");
            Console.SetCursorPosition(3, 8);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(3, 9);
            Console.Write(new string(' ', Console.WindowWidth));
            input = Console.ReadKey();
        }
        public void studentBlock_unsuccessful()
        {
            subMenuremove(10, countusers);
            position = 1;
            subMainUnderline(0,0);
            Console.SetCursorPosition(3, 6);
            Console.Write("A tanuló letiltása a tantárgyról sikertelen volt!");
            Console.SetCursorPosition(3, 8);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(3, 9);
            Console.Write(new string(' ', Console.WindowWidth));
            input = Console.ReadKey();
        }
        public Boolean areYouSure(string name = "")
        {
            subMenuremove(10, countusers);
            Console.SetCursorPosition(3, 6);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.Write("Biztosan le szeretné tiltani " + name + "-t?");
            subAreYouSure();
            if (position == 1)
                return true;
            else
                return false;
        }              
        
    }
}