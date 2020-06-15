namespace MassTransit.AmqpTransport.Topology
{
    using MassTransit.Topology;


    public interface IActiveMqMessageSendTopology<TMessage> :
        IMessageSendTopology<TMessage>
        where TMessage : class
    {
    }
}
