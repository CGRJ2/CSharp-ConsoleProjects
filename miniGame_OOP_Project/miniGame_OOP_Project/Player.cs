using System;

namespace miniGame_OOP_Project
{
    // 플레이어 객체

    // 플레이어 클래스는 게임매니저 클래스에 의존도가 높음... 해결방안 필요.
    public class Player
    {
        GameManager gm = GameManager.Instance;

        public Position playerPos;
        private Position currentPos;
        private Position effectPos;
        private Position dir;
        //private nowMapData;

        // 상호작용 이벤트 -> ui 갱신용
        public event Action Interact_Event;
        public InteractableObject interactable { get; private set; }

        public string name_P { get; set; }
        
        public int hp = 100;
        public int mp = 100;
        public int attack = 1;
        public int defence = 1;


        public Player(Position playerPos, string name_P)
        {
            this.playerPos = playerPos;
            this.currentPos = playerPos;
            this.effectPos = playerPos;
            this.name_P = name_P;
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
                    if (gm.mapInstance.checkWays[playerPos.y, playerPos.x - 1].type == EnumTileTypes.empty) 
                        playerPos.x--;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    dir = new Position(1, 0);
                    if (gm.mapInstance.checkWays[playerPos.y, playerPos.x + 1].type == EnumTileTypes.empty) 
                        playerPos.x++; 
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    dir = new Position(0, -1);
                    if (gm.mapInstance.checkWays[playerPos.y - 1, playerPos.x].type == EnumTileTypes.empty)
                        playerPos.y--;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    dir = new Position(0, 1);
                    if (gm.mapInstance.checkWays[playerPos.y + 1, playerPos.x].type == EnumTileTypes.empty)
                        playerPos.y++;
                    break;
                default:
                    break;
            }

            if (gm.mapInstance.checkWays[playerPos.y + dir.y, playerPos.x + dir.x].type == EnumTileTypes.empty) 
            {
                this.interactable = null;
                return;
            }
            this.interactable = gm.mapInstance.checkWays[playerPos.y + dir.y, playerPos.x + dir.x].interactable;
            // 인터렉터블 만남 
        }

        public void UsePortal(string mapName, Position outPos)
        {
            playerPos.x = outPos.x;
            playerPos.y = outPos.y;
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

        

        // UI 갱신용
        public void Interacted()
        {
            if (Interact_Event != null)
            {
                Interact_Event();
            }
        }
    }

}
