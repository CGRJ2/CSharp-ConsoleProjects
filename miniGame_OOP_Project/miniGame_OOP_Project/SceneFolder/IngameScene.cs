using System;

namespace miniGame_OOP_Project
{
    // 인게임 씬.
    // 플레이 방법, 단축키
    // 현재 맵, 플레이어 정보 출력

    class IngameScene : Scene
    {
        // 그냥 할거.
        // 플레이어 이동
        // 몬스터 이동
        // npc 상호작용
        // 공격  효과
        // 공격 중인 몬스터 체력
        // 아이템 드랍
        // 인벤토리

        // 여기에 플레이어, 맵인스턴스 넣자
        bool inventoryToggle = false;

        public override void Awake()
        {
            GameManager.Instance.Interact_Event += PrintUI;

            Print();
            // 인게임씬 다시 돌아올 때, 기존 인스턴스맵 다시 출력
            GameManager.Instance.mapInstance.Print();
            PrintUI();
        }

        public override void Input()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                GameManager.Instance.player.Move(key); // 방향키라면 이동하고

                // 인벤토리 키 : I
                if (key == ConsoleKey.I && !inventoryToggle)
                {
                    // 인벤토리 열기
                    inventoryToggle = true;
                }
                else if (key == ConsoleKey.I && inventoryToggle && key == ConsoleKey.Escape)
                {
                    // 인벤토리 닫기
                    inventoryToggle = false;
                }

                // 상호작용 키 : G
                else if (GameManager.Instance.player.interactable != null &&
                         key == ConsoleKey.G)
                {
                    GameManager.Instance.player.interactable.Interact();
                    // 플레이어 출력 1회 갱신.
                    GameManager.Instance.player.Move(key);
                }


            }
        }

        public override void Print()
        {
            // 플레이어 이동 출력
            GameManager.Instance.player.Print();
            // npc 움직임 출력
            // 몬스터 움직임 출력
        }

        // 기본출력 후 반복하는 것들
        public override void Update()
        {
            PrintInteractState();
            Input(); // 플레이어 움직임 
            Print();
        }

        // 시작할 때 출력 & 상호작용할 때마다 갱신. 업데이트x
        public void PrintUI()
        {
            PrintPlayerInfo();
            PrintKeyInfo();
            PrintInteractState();
        }


        public void PrintPlayerInfo()
        {
            int uiStartX = 32;
            int uiStartY = 1;
            Player player = GameManager.Instance.player;

            // 맵이 가로 30칸이 넘지 않게.
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write("┌──────────────┐");
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write("│ Player State │");
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write("│ -------------│");
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write($"│ Name: {player.name_P,-7}│");
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write($"│ HP:   {player.hp,-7}│");
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write($"│ MP:   {player.mp,-7}│");
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write("└──────────────┘");
            Console.SetCursorPosition(uiStartX, uiStartY++);

            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write("┌──────────────┐");
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write("│ Interactable:│");
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write("│              │");
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write("└──────────────┘");
        }

        public void PrintInteractState()
        {
            Player player = GameManager.Instance.player;
            int uiStartX = 32;
            int uiStartY = 11;

            Console.SetCursorPosition(uiStartX + 2, uiStartY++);

            if (player.interactable != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{player.interactable.interactScript,-1}");
                Console.ResetColor();
            }
            else
            {
                Console.Write("                 ");
            }
        }

        public void PrintKeyInfo()
        {
            int uiStartX = 52;
            int uiStartY = 1;
            Player player = GameManager.Instance.player;

            // 맵이 가로 30칸이 넘지 않게.
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write("┌──────────────┐");
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write("│ Interact : G │");
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write("│ Inventory: I │");
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write("│ Move :   ▲  │");
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write("│        ◀▼▶│");
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write("└──────────────┘");
        }

    }
}
