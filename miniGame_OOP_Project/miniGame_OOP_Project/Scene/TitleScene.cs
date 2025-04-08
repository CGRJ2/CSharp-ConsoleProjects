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


        public override void Print()
        {
            Console.Clear();
            Console.WriteLine("****************************************************************");
            Console.WriteLine("********************** Console RPG Game ************************");
            Console.WriteLine("**********************    제목 미정      ************************");
            Console.WriteLine("****************************************************************");
            Console.WriteLine();
            Console.WriteLine("1. 새로운 시작");
            Console.WriteLine("2. 불러오기");
            Console.WriteLine("3. 옵션");
            Console.WriteLine("4. 게임 종료");

            Input();
        }

        public void Input()
        {
            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.D1:
                    SceneManager.LoadScene("IngameScene");
                    break;
                case ConsoleKey.D4:
                    return;

            }
        }
    }
}
