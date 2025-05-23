﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
    public class Portal : InteractableObject
    {
        public Position PortalPos;
        Position outPos;
        string outMap;

        public Portal(Position portalPos, Position outPos, string outMap)
        {
            interactScript = $"이동(G): {outMap}";
            type = ObjectType.Portal;
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
        public override void Interact(ref MapInstance mapInstance, ref Player player)
        {
            mapInstance = new MapInstance(outMap);
            player.playerPos = outPos;
            player.Interacted();
        }
    }
}
