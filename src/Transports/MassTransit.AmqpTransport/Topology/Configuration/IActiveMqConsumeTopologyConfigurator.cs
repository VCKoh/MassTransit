namespace MassTransit.AmqpTransport.Topology
{
    using MassTransit.Topology;


    public interface IActiveMqConsumeTopologyConfigurator :
        IConsumeTopologyConfigurator,
        IActiveMqConsumeTopology
    {
        new IActiveMqMessageConsumeTopologyConfigurator<T> GetMessageTopology<T>()
            where T : class;

        void AddSpecification(IActiveMqConsumeTopologySpecification specification);
    }
}
