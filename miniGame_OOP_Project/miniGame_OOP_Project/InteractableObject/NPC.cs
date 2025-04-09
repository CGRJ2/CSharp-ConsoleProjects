using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
    class NPC : InteractableObject
    {
        public string name { get; private set; }
        public Position npcPos;
        Position currentPos;



        public NPC(string name, Position originPos, int moveRange)
        {
            this.name = name;
            this.npcPos = originPos;
            this.currentPos = originPos;
        }

        public override void Interact()
        {
        }

        public void Add()
        {

        }


        public void RandomMove()
        {

        }

        public void PrintNPC()
        {

        }

    }
}
