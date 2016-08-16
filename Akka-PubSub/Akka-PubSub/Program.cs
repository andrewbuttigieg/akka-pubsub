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
            system = ActorSystem.Create("PubSubActorSystem");
            Console.WriteLine("Created System.");

            IActorRef pubSubActor = system.ActorOf(Props.Create(typeof(PubSubActor)), "PubSubActor");
            for (int i = 0; i < 10; i++)
            {
                IActorRef consoleWriterActor = system.ActorOf(Props.Create(typeof(ConsoleWriterActor)),
                    $"ConsoleWriterActor{i}");
                pubSubActor.Tell(new SubscribeMessage($"ConsoleWriterActor{i}"), consoleWriterActor);
            }
            Console.ReadLine();
            pubSubActor.Tell(new ConsoleWriteMessage("This is a message to all subs."));

            Console.ReadLine();
            system.Terminate();
        }
    }
}
