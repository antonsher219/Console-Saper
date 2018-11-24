using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Lab._1
{
    class FreeCell : Cell
    {
        public FreeCell(int y, int x)
        {
            X = x;
            Y = y;
            Flag = false;
        }

        protected internal override void Print()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }
    }
}
