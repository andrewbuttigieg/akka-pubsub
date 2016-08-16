using Akka.Actor;
using Messages;
using System;
using System.Collections.Generic;

namespace Actors
{
    public class PubSubActor: ReceiveActor
    {
        Dictionary<string, IActorRef> subs = new Dictionary<string, IActorRef>();

        public PubSubActor()
        {
            Receive<SubscribeMessage>(sub =>
            {
                if (subs.ContainsKey(sub.Name) == false)
                {
                    Console.WriteLine($"Actor subbed with name {sub.Name}");
                    subs.Add(sub.Name, Sender);
                }
            });

            Receive<UnsubscribeMessage>(unsub =>
            {
                if (subs.ContainsKey(unsub.Name))
                {
                    Console.WriteLine($"Actor unsubbed with name {unsub.Name}");
                    subs.Remove(unsub.Name);
                }
            });

            Receive<ConsoleWriteMessage>(message =>
            {
                foreach (var sub in subs.Values)
                    sub.Tell(message);
            });
        }
    }
}
