namespace MassTransit.AmqpTransport.Configuration
{
    using MassTransit.Configuration;
    using Topology;


    public interface IActiveMqReceiveEndpointConfiguration :
        IReceiveEndpointConfiguration,
        IActiveMqEndpointConfiguration
    {
        ReceiveSettings Settings { get; }

        void Build(IActiveMqHostControl host);
    }
}
