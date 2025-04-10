using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
    class TitleScene : Scene
    {
        public TitleScene()
        {
            
        }
        public override void Awake()
        {
            Print();
            Input();
        }

        public override void Print()
        {
            Console.Clear();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine("************************** Console Project *******************************");
            Console.WriteLine("**************************    Static Rpg   *******************************");
            Console.WriteLine("*** 타임라인 구현할 시간이 없어서 주인공 빼고 모두 움직일 수 없는 세계 ***");
            Console.WriteLine("**************************************************************************");
            Console.WriteLine();
            Console.WriteLine("1. 새로운 시작");
            Console.WriteLine("2. 불러오기(미구현)");
            Console.WriteLine("3. 옵션(미구현)");
            Console.WriteLine("4. 게임 종료");

        }

        public override void Input()
        {
            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.D1:
                    GameManager.Instance.mapInstance = new MapInstance("Village");
                    SceneManager.Instance.LoadScene("IngameScene");
                    break;
                case ConsoleKey.D4:
                    GameManager.Instance.isOnGame = false;
                    break;
                default:
                    Console.WriteLine("제대로된 값을 입력하세요...");
                    Input();
                    break;
            }
        }

        public override void Update()
        {
            
        }

        
    }
}
