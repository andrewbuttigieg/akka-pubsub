using Akka.Actor;
using Messages;
using System;

namespace Actors
{
    public class ConsoleWriterActor: ReceiveActor
    {
        public ConsoleWriterActor()
        {
            Console.WriteLine("Created console writer actor.");

            Receive<ConsoleWriteMessage>(message =>
            {
                Console.WriteLine($"Received message \"{message.Message}\" as actor {Self.Path}.");
            });
        }
    }
}
