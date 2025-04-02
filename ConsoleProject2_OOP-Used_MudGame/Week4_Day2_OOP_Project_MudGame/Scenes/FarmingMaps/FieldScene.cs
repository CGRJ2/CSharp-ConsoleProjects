using System;

namespace Week4_Day2_OOP_Project_MudGame.Scenes
{
    public class FieldScene : Scene
    {
        public override void Render()
        {
            Game.PrintInfo();
            Util.Print("행선지를 선택하세요.", ConsoleColor.White, 500);
        }

        public override void Choice()
        {
            Console.WriteLine("1. 조용한 평원");
            Console.WriteLine("2. 동굴");
            Console.WriteLine("3. 높은 산");
        }

        public override void Result()
        {
            switch (input)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("<조용한 평원>으로 이동합니다...");
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("<동굴>으로 이동합니다...");
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("<높은 산>으로 이동합니다...");
                    break;
                default:
                    Console.WriteLine("잘못 입력 하셨습니다. 다시 입력해주세요.");
                    break;
            }
        }

        

        public override void Wait()
        {
            Console.WriteLine("계속하려면 아무키나 눌러주세요...");
            Console.ReadKey();
        }

        public override void Next()
        {
            switch (input)
            {
                case ConsoleKey.D1:
                    SceneManager.SceneLoad("조용한 평원");
                    break;
                case ConsoleKey.D2:
                    SceneManager.SceneLoad("Caves");
                    break;
                case ConsoleKey.D3:
                    SceneManager.SceneLoad("높은 산");
                    break;
            }
        }

    }
}
