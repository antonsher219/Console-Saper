using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Lab._1
{
    class Mine : Cell
    {
        public Mine(int y, int x)
        {
            X = x;
            Y = y;
            Flag = false;
        }

        protected internal override void Print()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(X, Y);
            Console.Write('*');
        }
    }
}
