using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
    class Monster:InteractableObject
    {
        string name;
        int hp;
        int attack;

        public Monster(string name, int hp, int attack)
        {
            this.name = name;
            this.hp = hp;
            this.attack = attack;
        }

        public override void Interact(ref MapInstance mapInstance , ref Player player)
        {
            // 상호작용 하면
            // 플레이어 공격력 만큼 몬스터 체력 닳기
            // 몬스터 공격력 - 플레이어 방어력 만큼 플레이어 체력 닳기
            player.hp -= (attack - player.defence);
            this.hp -= player.attack;

            player.Interacted();
        }
    }


    public class MonsterDic
    {
        // 싱글톤 저장소
        private static MonsterDic instance;
        public static MonsterDic Instance { get { if (instance == null) instance = new MonsterDic(); return instance; } }

        Dictionary<string, Monster> monstetDatas = new Dictionary<string, Monster>()
        {
            {"슬라임", new Monster("슬라임", 10, 3) },
            {"고블린", new Monster("고블린", 30, 10) }
        };
    }
}
