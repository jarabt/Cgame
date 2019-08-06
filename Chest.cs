using System;
using System.Collections.Generic;
using System.Text;

namespace Cgame
{
   public class Chest : Thing
   {
        public int KeyIdentifier { get; protected set; }
        private Thing content;
        public Chest(string name, int keyIdentifier, Thing content) : base(name)
        {
            this.KeyIdentifier = keyIdentifier;
            this.content = content;
        }

        public override bool UseOnMe(Thing thing)
        {
            var key = thing as Key;
            if (key != null)
            {
                if (key.KeyIdentifier == this.KeyIdentifier)
                {
                    Console.WriteLine("Truhla se otevrela. Nasel jsi: " + content.name);
                    Program.Player.inventory.Add(content);
                    return true;
                }
                else Console.WriteLine("Spatny klic");
            }
            else Console.WriteLine(thing.ToString() + " Se neda na Truhlu Pouzit");
                return false;
        }
   }
}
