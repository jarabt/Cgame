using System;
using System.Collections.Generic;
using System.Text;

namespace Cgame
{
    
    class Sword : Thing
    {
        public int attackPoint { get; }
        public Sword(string inputName, int inputAttackPoint ):base (inputName)
        {
            attackPoint = inputAttackPoint;
        }



    }
}
