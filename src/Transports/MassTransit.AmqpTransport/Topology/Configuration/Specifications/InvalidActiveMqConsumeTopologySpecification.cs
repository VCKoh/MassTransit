namespace MassTransit.AmqpTransport.Topology.Specifications
{
    using System.Collections.Generic;
    using Builders;
    using GreenPipes;


    public class InvalidActiveMqConsumeTopologySpecification :
        IActiveMqConsumeTopologySpecification
    {
        readonly string _key;
        readonly string _message;

        public InvalidActiveMqConsumeTopologySpecification(string key, string message)
        {
            _key = key;
            _message = message;
        }

        public IEnumerable<ValidationResult> Validate()
        {
            yield return this.Failure(_key, _message);
        }

        public void Apply(IReceiveEndpointBrokerTopologyBuilder builder)
        {
        }
    }
}
