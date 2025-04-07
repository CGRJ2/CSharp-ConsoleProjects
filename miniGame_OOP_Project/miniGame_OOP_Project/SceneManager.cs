using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
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
