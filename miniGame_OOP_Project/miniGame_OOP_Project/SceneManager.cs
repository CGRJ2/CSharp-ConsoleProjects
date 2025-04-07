using System;
using System.Collections.Generic;

namespace miniGame_OOP_Project
{
    
    // 씬 구성
    // 1. 타이틀
    // 2. 인게임
    // 3. 이동씬
    // 4. 전투씬
    // 5. 퀘스트씬

    abstract class Scene
    {

        public Scene() { }

        public abstract void Print();
    }

    static class SceneManager
    {

        static Dictionary<string, Scene> sceneDatas = new Dictionary<string, Scene>()
        {
            // 이렇게 추가. 씬별로 Scene클래스의 자식으로 상속해 사용.
            { "TitleScene", new TitleScene()},

        };



        public static void LoadScene(string sceneKey)
        {
            Console.Clear();
            sceneDatas[sceneKey].Print();

            // 플레이어 위치
        }

    }
}
