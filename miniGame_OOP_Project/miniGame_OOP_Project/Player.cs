using System;

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
        private Position effectPos;
        private Position dir;
        //private nowMapData;




        public InteractableObject interactable { get; private set; }
        public string name_P { get; set; }
        public int hp { get; private set; }
        public int mp { get; private set; }


        public Player(Position playerPos, string name_P, int hp, int mp)
        {
            this.playerPos = playerPos;
            this.currentPos = playerPos;
            this.effectPos = playerPos;
            this.name_P = name_P;
            this.hp = hp;
            this.mp = mp;
        }

        // 벽에 닿으면 이동불가.
        public void Move(ConsoleKey key)
        {
            currentPos = playerPos;
            switch (key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    dir = new Position(-1, 0);
                    if (GameManager.Instance.mapInstance.checkWays[playerPos.y, playerPos.x - 1].type == EnumTileTypes.empty) 
                        playerPos.x--;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    dir = new Position(1, 0);
                    if (GameManager.Instance.mapInstance.checkWays[playerPos.y, playerPos.x + 1].type == EnumTileTypes.empty) 
                        playerPos.x++; 
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    dir = new Position(0, -1);
                    if (GameManager.Instance.mapInstance.checkWays[playerPos.y - 1, playerPos.x].type == EnumTileTypes.empty)
                        playerPos.y--;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    dir = new Position(0, 1);
                    if (GameManager.Instance.mapInstance.checkWays[playerPos.y + 1, playerPos.x].type == EnumTileTypes.empty)
                        playerPos.y++;
                    break;
                default:
                    break;
            }


            if (GameManager.Instance.mapInstance.checkWays[playerPos.y + dir.y, playerPos.x + dir.x].type == EnumTileTypes.empty) 
            {
                this.interactable = null;
                return;
            }
            this.interactable = GameManager.Instance.mapInstance.checkWays[playerPos.y + dir.y, playerPos.x + dir.x].interactable;
            // 인터렉터블 만남 이벤트



            /*// 이동 완료 좌표가 포탈이라면 -- 이거 삭제해. 포탈과 상호작용으로 넘어가는거로 바꿔
            if (GameManager.Instance.mapInstance.checkWays[playerPos.y, playerPos.x] == TileType.portal)
            {
                // 포탈 인터랙트 이벤트
                // 이벤트로 플레이어 좌표 넣기.
                int count = GameManager.Instance.mapInstance.portals.Count;
                for (int i = 0; i < count; i++)
                {
                    if (GameManager.Instance.mapInstance.portals[i].PortalPos.x == playerPos.x &&
                        GameManager.Instance.mapInstance.portals[i].PortalPos.y == playerPos.y)
                    {
                        // 여기를 바꿀까?
                        GameManager.Instance.mapInstance.portals[i].Interact();
                    }
                }
            }*/

        }


        public void PrintMoveEffect()
        {
            Console.SetCursorPosition(effectPos.x, effectPos.y);
            Console.Write(" ");

            // 이동하지 않았다면 => 이동 효과 안줌. + 지우기 필요할듯?
            if (currentPos.x == playerPos.x && currentPos.y == playerPos.y) return;
            
            if (dir.x == 1)
            {
                Console.SetCursorPosition(currentPos.x, currentPos.y);
                Console.Write("=");
            }
            else if (dir.x == -1)
            {
                Console.SetCursorPosition(currentPos.x, currentPos.y);
                Console.Write("=");
            }
            else if (dir.y == 1)
            {
                Console.SetCursorPosition(currentPos.x, currentPos.y);
                Console.Write("|");
            }
            else if (dir.y == -1)
            {
                Console.SetCursorPosition(currentPos.x, currentPos.y);
                Console.Write("|");
            }

            effectPos = currentPos;
        }

        public void Print()
        {
            Console.SetCursorPosition(currentPos.x, currentPos.y);
            Console.Write(" ");

            PrintMoveEffect();

            Console.SetCursorPosition(playerPos.x, playerPos.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("P");

            Console.ResetColor();
        }

        
    }

}
