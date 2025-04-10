using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniGame_OOP_Project
{
    public enum ObjectType
    {
        NPC, Monster, Portal
    }
    public abstract class InteractableObject
    {

        public string interactScript;
        public ObjectType type;
        public abstract void Interact(ref MapInstance mapInstance, ref Player player);
    }
}
