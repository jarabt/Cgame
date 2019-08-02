using System;
using System.Collections.Generic;
using System.Text;

namespace Cgame
{
    public class Key : Thing
    {
        public int KeyIdentifier { get; protected set; }

        public Key(string name, int identifier) : base(name)
        {
            KeyIdentifier = identifier;
        }

        public override bool UseOnMe(Thing thing)
        {
            return false;
        }
    }
}
