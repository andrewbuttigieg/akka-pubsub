namespace Messages
{
    public class Subscribe
    {
        public string Name { get; private set; }

        public Subscribe(string name)
        {
            Name = name;
        }
    }
}
