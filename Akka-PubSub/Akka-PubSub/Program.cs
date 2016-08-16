using Actors;
using Akka.Actor;
using Messages;
using System;

namespace Akka_PubSub
{
    public class Program
    {
        public static ActorSystem system;

        static void Main(string[] args)
        {
            system = ActorSystem.Create("MyActorSystem");
            Console.WriteLine("Created System.");
            
            IActorRef pubSubActor = system.ActorOf(Props.Create(typeof(PubSubActor)), "PubSubActor");
            IActorRef consoleWriterActor1 = system.ActorOf(Props.Create(typeof(ConsoleWriterActor)), "ConsoleWriterActor1");
            IActorRef consoleWriterActor2 = system.ActorOf(Props.Create(typeof(ConsoleWriterActor)), "ConsoleWriterActor2");

            pubSubActor.Tell(new SubscribeMessage("ConsoleWriterActor1"), consoleWriterActor1);
            pubSubActor.Tell(new SubscribeMessage("ConsoleWriterActor2"), consoleWriterActor2);
            Console.ReadLine();
            pubSubActor.Tell(new ConsoleWriteMessage("This is a message to all subs."));

            Console.ReadLine();
            system.Terminate();
        }
    }
}
