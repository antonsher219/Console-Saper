using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Lab._1
{
    class Exit : Cell
    {
        public Exit(int y, int x)
        {
            X = x;
            Y = y;
            Flag = true;
        }

        protected internal override void Print()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(X, Y);
            Console.Write('$');
        }
    }
}
