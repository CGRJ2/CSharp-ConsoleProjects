using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
    enum tileType
    {
        wall, portal, npc, monster, empty
    }

    // 현재 맵 인스턴스 생성
    class MapInstance
    {
        public MapData nowMap;
        public List<Portal> portals = new List<Portal>();

        public tileType[,] checkWays;

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
                    // npc 추가
                    // monster 추가
                    break;
                case "Field":
                    nowMap = MapDic.Instance.GetMap("Field");
                    portals.Add(new Portal(new Position(1, 2), new Position(13 -1, 2), "Village")); // 나올때 왼쪽으로 나옴 -1
                    break;
            }

            // 맵 인스턴스 만들 때 마다 콘솔 초기화 후 맵타일 출력. 맵요소 정보 새로 저장
            checkWays = CheckWays_Fixed();
            Print();
        }

        // 맵 인스턴스 생성 시 단 한번만 호출
        // 맵 안 요소 체크 
        public tileType[,] CheckWays_Fixed()
        {
            tileType[,] ways = new tileType[nowMap.tileMap.GetLength(0), nowMap.tileMap.GetLength(1)];

            // 벽과 빈 공간
            for (int y = 0; y < nowMap.tileMap.GetLength(0); y++)
            {
                for (int x = 0; x < nowMap.tileMap.GetLength(1); x++)
                {
                    if (nowMap.tileMap[y, x] == " ") ways[y, x] = tileType.empty;
                    else ways[y, x] = tileType.wall;
                }
            }

            // 포탈 위치 
            for (int i = 0; i < portals.Count; i++)
            {
                ways[portals[i].PortalPos.y, portals[i].PortalPos.x] = tileType.portal;
            }

            // npc 위치는 tileType.wall

            // monster 위치는 tileType.monster

            return ways;
        }

        // 몬스터, npc 등 충돌 불가능 오브젝트 설정
        public bool[,] CheckWays_Updated(bool[,] fixedWays)
        {
            // npc 위치는 false 변경
            // monster 위치는 false 변경

            return fixedWays;
        }



        public void Print()
        {
            Console.Clear();
            nowMap.PrintMap();

            for (int i = 0; i < portals.Count; i++)
            {
                portals[i].PrintPortal();
            }
        }
    }
}
