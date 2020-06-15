namespace MassTransit.AmqpTransport.Topology
{
    using MassTransit.Topology;


    public interface IActiveMqMessageSendTopologyConfigurator<TMessage> :
        IMessageSendTopologyConfigurator<TMessage>,
        IActiveMqMessageSendTopology<TMessage>,
        IActiveMqMessageSendTopologyConfigurator
        where TMessage : class
    {
    }


    public interface IActiveMqMessageSendTopologyConfigurator :
        IMessageSendTopologyConfigurator
    {
    }
}
