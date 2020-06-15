namespace MassTransit.AmqpTransport.Configuration
{
    using MassTransit.Configuration;


    public interface IActiveMqEndpointConfiguration :
        IEndpointConfiguration
    {
        new IActiveMqTopologyConfiguration Topology { get; }
    }
}
