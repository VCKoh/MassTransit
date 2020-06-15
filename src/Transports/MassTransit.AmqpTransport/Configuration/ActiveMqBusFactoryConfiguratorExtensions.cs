namespace MassTransit.AmqpTransport
{
    using System;
    using Configuration;


    public static class ActiveMqBusFactoryConfiguratorExtensions
    {
        /// <summary>
        /// Select ActiveMQ as the transport for the service bus
        /// </summary>
        public static IBusControl CreateUsingAmqp(this IBusFactorySelector selector, Action<IActiveMqBusFactoryConfigurator> configure)
        {
            return ActiveMqBusFactory.Create(configure);
        }

        /// <summary>
        /// Configure MassTransit to use ActiveMQ for the transport.
        /// </summary>
        /// <param name="configurator">The registration configurator (configured via AddMassTransit)</param>
        /// <param name="configure">The configuration callback for the bus factory</param>
        public static void UsingAmqp(this IBusRegistrationConfigurator configurator,
            Action<IBusRegistrationContext, IActiveMqBusFactoryConfigurator> configure = null)
        {
            configurator.SetBusFactory(new ActiveMqRegistrationBusFactory(configure));
        }
    }
}
