namespace Cgame
{
    public abstract class Thing
    {
        public string name { get; }
        public Thing(string inputName)
        {
            name = inputName;
        }

        // Auto loot
        public abstract bool UseOnMe(Thing thing);
    
        public override string ToString()
        {
            return name;
        }
    }
}
