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
        private Position currentPos;
        //private nowMapData;


        private string name_P;
        private int hp;
        private int mp;

        public Player(Position playerPos, string name_P, int hp, int mp)
        {
            this.playerPos = playerPos;
            this.currentPos = playerPos;
            this.name_P = name_P;
            this.hp = hp;
            this.mp = mp;
        }

        // 이동과 출력을 동시에
        // 벽에 닿으면 이동불가.
        public void Move(ConsoleKey key)
        {
            currentPos = playerPos;
            switch (key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (GameManager.Instance.mapInstance.checkWays[playerPos.y, playerPos.x-1] == false) return;
                        playerPos.x--;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (GameManager.Instance.mapInstance.checkWays[playerPos.y, playerPos.x+1] == false) return;
                    playerPos.x++;
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (GameManager.Instance.mapInstance.checkWays[playerPos.y-1, playerPos.x] == false) return;
                    playerPos.y--;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (GameManager.Instance.mapInstance.checkWays[playerPos.y+1, playerPos.x] == false) return;
                    playerPos.y++;
                    break;
            }
            
        }
        
        

        public void Print()
        {
            Console.SetCursorPosition(currentPos.x, currentPos.y);
            Console.Write(" ");
            Console.SetCursorPosition(playerPos.x, playerPos.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("P");
            Console.ResetColor();
        }



    }


    class PlayerControll
    {

    }
}
