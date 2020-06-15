namespace MassTransit.AmqpTransport.Contexts
{
    using Context;
    using Topology.Builders;


    public interface ActiveMqReceiveEndpointContext :
        ReceiveEndpointContext
    {
        BrokerTopology BrokerTopology { get; }
    }
}
