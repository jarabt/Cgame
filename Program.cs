using System;
using System.Collections.Generic;

namespace Cgame
{
    class Program
    {
        private static Room currentRoom;
        public static Player Player { get; set; }
        
        static void Main(string[] args)
        {
            var chest = new Chest("Stara truhla", 42);

            Room[,] Rooms = new Room[10, 10];


            Rooms[0,0] = new Room("Jste v temne mistnosti plne pavouku.", new List<Thing> { chest });

            Player = new Player(100, "Pepa");
            Player.inventory.Add(new Key("Stary klic", 42));

            currentRoom = Rooms[0, 0];
         
            Console.WriteLine("Hra začíná");

            while (true)
            {
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "player": 
                        Console.WriteLine(Player.ToString());
                        break;
                    case "player inventory":
                        Player.showInventory();
                        break;
                    case "room":
                        Console.WriteLine(currentRoom.ToString());
                        break;
                    case "room inventory":
                        currentRoom.ShowItems();
                        break;
                    case "use":
                        Console.WriteLine("Vyber predmet hrace:");
                        string playerItemIndex = Console.ReadLine();

                        Console.WriteLine("Vyber predmet v mistonosti:");
                        string roomItemIndex = Console.ReadLine();

                        var playerItem = Player.inventory[Convert.ToInt32(playerItemIndex)];
                        var roomItem = currentRoom.Items[Convert.ToInt32(roomItemIndex)];
                        roomItem.UseOnMe(playerItem);
                        break;

                    default:
                        Console.WriteLine("Spatne zadani");
                        break;
                }
            }
        }
    }
}