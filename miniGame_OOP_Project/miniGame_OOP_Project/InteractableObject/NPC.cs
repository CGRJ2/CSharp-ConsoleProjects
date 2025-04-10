using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
    public class NPC : InteractableObject
    {
        public string name { get; private set; }
        public Position npcPos;
        string[] scripts;
        int scriptIndex = 0;
        int uiPosX = 32;
        int uiPosY = 16;

        public NPC(string name, Position originPos)
        {
            interactScript = $"{name} (NPC)";
            this.name = name;
            this.npcPos = originPos;
            this.scripts = NPCScripts.Instance.npcScripts[name];
        }

        public override void Interact(ref MapInstance mapInstance, ref Player player)
        {
            ScriptPrint();
            player.Interacted();
        }

        public void ScriptPrint()
        {
            OpenScriptBox();

            Console.SetCursorPosition(uiPosX, uiPosY);
            Erase();
            Console.SetCursorPosition(uiPosX, uiPosY);
            Console.Write($"│ {name}: {scripts[scriptIndex]}");
            scriptIndex++;

            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.G)
            {
                if (scriptIndex < scripts.Length)
                {
                    ScriptPrint();
                }
                else 
                {
                    CloseScriptBox();
                } 
            }
            else
            {
                CloseScriptBox();
            }
        }

        public void OpenScriptBox()
        {
            Console.SetCursorPosition(uiPosX, uiPosY-1);
            Console.Write("┌ ^────────────────────────────────┐");
            Console.SetCursorPosition(uiPosX, uiPosY +1);
            Console.Write("└──────────────────────────────────┘");
        }

        public void CloseScriptBox()
        {
            Console.SetCursorPosition(uiPosX, uiPosY - 1);
            Erase();
            Console.SetCursorPosition(uiPosX, uiPosY);
            Erase();
            Console.SetCursorPosition(uiPosX, uiPosY + 1);
            Erase();
            scriptIndex = 0;
            return;
        }

        public void Erase()
        {
            Console.Write("                                              ");
        }


        public void PrintNPC()
        {
            Console.SetCursorPosition(npcPos.x, npcPos.y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("N");
            Console.ResetColor();
        }
    }


    public class NPCScripts
    {
        // 싱글톤 저장소 (전역으로 하는게 나을라나? npc는 거의 모든 지역에 있으니까)
        private static NPCScripts instance;
        public static NPCScripts Instance { get { if (instance == null) instance = new NPCScripts(); return instance; } }

        public Dictionary<string, string[]> npcScripts = new Dictionary<string, string[]>();

        // 인스턴스 딱 하나 만들건데, 그때 타일 정보들 전부 저장해두기
        private NPCScripts()
        {
            npcScripts.Add("촌장님", new string[] {"우리 마을에 어서오게", "흠흠"});
            npcScripts.Add("주부", new string[] {"안녕!", "마침 재료가 부족한데...", "혹시 도와줄 수 있겠니?"});
            npcScripts.Add("기사", new string[] {"...", "이 앞은 위험하다..."});
        }

    }
}
