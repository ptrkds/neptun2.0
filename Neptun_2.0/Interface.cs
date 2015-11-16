using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    

    class Interface
    {
        public CMD Login(Boolean relogin=false)
        {            
            if(relogin)
            {
                Console.SetCursorPosition(5, 17);
                Console.Write("Hibás neptun kód vagy jelszó!");
            }
            Console.SetCursorPosition(10,4);
            Console.Write("Neptun 2.0 - Bejelentkezés:");
            Console.SetCursorPosition(5, 5);
            Console.Write("(a nyilakkal tud navigálni, neptun kód és jelszó is csak kis betű lehet)");
            Console.SetCursorPosition(5, 8);
            Console.Write("Neptun kód:");
            Console.SetCursorPosition(5, 10);
            Console.Write("Jelszó:");
            Console.SetCursorPosition(5, 12);
            Console.Write("Belejentkezés");
            Console.SetCursorPosition(5, 14);
            Console.Write("Kilépés a programból");
            int curpos = 8;
            Console.SetCursorPosition(20, curpos);
            int position = 1;
            int lengthneptun = 0;
            int lengthpassword = 0;
            String neptuncode = "";
            String password = "";
            ConsoleKeyInfo input;
            do
            {
                input = Console.ReadKey();
                if(!((input.KeyChar >= 'a' && input.KeyChar <= 'z') || (input.KeyChar >= '0' && input.KeyChar <= '9')) && input.Key != ConsoleKey.Backspace)
                {
                    Console.Write("\b ");
                }
                if(((input.KeyChar >= 'a' && input.KeyChar <= 'z') || (input.KeyChar >= '0' && input.KeyChar <= '9')) && position == 1)
                {
                    lengthneptun++;
                    neptuncode += input.KeyChar;
                }
                if(input.Key == ConsoleKey.Backspace && lengthneptun > 0 && position == 1)
                {
                    neptuncode = neptuncode.Remove(neptuncode.Length-1);
                    lengthneptun--;
                    Console.Write(" ");
                }
                if (((input.KeyChar >= 'a' && input.KeyChar <= 'z') || (input.KeyChar >= '0' && input.KeyChar <= '9')) && position == 2)
                {
                    Console.Write("\b*");
                    lengthpassword++;
                    password += input.KeyChar;
                }
                if (input.Key == ConsoleKey.Backspace && lengthpassword > 0 && position == 2 )
                {
                    password = password.Remove(password.Length - 1);
                    lengthpassword--;
                    Console.Write(" ");
                }
                Console.SetCursorPosition(5, curpos + 1);
                Console.Write("                    ");
                if (input.Key == ConsoleKey.DownArrow)
                    position++;
                if (input.Key == ConsoleKey.UpArrow)
                    position--;
                if (position < 1)
                    position = 4;
                if (position > 4)
                    position = 1;
                curpos = 6 + 2 * position;
                if (position == 1)
                    Console.SetCursorPosition(20 + lengthneptun, curpos);
                if (position == 2)
                    Console.SetCursorPosition(20 + lengthpassword, curpos);
                if (position==3)
                {
                    Console.SetCursorPosition(5, curpos+1);
                    Console.Write("-------------");
                    Console.SetCursorPosition(20, curpos);
                }
                if(position==4)
                {
                    Console.SetCursorPosition(5, curpos + 1);
                    Console.Write("--------------------");
                    Console.SetCursorPosition(27, curpos);
                }

            } while (input.Key != ConsoleKey.Enter || position < 3);
            CMD command = new CMD();
            if (position == 3) command.cmd = "login";
            if (position == 4) command.cmd = "exit";
            command.data = new List<String>();
            command.data.Add(neptuncode);
            command.data.Add(password);
            Console.Clear();
            return command;
        }
        public void Sajt(String sajt1, String sajt2)
        {
            Console.WriteLine(sajt1);
            Console.WriteLine(sajt2);
        }
    }
}
