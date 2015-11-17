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
        public CMD TeacherMainMenu()
        {
            //WriteMenu
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
    }
}
