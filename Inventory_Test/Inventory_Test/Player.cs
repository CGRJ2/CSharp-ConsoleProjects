using System;
using System.Collections.Generic;

namespace Inventory_Test
{
    public enum EquipTyep { head, body, shoes, gloves }

    public class Inventory
    {
        public static int slotCount = 8;
        public List<ItemInstance> slots = new List<ItemInstance>(slotCount);

        public void AddItem(ItemInstance itemInstance)
        {
            // 1. 수량이 있는 아이템
            if (itemInstance.itemData is IStackable stackable)
            {
                int remains = itemInstance.count;
                int maxCount = stackable.maxCount;

                int canAddCount = 0;

                // 인벤토리 확인 => 추가 가능한 수량 체크
                foreach (var slot in slots)
                {
                    // 현재 아이템과 겹치는 아이템이 있는 슬롯이라면 => {최대수량 - 현재슬롯에 있는 아이템 개수} 만큼 아이템 추가 가능.
                    if (slot.itemData == itemInstance.itemData)
                    {
                        canAddCount += maxCount - slot.count;
                    }
                    // 빈공간이라면 => 최대수량만큼 추가 가능
                    else if (slot.itemData == null)
                    {
                        canAddCount += maxCount;
                    }
                }

                // (추가 가능한 수량 < 얻는 아이템 수량) => 추가 불가!
                if (canAddCount < itemInstance.count)
                {
                    Console.WriteLine("인벤토리 공간 부족!");
                    return;
                }

                // 추가 가능!
                else
                {
                    // 겹치는 아이템이 존재한다면 합쳐주기 (우선순위)
                    for (int i = 0; i < slots.Count && remains > 0; i++)
                    {
                        if (slots[i].itemData == itemInstance.itemData)
                        {
                            if (slots[i].count + remains > maxCount)
                            {
                                remains -= (maxCount - slots[i].count);
                                slots[i].count = maxCount;
                            }
                            else // 남은게 다 들어감. -> 끝
                            {
                                slots[i].count += remains;
                                return;
                            }
                        }
                    }

                    // 그래도 남으면? 빈공간에 남은 수량 넣어주기
                    for (int i = 0; i < slots.Count && remains > 0; i++)
                    {
                        if (slots[i].itemData == null)
                        {
                            slots[i].itemData = itemInstance.itemData;

                            if (remains > maxCount)
                            {
                                slots[i].count = maxCount;
                                remains -= maxCount;
                            }
                            else
                            {
                                slots[i].count = remains;
                                return;
                            }
                            
                        }
                    }
                }

            }

            // 2. 수량이 없는 아이템
            else
            {
                for (int i = 0; i < slots.Count; i++)
                {
                    if (slots[i].itemData == null)
                    {
                        slots[i].itemData = itemInstance.itemData;
                        return;
                    }
                }
                Console.WriteLine("인벤토리 공간 부족!");
                return;
            }
        }

        public void RemoveItem(ItemData itemData)
        {

        }

    }

    public class Player
    {
        public int hp;
        public int mp;

        public int atk;
        public int def;

        // 초기화 해두자.
        public Inventory inventory;
        public Dictionary<EquipTyep, ItemInstance> equipState = new Dictionary<EquipTyep, ItemInstance>()
        {
            { EquipTyep.head, null },
            { EquipTyep.body, null },
            { EquipTyep.shoes, null },
            { EquipTyep.gloves, null }
        };



        public void Heal(int amount)
        {
            hp += amount;
        }

        public void Teleport(string mapName)
        {

        }
    }
}
