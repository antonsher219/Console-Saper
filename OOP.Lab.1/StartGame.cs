using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Lab._1
{
    class StartGame
    {
        static int height = 0;
        static int width = 0;
        static int mines = 0;
        static int jumps = 0;
        static int range = 1;
        static Player player;
        public static void Start()
        {
            FieldSize();
            LevelDifficult();
            Console.Clear();
            player = new Player(1, 1);
            GameField game = new GameField(height, width);
            game.Walls();
            game.Generate(mines);
            game.Draw();
            player.Print();
            Console.CursorLeft = 12;
            Console.CursorTop = game.Height;
            Console.Write(jumps);
            while (Check(game))
            {
                Console.CursorVisible = false;
                Console.CursorLeft = player.X;
                Console.CursorTop = player.Y;
                ConsoleKeyInfo press = Console.ReadKey();
                player.Move(press, ref range, ref jumps);
                if(press.Key == ConsoleKey.Spacebar)
                {
                    Console.CursorLeft = 12;
                    Console.CursorTop = game.Height;
                    Console.Write(jumps);
                }
            }
            Restart();
        }

        private static bool Check(GameField game)
        {
            bool check = true;
            if (GameField.field[player.Y, player.X].GetType() == typeof(Exit))
            {
                game.MinesDraw();
                Console.SetCursorPosition(0, game.Height);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You Win!       ");
                check = false;
            }
            if (GameField.field[player.Y, player.X].GetType() == typeof(Mine))
            {
                game.MinesDraw();
                Console.SetCursorPosition(0, game.Height);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You Lose!      ");
                check = false;
            }
            return check;
        }
        private static void FieldSize()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Select game field size: 1 - Small, 2 - Medium, 3 - Large");
            string lvlSize = Console.ReadLine();
            while (lvlSize != "1" && lvlSize != "2" && lvlSize != "3")
            {
                Console.WriteLine("Please, select game field size: 1 - Small, 2 - Medium, 3 - Large");
                lvlSize = Console.ReadLine();
            }
            switch (lvlSize)
            {
                case "1":
                    height = 10;
                    width = 20;
                    break;
                case "2":
                    height = 20;
                    width = 55;
                    break;
                case "3":
                    height = 40;
                    width = 100;
                    break;
            }
        }
        
        private static void LevelDifficult()
        {
            Console.WriteLine("Select difficulty: 1 - Easy, 2 - Medium, 3 - Hard");
            string difLvl = Console.ReadLine();
            while (difLvl != "1" && difLvl != "2" && difLvl != "3")
            {
                Console.WriteLine("Please, select difficulty: 1 - Small, 2 - Medium, 3 - Large");
                difLvl = Console.ReadLine();
            }
            switch (difLvl)
            {
                case "1":
                    mines = (height - 2) * (width - 2) * 10 / 100;
                    jumps = 5;
                    break;
                case "2":
                    mines = (height - 2) * (width - 2) * 20 / 100;
                    jumps = 15;
                    break;
                case "3":
                    mines = (height - 2) * (width - 2) * 30 / 100;
                    jumps = 25;
                    break;
            }
            Console.Clear();
        }
        private static void Restart()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Again? (Yes/No)");
            string answ = Console.ReadLine();
            while (answ != "Yes" && answ != "No")
            {
                Console.WriteLine("Answer must be \"Yes\" or \"No\" ");
                answ = Console.ReadLine();
            }
            switch (answ)
            {
                case "Yes":
                    Console.Clear();
                    Start();
                    break;
                case "No":
                    Console.Clear();
                    break;
            }
        }
    }
}
