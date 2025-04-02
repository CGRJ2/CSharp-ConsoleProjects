using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_Day2_OOP_Project_MudGame.Scenes
{

    // 씬매니저를 static으로 선언하여 객체 없이도 사용 가능하게 만듦
    public static class SceneManager
    {

        // 현재 씬 정보
        private static Scene nowScene;

        // 게임에 있는 모든 씬들을 보관하고 빠르게 찾아줄 용도로 쓸 자료구조
        private static Dictionary<string, Scene> sceneDic = new Dictionary<string, Scene>
        {
            {"Title", new TitleScene()},
            {"Town", new TownScene()},
            {"Shop", new ShopScene()},
            {"Field", new FieldScene()},
            {"Caves", new Caves()}

            //// 씬 추가할때마다 추가하기
        };

       
        
        // 씬 불러올 때 순차적으로 실행할 함수들.
        public static void SceneLoad(string sceneName)
        {
            nowScene = sceneDic[sceneName];
            Console.Clear();
            nowScene.Render();
            Console.WriteLine();
            nowScene.Choice();
            nowScene.Input();
            Console.WriteLine();
            nowScene.Result();
            Console.WriteLine();
            nowScene.Wait();
            nowScene.Next();
        }
    }

    // 씬 추상 클래스 (씬 기본 출력 시퀀스)
    public abstract class Scene
    {
        protected ConsoleKey input;

        public void Input()
        {
            input = Console.ReadKey(true).Key;
        }


        // 씬의 상황 설명을 작성
        public abstract void Render();

        // 씬의 선택지 목록을 작성
        public abstract void Choice();

        // 선택한 선택지를 기준으로 결과 출력
        public abstract void Result();

        // 결과를 본 후 기다리기 기능 구현
        public abstract void Wait();

        // 다음으로 넘어갈 씬 또는 게임오버를 구현
        public abstract void Next();
    }
}
