using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
    // 현재 맵 인스턴스 생성
    class MapInstance
    {
        public MapData nowMap;
        public List<Portal> portals = new List<Portal>();
        public bool[,] checkWays;

        // 이름으로 맵 인스턴스 만들어주기.
        // 맵별로 포털, npc, 몬스터 구성 정리
        public MapInstance(string mapName)
        {
            switch (mapName)
            {
                case "Village" :
                    nowMap = MapDic.Instance.GetMap("Village");
                    portals.Add(new Portal(new Position(3, 4), new Position(2, 2), "Field"));
                    // 포탈 필요하면 더 추가
                    // npc 추가
                    // monster 추가
                    break;
                case "Field":
                    nowMap = MapDic.Instance.GetMap("Field");
                    portals.Add(new Portal(new Position(2, 2), new Position(3, 4), "Village"));
                    break;
            }

            checkWays = CheckWays_Fixed();
        }

        // 맵 안에서 이동 불가능 영역 체크 
        public bool[,] CheckWays_Fixed()
        {
            bool[,] ways = new bool[nowMap.tileMap.GetLength(0), nowMap.tileMap.GetLength(1)];

            for (int y = 0; y < nowMap.tileMap.GetLength(0); y++)
            {
                for (int x = 0; x < nowMap.tileMap.GetLength(1); x++)
                {
                    if (nowMap.tileMap[y, x] == " ") ways[y, x] = true;
                    else ways[y, x] = false;
                }
            }

            // npc 위치는 false
            // monster 위치는 false

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
            for (int i = 0; i < portals.Count; i++)
            {
                portals[i].PrintPortal();
            }
        }
    }
}
