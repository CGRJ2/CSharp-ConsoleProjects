using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
    class Program
    {
        // 0. 기본 프레임워크
        // 4방향 이동 타일 RPG
        // 10프레임 마다 움직임 구현
        // 플레이어가 바라보고 있는 방향에 무기를 겨누고 있도록 구현

        // 1. 플레이어 구현
        // 플레이어 기본 데이터, 클래스 정리
        // 플레이어 위치
        // 플레이어 상호작용.
        // 플레이어 이동



        // 2. 맵 구현
        // 맵 이동 구현
        // 맵 저장소 구현    ///<-----------여기까지 완료



        // 3. 몬스터 구현
        // 몬스터 데이터 (딕셔너리? 탐색이 빠르니까?)
        // 몬스터 스포너
        // a* 알고리즘 플레이어 쫓기

        // 4. 전투구현
        // 근접/원거리 공격 
        // 몬스터, 상호작용, 죽음 후 전리품 
        // 스킬 창. 스킬 구현

        // 아이템 구현
        // 인벤토리, 아이템 착용 칸


        // 5. npc 구현





        // 6. 퀘스트 & npc 대화구현 (자료구조)


        // 7. 세이브 로드 구현
        // 플레이어 현재 상태 ( 데이터 + 위치(맵+좌표) ) 저장 및 불러오기
        // 맵에 있는 몬스터 데이터? --> 이거 그냥 맵 처음 시작할 때, 기본 몬스터 배치로 떼우면 될듯? 메이플처럼
        
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            const int frameTimeMs = 16; // 약 60FPS

            GameManager.Instance.Awake();


            while (true)
            {
                long start = sw.ElapsedMilliseconds;

                GameManager.Instance.Update(); // 한 프레임 처리

                long elapsed = sw.ElapsedMilliseconds - start;
                if (elapsed < frameTimeMs) Thread.Sleep((int)(frameTimeMs - elapsed)); // 남은 시간만큼 딜레이
            }
        }
    }
}
