using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // GameMap abstract class handling the dungeon layout and room movement
    abstract class GameMap
    {
        protected Dictionary<Direction, Room> connectedRooms;
        public Room CurrentRoom { get; set; }

        // Direction enumeration for movement
        public enum Direction
        {
            Centre,
            Left,
            Right,
            SecretA,
            SecretB
        }

        // Constructor for initializing map with rooms
        protected GameMap()
        {
            connectedRooms = new Dictionary<Direction, Room>();
            InitializeRooms();
        }

        private void InitializeRooms()
        {
            /// <summary> 
            /// creates the rooms for the game, along with their items and creatures 
            /// Further down monsters are created and assigned to rooms
            /// </summary>
            Room centreRoom = new Room("Centre Room", new List<string> { "massive sword of doom" });
            Room leftRoom = new Room("Left Room", new List<string> { "old stinky sword" });
            Room rightRoom = new Room("Right Room", new List<string> { "healing potion" });
            Room secretRoomA = new Room("Secret Room", new List<string> { "body armour" });
            Room secretRoomB = new Room("Secret Room", new List<string> { "big helmet for your head" });

            rightRoom.creature = new Monster("Stinky Pete", 50, 2); //name, health, damage dealt to player when attacked
            leftRoom.creature = new Monster("Legopeeps the Unruly!!!", 1000, 5); //much bigger health boss, adds variety

            // Connecting rooms
            ConnectRoom(Direction.Centre, centreRoom);
            centreRoom.ConnectRoom(Direction.Left, leftRoom);
            centreRoom.ConnectRoom(Direction.Right, rightRoom);
            
            leftRoom.ConnectRoom(Direction.Centre, centreRoom);
            rightRoom.ConnectRoom(Direction.Centre, centreRoom);
            
            centreRoom.ConnectRoom(Direction.SecretA, secretRoomA);
            centreRoom.ConnectRoom(Direction.SecretB, secretRoomB);

            CurrentRoom = centreRoom; // Starting room, ensures you start here
        }

        public void ConnectRoom(Direction direction, Room room)
        {
            connectedRooms[direction] = room;
        }
        
        public Room GetConnectedRoom(Direction direction)
        {
            return connectedRooms.ContainsKey(direction) ? connectedRooms[direction] : null;
        }

        //error handling for movement
        public bool Move(Direction direction)
        {
            Room next = CurrentRoom.GetConnectedRoom(direction);
            if (next != null)
            {
                CurrentRoom = next;
                return true;
            }
            return false;
        }
    }
}