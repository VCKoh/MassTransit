namespace MassTransit.AmqpTransport.Topology.Entities
{
    using MassTransit.Topology.Entities;


    public interface TopicHandle :
        EntityHandle
    {
        Topic Topic { get; }
    }
}
