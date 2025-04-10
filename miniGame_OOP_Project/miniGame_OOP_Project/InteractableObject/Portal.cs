using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
    class Portal : InteractableObject
    {
        public Position PortalPos;
        Position outPos;
        string outMap;

        public Portal(Position portalPos, Position outPos, string outMap)
        {
            interactScript = $"이동 -> {outMap}";
            PortalPos = portalPos;
            this.outPos = outPos;
            this.outMap = outMap;
        }

        public void PrintPortal()
        {
            Console.SetCursorPosition(PortalPos.x, PortalPos.y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("@");
            Console.ResetColor();
        }

        // 포탈 상호작용 => 맵 이동
        public override void Interact()
        {
            // 인게임 씬 상에서 구현해야할거같은데..
            // 게임 매니저 의존도가 여기 생기면 안될거같음.
            // 일단 시간 없으니 이어서 진행하자.
            GameManager.Instance.mapInstance = new MapInstance(outMap);
            GameManager.Instance.player.playerPos = outPos;

        }
    }
}
