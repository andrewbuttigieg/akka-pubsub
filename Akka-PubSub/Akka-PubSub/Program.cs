using Akka.Actor;

namespace Akka_PubSub
{
    public class Program
    {
        public static ActorSystem MyActorSystem;

        static void Main(string[] args)
        {
            MyActorSystem = ActorSystem.Create("MyActorSystem");

        }
    }
}
