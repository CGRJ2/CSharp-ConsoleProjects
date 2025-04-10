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

        int dropMoney;
        List<DropTable> dropTable;


        // 데이터 추가용 // 몬스터 생성은 MonsterDic에서
        public Monster(string name, int hp, int attack, int dropMoney)
        {
            interactScript = $"공격(G): {name}";
            type = ObjectType.Monster;
            this.name = name;
            this.hp = hp;
            this.attack = attack;
            this.dropMoney = dropMoney;
            this.dropTable = DropTableDataBase.Instance.monsterDropTable[name];
        }

        public Monster Clone()
        {
            return new Monster(this.name, this.hp, this.attack, this.dropMoney);
        }

        public override void Interact(ref MapInstance mapInstance , ref Player player)
        {
            // 상호작용 하면
            // 플레이어 공격력 만큼 몬스터 체력 닳기
            // 몬스터 공격력 - 플레이어 방어력 만큼 플레이어 체력 닳기
            ClearBattlePrint();
            player.hp -= (attack - player.defence);
            this.hp -= player.attack;
            BattlePrint(player);
            if (this.hp <= 0)
            {
                mapInstance.checkWays[monsterPos.y, monsterPos.x].type = EnumTileTypes.empty; 
                mapInstance.checkWays[monsterPos.y, monsterPos.x].interactable = null;
                ClearBattlePrint();
                Erase();

                player.money += dropMoney;
                int uiStartX = 52;
                int uiStartY = 10;
                Console.SetCursorPosition(uiStartX, uiStartY++);
                Console.Write($"{name}를 처치했다!");
                Console.SetCursorPosition(uiStartX, uiStartY++);
                Console.Write($"{dropMoney}Gold 획득!");
                for (int i = 0; i < dropTable.Count; i++)
                {
                    Random r = new Random();
                    if (r.NextDouble() < dropTable[i].dropProb)
                    {
                        player.inventory.Add(new Item(dropTable[i].item)); // 일단 그냥 리스트에 add 했는데 인벤토리에 추가하는 함수로 구현하자
                        Console.SetCursorPosition(uiStartX, uiStartY++);
                        Console.Write($"{dropTable[i].item.Name} 획득!");
                    }
                }
                


                //Dead();
            }

            player.Interacted();
        }
        public void BattlePrint(Player player)
        {
            int uiStartX = 52;
            int uiStartY = 10;
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write($"Target:{name}");
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write($"HP: {hp}");
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write($"{player.name_P}의 공격! {player.attack} 데미지!");
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write($"{name}의 공격! {attack} 데미지");
            Console.SetCursorPosition(uiStartX, uiStartY++);
        }
        public void ClearBattlePrint()
        {
            int uiStartX = 52;
            int uiStartY = 10;
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write("                                   ");
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write("                                    ");
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write("                                    ");
            Console.SetCursorPosition(uiStartX, uiStartY++);
            Console.Write("                                    ");
            Console.SetCursorPosition(uiStartX, uiStartY++);

            Console.SetCursorPosition(uiStartX, uiStartY++);
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

        public void DropBox(Item item, int money)
        {
            
        }
    }




    public class MonsterDic
    {
        // 싱글톤 저장소
        private static MonsterDic instance;
        public static MonsterDic Instance { get { if (instance == null) instance = new MonsterDic(); return instance; } }

        public Dictionary<string, Monster> monstetDatas = new Dictionary<string, Monster>()
        {
            {"슬라임", new Monster("슬라임", 10, 3, 10) },
            {"고블린", new Monster("고블린", 30, 10, 30) }
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

    public class DropTable
    {
        public ItemData item;
        public float dropProb;

        public DropTable(string name, float dropProb)
        {
            this.item = ItemDataBase.Instance.itemDatas[name];
            this.dropProb = dropProb;
        }
    }

    public class DropTableDataBase
    {
        private static DropTableDataBase instance;
        public static DropTableDataBase Instance { get { if (instance == null) instance = new DropTableDataBase(); return instance; } }
        public Dictionary<string, List<DropTable>> monsterDropTable = new Dictionary<string, List<DropTable>>()
        {
            {"슬라임",  new List<DropTable>
            { 
                new DropTable("슬라임 파편", 0.6f), 
                new DropTable("기본 투구", 0.1f),
            } },
            {"고블린",  new List<DropTable>
            {
                new DropTable("고블린의 귀", 0.6f),
                new DropTable("기사단장의 보검", 0.01f),
            } },
        };
    }
}
