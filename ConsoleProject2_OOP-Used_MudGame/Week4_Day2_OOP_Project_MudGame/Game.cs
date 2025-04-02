using System;
using System.Collections.Generic;
using Week4_Day2_OOP_Project_MudGame.Scenes;

namespace Week4_Day2_OOP_Project_MudGame
{
    public static class Game
    {
        // 게임에 필요한 정보들
        private static bool gameOver;

        private static Player player;
        public static Player Player { get { return player; } }

        // 게임에 필요한 기능들
        public static void Start()
        {
            player = new Player();
            player.Power = 10;
            player.Speed = 8;
        }

        public static void End()
        {

        }

        public static void Run()
        {
            while (gameOver == false)
            {
                SceneManager.SceneLoad("Title");
            }
        }


        public static void GameOver(string reason)
        {
            Console.Clear();
            Console.WriteLine("**********************************");
            Console.WriteLine("*          You Died...           *");
            Console.WriteLine("**********************************");
            Console.WriteLine();
            Console.WriteLine(reason);

            gameOver = true;
        }

        public static void PrintInfo()
        {
            Console.WriteLine("***************************************************");
            Console.WriteLine(" 플레이어");
            Console.WriteLine(" |힘: {0} |속도: {1} |소지금: {2} Gold", player.Power, player.Speed, player.Money);
            Console.WriteLine("***************************************************");
            Console.WriteLine("인벤토리-------------------------------------------");
            // 멤버변수 왜 접근 못하냐?
            Console.WriteLine(" |1. {0}      |2. {1}     |3. {2}     |4. {3}     |", player.inven.inventory[0], player.inven.inventory[1], player.inven.inventory[2], player.inven.inventory[3]);
            Console.WriteLine(" |5. {0}      |6. {1}     |7. {2}     |8. {3}     |", player.inven.inventory[4], player.inven.inventory[5], player.inven.inventory[6], player.inven.inventory[7]);
            Console.WriteLine(" *------------------------------------------------*");
            Console.WriteLine("***************************************************");
        }
    }
}
