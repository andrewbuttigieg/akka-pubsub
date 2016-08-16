namespace Messages
{
    public class UnsubscribeMessage
    {
        public string Name { get; private set; }

        public UnsubscribeMessage(string name)
        {
            Name = name;
        }
    }
}
