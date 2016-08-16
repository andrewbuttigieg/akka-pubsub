using Akka.Actor;
using Messages;
using System.Collections.Generic;

namespace Actors
{
    public class PubSubActor: ReceiveActor
    {
        Dictionary<string, IActorRef> subs = new Dictionary<string, IActorRef>();

        public PubSubActor()
        {
            Receive<Subscribe>(sub =>
            {
                if (subs.ContainsKey(sub.Name) == false)
                {
                    subs.Add(sub.Name, Sender);
                }
            });

            Receive<Unsubscribe>(unsub =>
            {
                if (subs.ContainsKey(unsub.Name))
                {
                    subs.Remove(unsub.Name);
                }
            });
        }
    }
}
