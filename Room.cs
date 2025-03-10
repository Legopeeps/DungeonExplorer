namespace DungeonExplorer
{
    public class Room
    {
        private string description;

        public Room(string description)
        {
            this.description = description;
        }

        private string GetDescription()
        {
            return description;
        }
    }
}