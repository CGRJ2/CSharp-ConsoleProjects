using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
    public class Box : InteractableObject
    {
        public int money;
        public List<Item> items;

        public Box(int money, List<Item> items)
        {
            this.money = money;
            this.items = items;
        }

        public override void Interact(ref MapInstance mapInstance, ref Player player)
        {

        }
    }
}
