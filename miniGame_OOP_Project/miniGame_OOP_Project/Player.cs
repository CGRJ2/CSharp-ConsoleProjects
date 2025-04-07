using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
    // 플레이어 객체
    // 플레이어 데이터
    // 플레이어 컨트롤


    // 플레이어 객체
    public class Player
    {
        private Position playerPos;

        private string name_P;
        private int hp;
        private int mp;


        public void Move(int x, int y)
        {
            playerPos = new Position(x, y);
        }

        public void PrintPlayerState()
        {

        }
         
    }


    class PlayerControll
    {

    }
}
