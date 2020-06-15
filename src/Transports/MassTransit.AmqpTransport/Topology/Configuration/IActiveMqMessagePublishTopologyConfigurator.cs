namespace MassTransit.AmqpTransport.Topology
{
    using MassTransit.Topology;


    public interface IActiveMqMessagePublishTopologyConfigurator<TMessage> :
        IMessagePublishTopologyConfigurator<TMessage>,
        IActiveMqMessagePublishTopology<TMessage>,
        IActiveMqMessagePublishTopologyConfigurator
        where TMessage : class
    {
    }


    public interface IActiveMqMessagePublishTopologyConfigurator :
        IMessagePublishTopologyConfigurator,
        IActiveMqMessagePublishTopology,
        ITopicConfigurator
    {
    }
}
