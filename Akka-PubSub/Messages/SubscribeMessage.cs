namespace Messages
{
    public class SubscribeMessage
    {
        public string Name { get; private set; }

        public SubscribeMessage(string name)
        {
            Name = name;
        }
    }
}
