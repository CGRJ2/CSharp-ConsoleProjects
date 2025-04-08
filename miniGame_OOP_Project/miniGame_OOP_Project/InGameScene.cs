using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
    // 현재 맵 인스턴스 생성
    class InGameScene : Scene
    {
        Map nowMap;
        List<Portal> portals;
        //List<NPC>
        //List<Monster>

        // 맵별로 포털, npc, 몬스터 구성 정리
        public InGameScene(string mapName)
        {
            switch (mapName)
            {
                case "Village" :
                    nowMap = MapData.Instance.GetMap("Village");

                    break;
            }
        }

        public override void Print()
        {
            
        }
    }
}
