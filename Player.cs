using System;
using System.Collections.Generic;
using System.Text;

namespace Cgame
{
    class Player
    {
        public int HP { get; }
        public string name { get; }
        public List<Thing> inventory { get; set; }

        public Player(int inputHP, string inputName)
        {
            HP = inputHP;
            name = inputName;
            inventory = new List<Thing>();
        }

        public void showInventory()
        {
            foreach (Thing thing in inventory)
            {
                Console.WriteLine(thing.name);
            }
        }

    }
}
