using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OOP.Lab._1
{
    class Player : Cell
    {
        private int Item { set; get; }

        internal Player(int y, int x, int item = 0)
        {
            X = x;
            Y = y;
            Item = item;
        }

        protected internal override void Print()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Item = 0;
            if (GameField.field[Y - 1, X].GetType() == typeof(Mine))
            {
                Item = Item + 1;
            }
            if (GameField.field[Y + 1, X].GetType() == typeof(Mine))
            {
                Item = Item + 1;
            }
            if (GameField.field[Y, X - 1].GetType() == typeof(Mine))
            {
                Item = Item + 1;
            }
            if (GameField.field[Y, X + 1].GetType() == typeof(Mine))
            {
                Item = Item + 1;
            }
            Console.SetCursorPosition(X, Y);
            Console.Write(Item);
        }

        internal void Move(ConsoleKeyInfo press, ref int range, ref int jumps)
        {
            switch (press.Key)
            {
                case ConsoleKey.UpArrow:
                    Up(ref range);
                    break;
                case ConsoleKey.DownArrow:
                    Down(ref range);
                    break;
                case ConsoleKey.LeftArrow:
                    Left(ref range);
                    break;
                case ConsoleKey.RightArrow:
                    Right(ref range);
                    break;
                case ConsoleKey.Spacebar:
                    Jump(ref range, ref jumps);
                    break;
                case ConsoleKey.Enter:
                    FlagMode();
                    break;
            }
            Print();
        }

        private void Up(ref int range)
        {
            if (GameField.field[Y - 1, X].GetType() != typeof(Wall))
            {
                if (GameField.field[Y - range, X].GetType() != typeof(Wall))
                {
                    VisitedCell visitedCell = new VisitedCell(Y, X);
                    GameField.field[Y, X] = visitedCell;
                    visitedCell.Print();
                    Y -= range;
                    range = 1;
                }
            }
        }

        private void Down(ref int range)
        {
            if (GameField.field[Y + 1, X].GetType() != typeof(Wall))
            {
                if (GameField.field[Y + range, X].GetType() != typeof(Wall))
                {
                    VisitedCell visitedCell = new VisitedCell(Y, X);
                    GameField.field[Y, X] = visitedCell;
                    visitedCell.Print();
                    Y += range;
                    range = 1;
                }
            }
        }

        private void Left(ref int range)
        {
            if (GameField.field[Y, X - 1].GetType() != typeof(Wall))
            {
                if (GameField.field[Y, X - range].GetType() != typeof(Wall))
                {
                    VisitedCell visitedCell = new VisitedCell(Y, X);
                    GameField.field[Y, X] = visitedCell;
                    visitedCell.Print();
                    X -= range;
                    range = 1;
                }
            }
        }

        private void Right(ref int range)
        {
            if (GameField.field[Y, X + 1].GetType() != typeof(Wall))
            {
                if (GameField.field[Y, X + range].GetType() != typeof(Wall))
                {
                    VisitedCell visitedCell = new VisitedCell(Y, X);
                    GameField.field[Y, X] = visitedCell;
                    visitedCell.Print();
                    X += range;
                    range = 1;
                }
            }
        }

        private static void Jump(ref int range, ref int jumps)
        {
            if (range == 2)
            {
                range = 1;
                jumps += 1;
            }
            else if (jumps > 0 && range != 2)
            {
                range = 2;
                jumps -= 1;
            }
        }

        private void FlagMode()
        {
            Console.SetCursorPosition(X, Y);
            ConsoleKeyInfo press = Console.ReadKey();
            switch(press.Key)
            {
                case ConsoleKey.UpArrow:
                    Y--; PutFlag(); Y++;
                    break;
                case ConsoleKey.DownArrow:
                    Y++; PutFlag(); Y--;
                    break;
                case ConsoleKey.LeftArrow:
                    X--; PutFlag(); X++;
                    break;
                case ConsoleKey.RightArrow:
                    X++; PutFlag(); X--;
                    break;
                case ConsoleKey.E:
                    Print();
                    break;
            }
            if (GameField.field[Y, X + 1].Flag == false && GameField.field[Y, X + 1].GetType() != typeof(Mine))
            {
                GameField.field[Y, X + 1].Print();
            }
            else
            {
                Console.CursorLeft = X + 1;
                Console.CursorTop = Y;
                Console.Write("M");
            }
        }

        private void PutFlag()
        {
            Console.CursorLeft = X;
            Console.CursorTop = Y;
            if (GameField.field[Y, X].GetType() != typeof(Wall)
            &&  GameField.field[Y, X].GetType() != typeof(Exit))
            {
                if (GameField.field[Y, X].Flag == false)
                {
                    Console.Write("M");
                    GameField.field[Y, X].Flag = true;
                }
                else if (GameField.field[Y, X].GetType() != typeof(Mine))
                {
                    GameField.field[Y, X].Print();
                    GameField.field[Y, X].Flag = false;
                }
                else
                {
                    Console.Write(" ");
                    GameField.field[Y, X].Flag = false;
                }
            }
        }

    }

}
