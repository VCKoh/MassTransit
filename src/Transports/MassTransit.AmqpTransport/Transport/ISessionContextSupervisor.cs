namespace MassTransit.AmqpTransport.Transport
{
    using GreenPipes.Agents;


    /// <summary>
    /// Creates and caches a session on the connection
    /// </summary>
    public interface ISessionContextSupervisor :
        ISupervisor<SessionContext>
    {
    }
}
