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

        public override void Awake()
        {
            GameManager.Instance.mapInstance = new MapInstance("Village");
            Print();
        }

        public override void Input()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                GameManager.Instance.player.Move(key);
            }
        }

        public override void Print()
        {
            GameManager.Instance.player.Print(); // 움직인 후 플레이어 출력
        }

        // 기본출력 후 반복하는 것들
        public override void Update()
        {
            Input(); // 플레이어 움직임
            Print();
        }
    }
}
