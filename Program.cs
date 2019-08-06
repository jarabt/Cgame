using System;
using System.Collections.Generic;

namespace Cgame
{
    class Program
    {
        public static Room currentRoom;
        public static Player Player { get; set; }
        static void Main(string[] args)
        {
            Player = new Player(100, "Pepa");
            Player.inventory.Add(new Key("Stary klic", 42));
            var chest = new Chest("Stara truhla", 42, new Sword("Stary mec", 10));
            var dirtyChest = new Chest("Spinava truhla", 43, new Key("Novy klic", 101));
            Player.inventory.Add(new Key("Spinavy klic", 43));

            Room startRoom=    new Room("Jste v temne mistnosti plne pavouku.", new List<Thing> {chest});
            Room anotherRoom = new Room("Jste v spinave mistnosti plne pavouku.", new List<Thing> { dirtyChest });
            Room lockedRoom = new Room("Jste v nove mistnosti plne pavouku.", new List<Thing> { });
            currentRoom = startRoom;

        /*var door1 = */new Door("Spinave dvere", startRoom, anotherRoom, Door.State.OPEN, null);
            var door2 = new Door("Funglovky nove bezpecnostni dvere", startRoom, lockedRoom, Door.State.BLOCKED, 101);
            var case1 = new Blockage("Skrinka. Kdo dal skrinku pred dvere?", door2);
            startRoom.Items.Add(case1);

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

                    case "go":
                        Console.WriteLine("Vyber skrz ktere dvere chces projit:");
                        string roomItemIndex1 = Console.ReadLine();
                        var roomItemGo = currentRoom.Items[Convert.ToInt32(roomItemIndex1)];
                        if (roomItemGo is Door)
                        {
                            var d2 = roomItemGo as Door;
                            if (d2 != null)
                               if (d2.Go()) Console.WriteLine(currentRoom.ToString());
                        }
                        else Console.WriteLine($"Skrz {roomItemGo} nejde projit"); 
                        break;

                    default:
                        Console.WriteLine("Spatne zadani");
                        break;
                }
            }
        }
    }
}