namespace Messages
{
    public class Unsubscribe
    {
        public string Name { get; private set; }

        public Unsubscribe(string name)
        {
            Name = name;
        }
    }
}
