namespace MassTransit.AmqpTransport.Topology
{
    using MassTransit.Topology;


    public interface IActiveMqPublishTopologyConfigurator :
        IPublishTopologyConfigurator,
        IActiveMqPublishTopology
    {
        new IActiveMqMessagePublishTopologyConfigurator<T> GetMessageTopology<T>()
            where T : class;
    }
}
