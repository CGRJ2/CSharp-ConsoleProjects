using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
    #region 아이템 종류별 클래스
    public class Item
    {
        // 아이템 개수
        public int count;

        public ItemData Data { get; set; }
        public Item(ItemData itemData) { Data = itemData; }
    }

    public class Consumable : Item
    {
        public Consumable(ItemData itemData, int itemCount) : base(itemData) { count = itemCount; }
    }

    public class Armor : Item
    {
        public int defence { get; }     // 방어력  // 강화하면 수치 달라지니까. 이때는 set도 필요한가?
        public Armor(ItemData itemData, int def) : base(itemData)
        {
            defence = def;
        }
    }

    public class Weapon : Item
    {
        public int attack { get; }     // 공격력
        public Weapon(ItemData itemData, int atk) : base(itemData) 
        { 
            attack = atk; 
        }
    }
    #endregion

    #region 아이템 정보 저장공간

    public class ItemData
    {
        // 아이템 코드
        public string Name { get; }
        public int MaxCount { get; }
        public string Description { get; }


        public ItemData(string name, int maxCount, string descript)
        {
            Name = name;
            MaxCount = maxCount;
            Description = descript;
        }
    }



    public class ItemDataBase
    {
        private static ItemDataBase instance;
        public static ItemDataBase Instance { get { if (instance == null) instance = new ItemDataBase(); return instance; } }

        public Dictionary<string, ItemData> itemDatas = new Dictionary<string, ItemData>
        {
            {"체력 포션", new ItemData("체력 포션", 99, "HP를 회복합니다.")},
            {"마나 포션", new ItemData("마나 포션", 99, "MP를 회복합니다.")},
            {"기본 투구", new ItemData("기본 투구", 1, "제법 쓸만한 투구이다.")},
            {"기본 상의", new ItemData("기본 상의", 1, "제법 쓸만한 상의이다.")},
            {"기본 하의", new ItemData("기본 하의", 1, "제법 쓸만한 하의이다.")},
            {"기본 장갑", new ItemData("기본 장갑", 1, "제법 쓸만한 장갑이다.")},
            {"기본 신발", new ItemData("기본 신발", 1, "제법 쓸만한 신발이다.")},
            {"기본 롱소드", new ItemData("기본 롱소드", 1, "제법 쓸만한 롱소드다.")},
            {"드래곤의 투구", new ItemData("드래곤의 투구", 1, "드래곤을 처치한 용사가 사용했던 투구. 진짜 드래곤의 비늘이 박혀있다.")},
            {"기사단장의 보검", new ItemData("기사단장의 보검", 1, "고대 왕국의 기사단장이 사용했던 보검. 여전히 축복이 남아 은은한 빛을 내고 있다.")},
            {"리사의 편지", new ItemData("리사의 편지", 1, "알렉스에게 쓰는 편지. 열어보지말고 바로 전달하자.")},
            {"슬라임 파편", new ItemData("슬라임 파편", 99, "물컹물컹한 덩어리이다.")},
            {"고블린의 귀", new ItemData("고블린의 귀", 99, "고블린을 사냥한 증표.")}
        };
    }

    #endregion
}
