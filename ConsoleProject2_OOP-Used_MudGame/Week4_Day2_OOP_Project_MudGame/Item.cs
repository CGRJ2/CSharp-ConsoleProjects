using System.Collections.Generic;

namespace Week4_Day2_OOP_Project_MudGame
{
    #region 아이템 종류별 클래스
    public class Item
    {
        public ItemData Data { get; set; }
        public Item(ItemData itemData) { Data = itemData; }
    }

    public class Consumable : Item
    {
        // 아이템 개수
        public int count;
        public Consumable(ItemData itemData, int itemCount) : base(itemData) { count = itemCount; }
    }

    public class Armor : Item
    {
        public int DEF { get; }     // 방어력         // 강화하면 수치 달라지니까. 이때는 set도 필요한가?
        public int SPD { get; }     // 속도
        public int CHA { get; }     // 매력
        public Armor(ItemData itemData, int dEF, int sPD, int cHA) : base(itemData)
        {
            DEF = dEF;
            SPD = sPD;
            CHA = cHA;
        }
    }

    public class Weapon : Item
    {
        public int DMG { get; }     // 공격력
        public Weapon(ItemData itemData, int dmg) : base(itemData) { DMG = dmg; }
    }
    #endregion

    #region 아이템 정보 저장공간

    public class ItemData
    {
        // 아이템 코드
        public int Code { get; }
        public string Name { get; }
        public int MaxCount { get; }
        public string Description { get; }


        public ItemData(int code, string name, int maxCount, string descript)
        {
            Code = code;
            Name = name;
            MaxCount = maxCount;
            Description = descript;
        }
    }






    public static class ItemDataBase
    {
        public static Dictionary<int, ItemData> itemDatas = new Dictionary<int, ItemData>
        {
            {1, new ItemData(1, "체력 포션", 99, "HP를 회복합니다.")},
            {2, new ItemData(2, "마나 포션", 99, "MP를 회복합니다.")},
            {1001, new ItemData(1001, "기본 투구", 1, "제법 쓸만한 투구이다.")},
            {2001, new ItemData(2001, "기본 상의", 1, "제법 쓸만한 상의이다.")},
            {3001, new ItemData(3001, "기본 하의", 1, "제법 쓸만한 하의이다.")},
            {4001, new ItemData(4001, "기본 장갑", 1, "제법 쓸만한 장갑이다.")},
            {5001, new ItemData(5001, "기본 신발", 1, "제법 쓸만한 신발이다.")},
            {6001, new ItemData(6001, "기본 롱소드", 1, "제법 쓸만한 롱소드다.")},
            {1099, new ItemData(1099, "드래곤의 투   구", 1, "드래곤을 처치한 용사가 사용했던 투구. 진짜 드래곤의 비늘이 박혀있다.")},
            {6099, new ItemData(6099, "기사단장의 보검", 1, "고대 왕국의 기사단장이 사용했던 보검. 여전히 축복이 남아 은은한 빛을 내고 있다.")},
            {9001, new ItemData(9001, "리사의 편지", 1, "알렉스에게 쓰는 편지. 열어보지말고 바로 전달하자.")}
        };
    }

    #endregion
}
