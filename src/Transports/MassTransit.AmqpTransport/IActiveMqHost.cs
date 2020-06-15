namespace MassTransit.AmqpTransport
{
    using Topology;


    public interface IActiveMqHost :
        IHost,
        IReceiveConnector<IActiveMqReceiveEndpointConfigurator>
    {
        new IActiveMqHostTopology Topology { get; }
    }
}
