using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public bool isOnGame;
        
        // 초기 플레이어 위치
        public Position startPos;

        public Player player;

        public MapInstance mapInstance;

        

        public void Awake()
        {
            // 초기 설정
            isOnGame = true;
            startPos = new Position(13, 3);                         // 시작 플레이어 위치
            player = new Player(startPos, "steve");       // 이름설정 추가하자

            SceneManager.Instance.LoadScene("TitleScene");
            // 씬변경 후 다시 인게임씬으로 돌아올 때. 게임매니저에 저장된 맵 인스턴스 다시 받아서 출력

        }

        public void Start()
        {

        }

        public void Update() // 프레임마다 반복
        {
            SceneManager.Instance.nowScene.Update();
        }


    }
}
