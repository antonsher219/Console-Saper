using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Lab._1
{
    abstract class Cell
    {
        public int Y { protected set; get; }

        public int X { protected set; get; }

        public bool Flag { set; get; }

        protected internal abstract void Print();
    }
}
