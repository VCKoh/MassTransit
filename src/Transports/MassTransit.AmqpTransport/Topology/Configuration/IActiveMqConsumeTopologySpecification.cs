namespace MassTransit.AmqpTransport.Topology
{
    using Builders;
    using GreenPipes;


    public interface IActiveMqConsumeTopologySpecification :
        ISpecification
    {
        void Apply(IReceiveEndpointBrokerTopologyBuilder builder);
    }
}
