using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
    // 맵을 담는 역할만 하자.
    public class Map
    {
        string name;
        string[,] tileMap;

        public Map(string name, string[,] tileMap)
        {
            this.name = name;
            this.tileMap = tileMap;
        }

        public void PrinfMap()
        {
            for (int y = 0; y < tileMap.GetLength(0); y++)
            {
                for (int x = 0; x < tileMap.GetLength(1); x++)
                {
                    Console.Write(tileMap[y, x]);
                }
            }
        }
    }

    public class MapData
    {
        // 싱글톤 저장소 (전역으로 하는게 나을라나?)
        private static MapData instance;
        public static MapData Instance { get { if (instance == null) instance = new MapData(); return instance; } }

        Dictionary<string, Map> tileMapDatas = new Dictionary<string, Map>();

        // 인스턴스 딱 하나 만들건데, 그때 타일 정보들 전부 저장해두기
        private MapData()
        {
            // 이름과 타일맵 정보 추가
            AddMap("test1", new string[10, 15]
            {
                //       0     1     2     3     4     5     6     7     8     9     10    11    12    13    14
                /*0*/ { "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■" },
                /*1*/ { "■", "  ", "  ", "  ", "  ",  "■", "  ",  "■", "  ", "  ", "  ", "  ",  "■",  "■",  "■" },
                /*2*/ { "■", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ",  "■",  "■" },
                /*3*/ { "■", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ",  "■",  "■",  "■" },
                /*4*/ { "■", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ",  "■",  "■",  "■" },
                /*5*/ { "■",  "■",  "■",  "■", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ",  "■" },
                /*6*/ { "■", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ",  "■",  "■",  "■" },
                /*7*/ { "■", "  ",  "■",  "■",  "■", "  ", "  ", "  ", "  ", "  ", "  ", "  ",  "■",  "■",  "■" },
                /*8*/ { "■", "  ",  "■",  "■",  "■", "  ", "  ", "  ", "  ", "  ", "  ", "  ",  "■",  "■",  "■" },
                /*9*/ { "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■" },
            });

            // 마을
            AddMap("Village", new string[10, 15]
            {
                //       0     1     2     3     4     5     6     7     8     9     10    11    12    13    14
                /*0*/ { "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■" },
                /*1*/ { "■", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ",  "■" },
                /*2*/ { "■", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ",  "■" },
                /*3*/ { "■", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ",  "■" },
                /*4*/ { "■", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ",  "■" },
                /*5*/ { "■", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ",  "■" },
                /*6*/ { "■", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ",  "■" },
                /*7*/ { "■", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ",  "■" },
                /*8*/ { "■", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ", "  ",  "■" },
                /*9*/ { "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■",  "■" },
            });
        }

        public void AddMap(string name, string[,] tileMap)
        {
            tileMapDatas[name] = new Map(name, tileMap);
        }

        // Map을 반환하는 함수
        public Map GetMap(string name)
        {
            return tileMapDatas[name];
        }
    }
}
