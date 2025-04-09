using System;
using System.Collections.Generic;

namespace miniGame_OOP_Project
{

    // 씬 구성
    // 1. 타이틀
    // 2. 인게임
    // 3. 대화씬

    // 씬별로 인풋과 UI를 다르게 구성해야할듯. 구조 수정하자.

    abstract class Scene
    {

        public Scene() { }

        public abstract void Awake();

        public abstract void Print();
        public abstract void Input();
        public abstract void Update();
    }

    // 이것도 싱글톤. 하나만 필요하니까.
    class SceneManager
    {
        public Scene nowScene;

        private static SceneManager instance;
        public static SceneManager Instance { get { if (instance == null) instance = new SceneManager(); return instance; } }

        Dictionary<string, Scene> sceneDatas = new Dictionary<string, Scene>()
        {
            // 이렇게 추가. 씬별로 Scene클래스의 자식으로 상속해 사용.
            { "TitleScene", new TitleScene()},
            { "IngameScene", new IngameScene()},
        };


        // 씬 전환 시 호출
        public void LoadScene(string sceneKey)
        {
            nowScene = sceneDatas[sceneKey];
            Console.Clear();

            nowScene.Awake();
        }

    }
}
