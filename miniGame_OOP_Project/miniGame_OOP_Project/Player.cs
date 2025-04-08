using System;

namespace miniGame_OOP_Project
{
    // 플레이어 객체
    // 플레이어 데이터
    // 플레이어 컨트롤


    // 플레이어 객체
    public class Player
    {
        private Position playerPos;
        //private nowMapData;

        private string name_P;
        private int hp;
        private int mp;

        public Player(Position playerPos, string name_P, int hp, int mp)
        {
            this.playerPos = playerPos;
            this.name_P = name_P;
            this.hp = hp;
            this.mp = mp;
        }

        // 이동과 출력을 동시에
        public void Move(ConsoleKey key)
        {
            Console.SetCursorPosition(playerPos.x, playerPos.y);
            Console.Write(" ");
            switch (key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                        playerPos.x--;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    //if (mapData.mapping[playerPos.y, playerPos.x + 1] == ' ')
                    //{
                        playerPos.x++;
                    //}
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    //if (mapData.mapping[playerPos.y - 1, playerPos.x] == ' ')
                    //{
                        playerPos.y--;
                    //}
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    //if (mapData.mapping[playerPos.y + 1, playerPos.x] == ' ')
                    //{
                        playerPos.y++;
                    //}
                    break;
            }
            Console.SetCursorPosition(playerPos.x, playerPos.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("P");
            Console.ResetColor();
        }

        

        public void PrintPlayerState()
        {

        }



    }


    class PlayerControll
    {

    }
}
