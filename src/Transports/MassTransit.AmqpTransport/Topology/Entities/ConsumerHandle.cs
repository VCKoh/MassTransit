namespace MassTransit.AmqpTransport.Topology.Entities
{
    using MassTransit.Topology.Entities;


    public interface ConsumerHandle :
        EntityHandle
    {
        Consumer Consumer { get; }
    }
}
