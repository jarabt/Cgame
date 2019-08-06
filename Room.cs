using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Cgame
{
   public class Room
    {
        public string Description { get; }
        public List<Thing> Items { get; set; }

        public Room(string description, List<Thing> things)
        {
            this.Description = description;
            this.Items = things;
        }

        public void ShowItems()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"  {i}: {Items[i]}");    
            }
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
