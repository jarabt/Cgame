using System;
using System.Collections.Generic;
using System.Text;

namespace Cgame
{
  public  class Door: Thing
    {
       public enum State { OPEN, LOCKED, BLOCKED}
       private State state = State.OPEN;
        private Room room1,room2;
        public int? NullableKeyIdentifier { get; protected set; }//null pro pripad kdyz dvere nepotrebuji klic
        public  Door (string name, Room room1,Room room2, State state, int? nullableKeyIdentifier):base(name)
        {
            this.room1 = room1;
            this.room2 = room2;
            this.state = state;
            this.NullableKeyIdentifier = nullableKeyIdentifier;
            room1.Items.Add(this);
            room2.Items.Add(this);
        }
        public override bool UseOnMe(Thing thing)
        {
            if (state == State.BLOCKED)
            {
                Console.WriteLine("Pred dvermi neco prekazi");
                return false;
            }

            var key = thing as Key;
            if (NullableKeyIdentifier.HasValue && key != null)
               {
                  if (key.KeyIdentifier == this.NullableKeyIdentifier.Value)
                   {
                       state = State.OPEN;
                      Console.WriteLine("Dvere se otevrely.");
                    return true;
                   }
                      else Console.WriteLine("Klic Nepasuje.");
                return false;
                }

                Console.WriteLine(thing.ToString() + " nejde na dvere pouzit");
            return false;
        }
       public bool Go()
        {
            switch (state)
            {
                case State.OPEN:
                    
                    if (room1 == Program.currentRoom)
                        Program.currentRoom = room2;
                    else Program.currentRoom = room1;
                    return true;

                case State.LOCKED:
                    Console.WriteLine("Dvere jsou zamcene");
                    return false;

                case State.BLOCKED:

                    Console.WriteLine("Pred dvermi neco prekazi");
                   return false;
                default: return false;
            }
        }
        public void Unblock()
        {
            if (NullableKeyIdentifier.HasValue)
                state = State.LOCKED;
            else state = State.OPEN;
        }
   }
}
