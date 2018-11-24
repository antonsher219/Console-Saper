using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Lab._1
{
    class VisitedCell : Cell
    {
        public VisitedCell(int y, int x)
        {
            X = x;
            Y = y;
            Flag = false;
        }

        protected internal override void Print()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(X, Y);
            Console.Write('.');
        }
    }
}
