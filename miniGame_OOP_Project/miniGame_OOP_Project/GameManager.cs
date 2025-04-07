using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
    // 싱글톤 패턴
    class GameManager
    {
        static GameManager instance;
        public static GameManager Instance { get { if (instance == null) instance = new GameManager(); return instance; } }

        public static void Awake()
        {

        }

        public void Update()
        {
            ConsoleKey key = Console.ReadKey(true).Key;

            Thread.Sleep(200);   // 프레임 간격 (0.2초마다 갱신)
        }

    }

    public struct Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

}
