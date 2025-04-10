using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
    public class Monster:InteractableObject
    {
        string name;
        int hp;
        int attack;
        public Position monsterPos;

        // 데이터 추가용 // 몬스터 생성은 MonsterDic에서
        public Monster(string name, int hp, int attack)
        {
            interactScript = $"공격(G): {name}";
            this.name = name;
            this.hp = hp;
            this.attack = attack;
        }

        public Monster Clone()
        {
            return new Monster(this.name, this.hp, this.attack);
        }

        public override void Interact(ref MapInstance mapInstance , ref Player player)
        {
            // 상호작용 하면
            // 플레이어 공격력 만큼 몬스터 체력 닳기
            // 몬스터 공격력 - 플레이어 방어력 만큼 플레이어 체력 닳기
            player.hp -= (attack - player.defence);
            this.hp -= player.attack;

            if (this.hp <= 0)
            {
                mapInstance.checkWays[monsterPos.y, monsterPos.x].type = EnumTileTypes.empty;
                mapInstance.checkWays[monsterPos.y, monsterPos.x].interactable = null;

                Erase();
            }

            player.Interacted();
        }

        public void Erase()
        {
            Console.SetCursorPosition(monsterPos.x, monsterPos.y);
            Console.Write(" ");
        }

        public void PrintMonster()
        {
            Console.SetCursorPosition(monsterPos.x, monsterPos.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("M");
            Console.ResetColor();
        }


    }




    public class MonsterDic
    {
        // 싱글톤 저장소
        private static MonsterDic instance;
        public static MonsterDic Instance { get { if (instance == null) instance = new MonsterDic(); return instance; } }

        public Dictionary<string, Monster> monstetDatas = new Dictionary<string, Monster>()
        {
            {"슬라임", new Monster("슬라임", 10, 3) },
            {"고블린", new Monster("고블린", 30, 10) }
        };

        // 몬스터 생성용
        public Monster SpawnMonster(string name, Position position)
        {
            // 참조복사가 되는데?
            Monster monsterOrigin = monstetDatas[name];

            Monster monster = monsterOrigin.Clone();
            monster.monsterPos = position;
            return monster;
        }
    }
}
