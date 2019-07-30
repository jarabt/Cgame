using System;

namespace Cgame
{
    class Program
    {
        static void Main(string[] args)
        {
            Player myPlayer = new Player(100, "Pepa");
            Thing sword = new Sword("sword",10);
            Thing key = new Thing("key");



            myPlayer.inventory.Add(sword);
            myPlayer.inventory.Add(key);

            myPlayer.showInventory();

        }
    }
}
