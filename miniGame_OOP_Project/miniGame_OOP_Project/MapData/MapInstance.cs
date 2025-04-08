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
        public List<Portal> portals;

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
