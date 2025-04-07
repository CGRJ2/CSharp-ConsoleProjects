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
        private nowMapData;

        private string name_P;
        private int hp;
        private int mp;


        public void Move(ConsoleKey key)
        {
            int x = 0;
            int y = 0;
            switch (key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    //if (mapData.mapping[playerPos.y, playerPos.x - 1] == ' ')
                    //{
                        playerPos.x--;
                    //}
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
            playerPos = new Position(x, y);
        }

        public void RenderPlayer()
        {
            // 플레이어 위치에 플레이어 출력
        }

        public void PrintPlayerState()
        {

        }



    }


    class PlayerControll
    {

    }
}
