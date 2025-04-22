using System;
using System.Collections.Generic;

namespace Inventory_Test
{

    public class ItemInstance
    {
        public ItemData itemData;
        public int count;

        public ItemInstance(ItemData itemData, int count = 0)
        {
            this.itemData = itemData;
            this.count = count;
        }

    }

    public interface IStackable
    {
        int maxCount { get; }
    }

    public interface IEquipable
    {
        void Equip(Player player);

        void UnEquip(Player player);
    }


    // 아이템 자체는 만들 수 없게. 아이템 인스턴스에서 갖는 데이터
    public abstract class ItemData
    {
        public string name;
        public int price;

        public ItemData(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
    }
     
    

    public class Weapon : ItemData, IEquipable
    {
        public int atk;
        
        public Weapon(string name, int price, int atk) : base(name, price)
        {
            this.atk = atk;
        }

        public void Equip(Player player)
        {
            // 장비창에 무기가 이미 있다면 장착 불가 -> 이건 인벤토리에서 가능 여부 판단하는걸로
            player.atk += this.atk;
            player.inventory.RemoveItem(this);
            
            // 장비창에 장착
        }

        public void UnEquip(Player player)
        {
            // 인벤토리에 빈공간이 없다면 장착해제 불가 -> 이건 인벤토리에서 가능 여부 판단하는걸로
            player.atk -= this.atk;
            //player.inventory.AddItem(this);
            // 장비창에 장착해제
        }
    }


    public class Consumable : ItemData, IStackable
    {
        public int maxCount { get; private set; }

        public Action<Player> effect;


        // 소비 아이템은 기본 맥스카운트. 특별 아이템들만 최대 갯수 조정하기
        public Consumable(string name, int price, Action<Player> effect, int maxCount = 100) : base(name, price)
        {
            this.maxCount = maxCount;
            this.effect = effect;
        }

        public void Consume(Player player)
        {

            effect?.Invoke(player);

        }
    }

    public class NormalItem : ItemData, IStackable
    {
        public int maxCount { get; private set; }

        public NormalItem(string name, int price, int maxCount = 100) : base(name, price)
        {
            this.maxCount = maxCount;
        }
    }
    public class QuestItem : ItemData
    {
        public QuestItem(string name, int price = 0) : base(name, price)
        {

        }
    }



    public class ItemDataBase
    {
        ItemData a = new Consumable("HP포션", 50, (player) => player.hp += 10); // 람다식으로 포션 효과 설정

        Dictionary<string, ItemData> itemDB = new Dictionary<string, ItemData>()
        {
            // 여기에 ItemData 저장
        };
    }
}
