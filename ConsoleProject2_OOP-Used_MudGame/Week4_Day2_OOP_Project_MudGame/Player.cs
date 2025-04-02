using System;

namespace Week4_Day2_OOP_Project_MudGame
{
    public class Player
    {
        private int money;
        public int Money { get { return money; } set { money = value; } }


        private int power;
        public int Power { get { return power; } set { power = value; } }

        private int speed;
        public int Speed { get { return speed; } set { speed = value; } }

        public Inventory inven = new Inventory();
    }

    public class Inventory
    {
        // 여기 살짝 꼬임
        // 인벤토리는 플레이어 고유니까 객체로 만들어야하나? 솔플이니까 그냥 정적클래스로 할까?
        public int invenCapacity = 8;
        public Item[] inventory = new Item[invenCapacity];

        public Inventory()
        {
            // 기본 아이템 제공
            GetItem(ItemDataBase.ItemDatas[1]);
            GetItem(ItemDataBase.ItemDatas[2]);
            GetItem(ItemDataBase.ItemDatas[1001]);
            GetItem(ItemDataBase.ItemDatas[2001]);
            GetItem(ItemDataBase.ItemDatas[3001]);
            GetItem(ItemDataBase.ItemDatas[4001]);
            GetItem(ItemDataBase.ItemDatas[5001]);
            GetItem(ItemDataBase.ItemDatas[9001]);
        }


        public static void GetItem(Item item)
        {
            for (int i = 0; i < invenCapacity; i++)
            {
                if (inventory[i] == null)
                {
                    inventory[i] = item;
                    return;
                }
                else if ( (inventory[i] == item) && (item.type == ItemType.Consumable) && (item.ItemCount <99) )
                {
                    inventory[i].ItemCount += 1;
                    return;
                }
            }
            // 빈자리 없으면 리턴 안됨. => 인벤토리 꽉찬상태
            Console.WriteLine("인벤토리에 빈 공간이 없습니다!");
        }

        public static void LoseItem(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                    inventory[0] = null;
                    break;
                case ConsoleKey.D2:
                    inventory[1] = null;
                    break;
                case ConsoleKey.D3:
                    inventory[2] = null;
                    break;
                case ConsoleKey.D4:
                    inventory[3] = null;
                    break;
                case ConsoleKey.D5:
                    inventory[4] = null;
                    break;
                case ConsoleKey.D6:
                    inventory[5] = null;
                    break;
                case ConsoleKey.D7:
                    inventory[6] = null;
                    break;
                case ConsoleKey.D8:
                    inventory[7] = null;
                    break;
            }
        }
    }

}
