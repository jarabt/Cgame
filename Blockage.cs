using System;
using System.Collections.Generic;
using System.Text;

namespace Cgame
{
   public class Blockage:Thing
    { 
        private Thing blockedThing;
        private bool broken=false;
        public Blockage(string name,Thing blockedThing):base(name)
        {
            this.blockedThing = blockedThing;
        }
        public override bool UseOnMe(Thing thing)
        {
            if (broken)
            {
                Console.WriteLine(name + " Uz je rozbita");
                return false;
            }
            var sword = thing as Sword;
            if (sword != null)
            {
                broken = true;
                Console.WriteLine(name + " ...Byla rozmlacena mecem");
               var door = blockedThing as Door;
                if (door != null) door.Unblock();
                return true;
            }
            return false;

        }
    }
}
