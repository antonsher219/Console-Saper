using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Lab._1
{
    class GameField
    {
        protected internal static Cell[,] field;
        protected internal int Width { get; }
        protected internal int Height { get; }

        public GameField(int rows, int columns)
        {
            if (rows < 4)
                rows = 4;
            if (columns < 4)
                columns = 4;
            field = new Cell[rows, columns];
            Height = rows;
            Width = columns;
        }

        public Cell this[int row, int column]
        {
            get { return field[row, column]; }
            set { field[row, column] = value; }
        }

        protected internal void Walls()
        {
            for (int y = 0, x = 0; y < Height || x < Width;)
            {
                if (x < Width)
                {
                    this[0, x] = new Wall(0, x);
                    this[Height - 1, x] = new Wall(Height - 1, x);
                    x++;
                }
                if (y < Height)
                {
                    this[y, 0] = new Wall(y, 0);
                    this[y, Width - 1] = new Wall(y, Width - 1);
                    y++;
                }
            }
        }

        protected internal void Generate(int minesCount)
        {
            Random random = new Random();
            int i = 1;
            while (i <= minesCount)
            {
                int x = random.Next(1, Width - 1);
                int y = random.Next(1, Height - 1);
                if (this[y, x] == null && (y != 1 || x != 1) && (y != Height - 2 || x != Width - 2))
                {
                    field[y, x] = new Mine(y, x);
                    ++i;
                }
            }
        }

        protected internal void Draw()
        {
            this[Height - 2, Width - 2] = new Exit(Height - 2, Width - 2);
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (this[y, x] == null)
                    {
                        this[y, x] = new FreeCell(y, x);
                    }
                    else if (this[y, x].GetType() != typeof(Mine))
                    {
                        this[y, x].Print();
                    }
                }
                Console.WriteLine();
            }
            Console.CursorLeft = 0;
            Console.CursorTop = Height;
            Console.Write("Jumps left: ");
        }

        protected internal void MinesDraw()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    if (this[y, x].GetType() == typeof(Mine))
                    {
                        this[y, x].Print();
                    }
                }
            }
        }
    }
}
