﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    
    class InterfaceLogin
    {
        public CMD Login(Boolean relogin=false)
        {
            //WriteMenu
            Console.Clear();
            Console.SetCursorPosition(10,4);
            Console.Write("Neptun 2.0 - Bejelentkezés:");
            Console.SetCursorPosition(10, 5);
            Console.Write("(a nyilakkal tud navigálni)");
            Console.SetCursorPosition(5, 8);
            Console.Write("Neptun kód:");
            Console.SetCursorPosition(5, 10);
            Console.Write("Jelszó:");
            Console.SetCursorPosition(5, 12);
            Console.Write("Belejentkezés");
            Console.SetCursorPosition(5, 14);
            Console.Write("Kilépés a programból");
            if (relogin)
            {
                Console.SetCursorPosition(5, 17);
                Console.Write("Hibás neptun kód vagy jelszó!");
            }

            //initial
            int curpos = 8;
            Console.SetCursorPosition(20, curpos);
            int position = 1;
            int lengthneptun = 0;
            int lengthpassword = 0;
            String neptuncode = "";
            String password = "";
            ConsoleKeyInfo input;

            //controll
            do
            {
                input = Console.ReadKey();
                //writing input
                if (position > 2)
                {
                    Console.Write("\b ");
                }
                if (!((input.KeyChar >= 'a' && input.KeyChar <= 'z') || (input.KeyChar >= 'A' && input.KeyChar <= 'Z') || (input.KeyChar >= '0' && input.KeyChar <= '9') || (input.Key == ConsoleKey.Spacebar)) && input.Key != ConsoleKey.Backspace)
                {
                    Console.Write("\b ");
                }
                if (((input.KeyChar >= 'a' && input.KeyChar <= 'z') || (input.KeyChar >= 'A' && input.KeyChar <= 'Z') || (input.KeyChar >= '0' && input.KeyChar <= '9') || (input.Key == ConsoleKey.Spacebar)) && position == 1)
                {
                    lengthneptun++;
                    neptuncode += input.KeyChar;
                }
                if (input.Key == ConsoleKey.Backspace && lengthneptun > 0 && position == 1)
                {
                    neptuncode = neptuncode.Remove(neptuncode.Length - 1);
                    lengthneptun--;
                    Console.Write(" ");
                }
                if (((input.KeyChar >= 'a' && input.KeyChar <= 'z') || (input.KeyChar >= 'A' && input.KeyChar <= 'Z') || (input.KeyChar >= '0' && input.KeyChar <= '9') || (input.Key == ConsoleKey.Spacebar)) && position == 2)
                {
                    Console.Write("\b*");
                    lengthpassword++;
                    password += input.KeyChar;
                }
                if (input.Key == ConsoleKey.Backspace && lengthpassword > 0 && position == 2)
                {
                    password = password.Remove(password.Length - 1);
                    lengthpassword--;
                    Console.Write(" ");
                }
                Console.SetCursorPosition(5, curpos + 1);
                Console.Write("                    ");

                //Action
                if (input.Key == ConsoleKey.DownArrow)
                    position++;
                if (input.Key == ConsoleKey.UpArrow)
                    position--;
                if (input.Key == ConsoleKey.Tab && position == 1)                
                    position++;                
                if (position < 1)
                    position = 4;
                if (position > 4)
                    position = 1;

                //Cursor position
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

            //return
            CMD command = new CMD();
            if (position == 3) command.cmd = "login";
            if (position == 4) command.cmd = "exit";
            command.data = new List<String>();
            command.data.Add(neptuncode.ToUpper());
            command.data.Add(password);
            Console.Clear();
            return command;
        }        
      
    }
}
