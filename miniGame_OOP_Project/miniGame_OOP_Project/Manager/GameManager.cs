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
        
        // 초기 플레이어 위치
        public Player player = new Player(new Position(6,2), "기본이름", 100, 100);
        public MapInstance mapInstance;
        
        


        public void Awake()
        {
            // 초기 설정
            Console.CursorVisible = false;
            SceneManager.Instance.LoadScene("TitleScene");
            mapInstance = new MapInstance("Village");
        }

        public void Update()
        {
            //Rendering();
            
            // 이게 순서 맞음 출력-입력-이동->다시출력
            player.Print();
            ConsoleKey key = Console.ReadKey(true).Key;
            player.Move(key);
        }

        // 계속 움직이는거 출력용. 기존 커서 지우고 새 커서 작성
        public void Rendering()
        {

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
