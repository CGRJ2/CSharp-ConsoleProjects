﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            Weapon a = (Weapon)player.equipState.weaponSlot;
            a.UnEquip(player);
        }
    }


}
