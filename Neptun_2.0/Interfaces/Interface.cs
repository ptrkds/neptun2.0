using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptun_2._0
{
    class Interface
    {
        protected int position = 1;
        protected int cursorpos = 0;
        protected String logOut = "Kijelentkezés";
        protected ConsoleKeyInfo input;
        protected String back = "Visszalépés";
        protected String yes = "Igen";
        protected String no = "Nem";
        protected String application = "Felvitel";
        protected void subMainUnderline(int max, int offset)
        {
            Console.Write("\b\b\b   ");
            if (position == 1)
            {
                for (int i = 0; i < back.Length; i++)
                {
                    Console.SetCursorPosition(5 + i, 9 + offset);
                    Console.Write("-");
                }
                Console.SetCursorPosition(8 + back.Length, 8 + offset);
            }
            else
            {
                if (position == 2 || position == max + 1)
                {
                    for (int i = 0; i < back.Length; i++)
                    {
                        Console.SetCursorPosition(5 + i, 9 + offset);
                        Console.Write(" ");
                    }
                }
                Console.SetCursorPosition(2, 10 + position - 2 + offset);
                Console.Write("->");
            }            
        }

        protected void subMenuremove(int where, int length)
        {
            for (int i = where; i < where + length; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.SetCursorPosition(j * 4, i);
                    Console.Write("    ");
                }
            }
        }

        protected void subAreYouSure()
        {
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
                    Console.SetCursorPosition(13 + no.Length, 8);
                    break;
            }
        }

    }
    
}
