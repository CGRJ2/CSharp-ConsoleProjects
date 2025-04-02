using System;

namespace Week4_Day2_OOP_Project_MudGame.Scenes
{
    public class Caves : Scene
    {
        int CaveLevel = 0;
        public override void Render()
        {
            Game.PrintInfo();
            if (CaveLevel == 0)
            {
                Util.Print("마을 근처 수풀가에 있는 동굴에 들어왔다.", ConsoleColor.White, 500);
                Util.Print("스산한 바람이 안에서 불어오고 있다.", ConsoleColor.White, 500);
            }
            else if (CaveLevel == 1)
            {
                Util.Print("당신의 눈앞에 두 갈래로 나눠진 굴이 나타났다.", ConsoleColor.White, 500);
                Util.Print("왼쪽 굴에서는 대화 소리가 들리고 있다.", ConsoleColor.White, 500);
                Util.Print("오른쪽 굴에는 저 멀리 작은 무언가가 희미한 빛을 내고 있다.", ConsoleColor.White, 500);
            }
            else if (CaveLevel == 2)
            {
                Util.Print("\"어제 습격은 꽤 짭잘했어. 보물은 잘 챙겨뒀지?\"", ConsoleColor.White, 500);
                Util.Print("\"어. 저기 옆 굴 안에 잘 모셔놨지.\"", ConsoleColor.White, 500);
                Util.Print("당신은 대화를 듣곤 이들이 도적들임을 눈치챘습니다.", ConsoleColor.White, 500);
            }

        }

        public override void Choice()
        {
            if (CaveLevel == 0)
            {
                Console.WriteLine("1. 더 깊숙히 들어간다.");
                Console.WriteLine("2. 무섭다. 그냥 필드로 돌아간다.");
            }
            else if (CaveLevel == 1)
            {
                Console.WriteLine("1. 왼쪽으로 간다.");
                Console.WriteLine("2. 오른쪽으로 간다.");
                Console.WriteLine("3. 지금이라도 돌아간다. <필드>");
                Console.WriteLine("4. 대화에 귀 기울여 본다.");

            }
            else if (CaveLevel == 2)
            {
                Console.WriteLine("1. 왼쪽으로 간다.");
                Console.WriteLine("2. 오른쪽으로 간다.");
                Console.WriteLine("3. 진짜 위험해 보인다. 지금이라도 돌아가자. <필드>");
            }
            
        }

        public override void Result()
        {
            if (CaveLevel == 2)
            {
                CaveLevel -= 1;
            }
                

            if (CaveLevel == 0)
            {
                switch (input)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("당신은 더 깊은 곳으로 향합니다...");
                        break;

                    case ConsoleKey.D2:
                        Console.WriteLine("필드로 나갑니다...");
                        break;
                    default:
                        Console.WriteLine("잘못 입력 하셨습니다. 다시 입력해주세요.");
                        break;
                }
            }
            else if (CaveLevel == 1)
            {
                switch (input)
                {
                    case ConsoleKey.D1:
                        Util.Print("당신은 왼쪽 굴로 걸어갔습니다.", ConsoleColor.White, 500);
                        Util.Print("소리의 근원지에 다다랐을 때 당신은 그것이 도적들의 대화임을 알아챘습니다.", ConsoleColor.White, 500);
                        Util.Print("도적 중 한명이 쇠뇌를 들어 당신을 겨냥했습니다.", ConsoleColor.Red, 500);
                        if (Game.Player.Speed >= 10)
                        {
                            Util.Print("당신은 재빠르게 쇠뇌살을 피했습니다.", ConsoleColor.Green, 500);
                            Util.Print("도적들을 당신을 쫓아 달렸지만, 가까스로 도망치는데에 성공했습니다.", ConsoleColor.Green, 500);
                        }
                        else
                        {
                            Util.Print("당신의 심장에 쇠뇌살이 날아와 박혔습니다!.", ConsoleColor.Red, 500);
                            Util.Print("온몸에 힘이 빠지며 서서히 눈이 감깁니다...", ConsoleColor.White, 500);
                        }

                        break;

                    case ConsoleKey.D2:
                        Util.Print("당신은 오른쪽 굴로 걸어갑니다.", ConsoleColor.White, 500);
                        Util.Print("희미한 빛은 생각보다 더 멀리에 있었습니다.", ConsoleColor.White, 500);
                        Util.Print("빛에 거의 다 도달할 때 즈음, 멀리서 보였던 빛은 보물상자임을 알게 되었습니다.", ConsoleColor.White, 500);

                        int gold = 30;
                        Game.Player.Money += gold;
                        Util.Print($"{gold} Gold 획득!", ConsoleColor.Green, 500);
                        Util.Print("당신은 골드를 챙겨 조용히 빠져나왔습니다.", ConsoleColor.White, 500);


                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine("필드로 나갑니다...");
                        break;

                    case ConsoleKey.D4:
                        Util.Print("당신은 대화소리에 귀를 기울입니다.", ConsoleColor.White, 500);
                        break;

                    default:
                        Console.WriteLine("잘못 입력 하셨습니다. 다시 입력해주세요.");
                        break;
                }
            }

        }

        public override void Wait()
        {
            Console.WriteLine("계속하려면 아무키나 눌러주세요...");
            Console.ReadKey();
        }

        public override void Next()
        {
            if (CaveLevel == 0)
            {
                switch (input)
                {
                    case ConsoleKey.D1:
                        CaveLevel += 1;
                        SceneManager.SceneLoad("Caves");

                        break;
                    case ConsoleKey.D2:
                        SceneManager.SceneLoad("Field");
                        break;
                }
            }

            else if (CaveLevel == 1)
            {
                switch (input)
                {
                    case ConsoleKey.D1:
                        if (Game.Player.Speed >= 10)
                        {
                            // 도망 성공
                            CaveLevel = 0;
                            Console.WriteLine("필드로 나갑니다...");
                            SceneManager.SceneLoad("Field");
                        }
                        else
                        {
                            Game.GameOver("신중한 선택이 필요합니다...");
                        }

                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.D3:
                        CaveLevel = 0;
                        Console.WriteLine("필드로 나갑니다...");
                        SceneManager.SceneLoad("Field");
                        break;

                    case ConsoleKey.D4:
                        
                        CaveLevel += 1;
                        SceneManager.SceneLoad("Caves");
                        break;
                }
            }
        }
    }
}
