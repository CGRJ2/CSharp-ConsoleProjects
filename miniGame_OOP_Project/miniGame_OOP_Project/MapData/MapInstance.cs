using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
    public enum EnumTileTypes { portal, npc, monster, wall, empty }
    public class TileType
    {
        public EnumTileTypes type;
        public InteractableObject interactable { get; private set; }

        public TileType (EnumTileTypes type, InteractableObject interactable)
        {
            this.type = type;
            this.interactable = interactable;
        }
    }

    // 현재 맵 인스턴스 생성
    public class MapInstance
    {
        public MapData nowMap;
        public List<Portal> portals = new List<Portal>();
        public List<NPC> npcs = new List<NPC>();
        public TileType[,] checkWays; // 여기에 npc/몬스터 위치 갱신

        

        // 이름으로 맵 인스턴스 만들어주기.
        // 맵별로 포털, npc, 몬스터 구성 정리
        public MapInstance(string mapName)
        {
            switch (mapName)
            {
                case "Village" :
                    nowMap = MapDic.Instance.GetMap("Village");
                    portals.Add(new Portal(new Position(13, 2), new Position(1 +1, 2), "Field")); // 나올때 오른쪽으로 나옴 +1
                    // 포탈 필요하면 더 추가
                    npcs.Add(new NPC("촌장님", new Position(14,6)));
                    npcs.Add(new NPC("주부", new Position(19,10)));

                    // monster 추가
                    break;
                case "Field":
                    nowMap = MapDic.Instance.GetMap("Field");
                    portals.Add(new Portal(new Position(1, 2), new Position(13 -1, 2), "Village")); // 나올때 왼쪽으로 나옴 -1
                    npcs.Add(new NPC("기사", new Position(10, 6)));
                    break;
            }

            // 맵 인스턴스 만들 때 마다 콘솔 초기화 후 맵타일 출력. 맵요소 정보 새로 저장
            checkWays = CheckWays_Fixed();
            Print();
        }

        // 맵 인스턴스 생성 시 단 한번만 호출
        // 맵 안 요소 체크 // 1회성
        public TileType[,] CheckWays_Fixed()
        {
            TileType[,] ways = new TileType[nowMap.tileMap.GetLength(0), nowMap.tileMap.GetLength(1)];

            // 벽과 빈 공간
            for (int y = 0; y < nowMap.tileMap.GetLength(0); y++)
            {
                for (int x = 0; x < nowMap.tileMap.GetLength(1); x++)
                {
                    if (nowMap.tileMap[y, x] == " ") ways[y, x] = new TileType(EnumTileTypes.empty, null);
                    else ways[y, x] = new TileType(EnumTileTypes.wall, null);
                }
            }

            // 포탈 위치는 불변하니 여기서 한번만 출력되게. 여기 저장
            for (int i = 0; i < portals.Count; i++)
            {
                ways[portals[i].PortalPos.y, portals[i].PortalPos.x] = new TileType(EnumTileTypes.portal, portals[i]); // 포탈은 이동 가능
            }

            // npc
            for (int i = 0; i < npcs.Count; i++)
            {
                ways[npcs[i].npcPos.y, npcs[i].npcPos.x] = new TileType(EnumTileTypes.npc, npcs[i]); 
            }


            // monster 위치는 tileType.monster

            return ways;
        }

       



        public void Print()
        {
            Console.Clear();
            nowMap.PrintMap();

            for (int i = 0; i < portals.Count; i++)
            {
                portals[i].PrintPortal();
            }

            for (int i = 0; i < npcs.Count; i++)
            {
                npcs[i].PrintNPC();
            }
        }
    }
}
