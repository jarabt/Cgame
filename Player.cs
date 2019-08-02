using System;
using System.Collections.Generic;
using System.Text;

namespace Cgame
{
    public class Player
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
            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine($"  {i}: {inventory[i]}");
            }
        }

        public override string ToString()
        {
            return $"Jmeno: {name}, HP: {HP}";
        }
    }
}
