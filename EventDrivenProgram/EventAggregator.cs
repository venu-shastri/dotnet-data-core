using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDrivenProgram
{
    public class PubSubEvent
    {
        List<Action> _subscribersList = new List<Action>();
        public void Subscribe(Action subscriberAddress)
        {

        }
        public void Publish()
        {

        }
        public void UnSubcribe(Action subscriberAdderss) { }
    }

    public class E1 : PubSubEvent
    {

    }

    public  class PrismEventAggregator
    {
        List<PubSubEvent> _eventsStore = new List<PubSubEvent>();

    }


    public interface ISubscribe
    {
        void Update(string eventName);

    }

    public interface IEventAggregator
    {
        void Publish(string eventName);
        void Subscribe(string eventName, ISubscribe subscriberAddress);
    }

    public class EventAggregator : IEventAggregator
    {
        Dictionary<string, List<ISubscribe>> _routingTable = new Dictionary<string, List<ISubscribe>>();
        public void Subscribe(string eventName, ISubscribe subscriberAddress)
        {
            if (_routingTable.ContainsKey(eventName))
            {
                _routingTable[eventName].Add(subscriberAddress);
            }
            else
            {
                _routingTable.Add(eventName, new List<ISubscribe> { subscriberAddress });
            }
        }

        public void Publish(string eventName)
        {
            if (_routingTable.ContainsKey(eventName))
            {
                List<ISubscribe> _subscribers = _routingTable[eventName];
                foreach (ISubscribe subscriber in _subscribers)
                {
                    subscriber.Update(eventName);
                }
            }

        }
    }

    public class ModuleA
    {

        IEventAggregator _mediator;
        public ModuleA(IEventAggregator mediator)
        {
            this._mediator = mediator;
        }
        public void PublishEvent()
        {
            this._mediator.Publish("E1");
        }

    }

    public class ModuleD : ISubscribe
    {
        IEventAggregator _mediator;

        public ModuleD(IEventAggregator mediator)
        {
            _mediator = mediator;
            _mediator.Subscribe("E1", this);
            _mediator.Subscribe("E2", this);
            _mediator.Subscribe("E3", this);
        }
        public void Update(string eventName)
        {
            throw new NotImplementedException();
        }
    }
}
