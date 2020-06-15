namespace MassTransit.AmqpTransport
{
    using Apache.NMS;


    public interface ActiveMqMessageContext
    {
        IMessage TransportMessage { get; }

        IPrimitiveMap Properties { get; }
    }
}
