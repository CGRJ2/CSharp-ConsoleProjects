using System;
using System.Collections.Generic;

namespace miniGame_OOP_Project
{
    // 플레이어 객체
    // 플레이어 데이터
    // 플레이어 컨트롤


    // 플레이어 객체
    public class Player
    {
        public Position playerPos;
        private Position currentPos;
        //private nowMapData;

        private int dir_X;
        private int dir_Y;


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
            Console.SetCursorPosition(currentPos.x, currentPos.y);
            Console.Write(" ");
            currentPos = playerPos;
            switch (key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    if (GameManager.Instance.mapInstance.checkWays[playerPos.y, playerPos.x-1] == tileType.wall) return;
                        playerPos.x--;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    if (GameManager.Instance.mapInstance.checkWays[playerPos.y, playerPos.x+1] == tileType.wall) return;
                    playerPos.x++;
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (GameManager.Instance.mapInstance.checkWays[playerPos.y-1, playerPos.x] == tileType.wall) return;
                    playerPos.y--;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (GameManager.Instance.mapInstance.checkWays[playerPos.y+1, playerPos.x] == tileType.wall) return;
                    playerPos.y++;
                    break;
            }

            // 이동 완료 좌표가 포탈이라면
            if (GameManager.Instance.mapInstance.checkWays[playerPos.y, playerPos.x] == tileType.portal)
            {
                // 포탈 인터랙트 이벤트
                // 이벤트로 플레이어 좌표 넣기.
                int count = GameManager.Instance.mapInstance.portals.Count;
                for (int i = 0; i < count; i++)
                {
                    if (GameManager.Instance.mapInstance.portals[i].PortalPos.x == playerPos.x &&
                        GameManager.Instance.mapInstance.portals[i].PortalPos.y == playerPos.y)
                    {
                        GameManager.Instance.mapInstance.portals[i].Interact();
                    }
                }
            }
            
        }
        
        public void Print()
        {
            dir_X = playerPos.x - currentPos.x;
            dir_Y = playerPos.y - currentPos.y;
            Console.SetCursorPosition(currentPos.x, currentPos.y);
            Console.Write(" ");



            if (dir_X >= 1)
            {
                Console.SetCursorPosition(playerPos.x - 1, playerPos.y);
                Console.Write("=");
            }
            else if (dir_X <= -1)
            {
                Console.SetCursorPosition(playerPos.x + 1, playerPos.y);
                Console.Write("=");
            }
            else if (dir_Y >= 1)
            {
                Console.SetCursorPosition(playerPos.x, playerPos.y - 1);
                Console.Write("|");
            }
            else if (dir_Y <= -1)
            {
                Console.SetCursorPosition(playerPos.x, playerPos.y + 1);
                Console.Write("|");
            }

            Console.SetCursorPosition(playerPos.x, playerPos.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("P");
                
            Console.ResetColor();
        }
    }

}
