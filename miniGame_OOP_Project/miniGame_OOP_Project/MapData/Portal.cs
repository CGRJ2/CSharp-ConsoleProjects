using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
    class Portal : IInteractable
    {
        public Position PortalPos;
        Position outPos;
        string outMap;

        public Portal(Position portalPos, Position outPos, string outMap)
        {
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
        public void Interact()
        {
            GameManager.Instance.mapInstance = new MapInstance(outMap);
            GameManager.Instance.player.playerPos = outPos;
        }
    }
}
