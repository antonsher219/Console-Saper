using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Lab._1
{
    class Wall : Cell
    {
        public Wall(int y, int x)
        {
            X = x;
            Y = y;
            Flag = true;
        }

        protected internal override void Print()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(X, Y);
            Console.Write("#");
        }
    }
}
