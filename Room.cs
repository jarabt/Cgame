using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Cgame
{
    class Room
    {
        public string Description { get; }
        public List<Thing> Items { get; set; }

        public bool Sever { get; }
        public bool Jih { get; }
        public bool Vychod { get; }
        public bool Zapad { get; }

        public Room(string description, List<Thing> things, bool sever, bool jih, bool vychod, bool zapad )
        {
            this.Description = description;
            this.Items = things;
            this.Sever = sever;
            this.Jih = jih;
            this.Vychod = vychod;
            this.Zapad = zapad;

        }

        public void ShowItems()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"  {i}: {Items[i]}");    
            }
        }

        public void ShowWays()
        {
            if (Sever)
                Console.WriteLine("   sever");
            if (Jih)
                Console.WriteLine("   jih");
            if (Vychod)
                Console.WriteLine("   vychod");
            if (Zapad)
                Console.WriteLine("   zapad");
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
