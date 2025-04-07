using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
    // 플레이어 
    // 플레이어 데이터
    // 플레이어 컨트롤

    class Player
    {
        public Position nowPos;
        public Player(PlayerData data)
        {
            
        }
    }

    public class PlayerData
    {
        private static Position playerPos;

        public string name_P;
        public int hp;
        public int mp;
    }

    class PlayerControll
    {

    }
}
