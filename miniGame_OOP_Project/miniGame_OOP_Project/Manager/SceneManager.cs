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

    // 이것도 싱글톤. 하나만 필요하니까.
    class SceneManager
    {
        private static SceneManager instance;
        public static SceneManager Instance { get { if (instance == null) instance = new SceneManager(); return instance; } }

        Dictionary<string, Scene> sceneDatas = new Dictionary<string, Scene>()
        {
            // 이렇게 추가. 씬별로 Scene클래스의 자식으로 상속해 사용.
            { "TitleScene", new TitleScene()},
            { "IngameScene", new IngameScene()},
        };



        public void LoadScene(string sceneKey)
        {
            Console.Clear();
            sceneDatas[sceneKey].Print();
        }

    }
}
