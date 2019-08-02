using System;
using System.Collections.Generic;
using System.Text;

namespace Cgame
{
   public class Chest : Thing
   {
        public int KeyIdentifier { get; protected set; }
        public Chest(string name, int keyIdentifier) : base(name)
        {
            this.KeyIdentifier = keyIdentifier;
        }

        public override bool UseOnMe(Thing thing)
        {
            var key = thing as Key;
            if (key != null)
            {
                if (key.KeyIdentifier == this.KeyIdentifier)
                {
                    
                    Console.WriteLine("Truhla se otevrela. Nasel jsi mec.");
                    Program.Player.inventory.Add(new Sword("Stary mec", 10));
                    return true;
                }
            }

            return false;
        }
   }
}
