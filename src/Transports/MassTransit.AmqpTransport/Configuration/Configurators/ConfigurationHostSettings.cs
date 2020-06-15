namespace MassTransit.AmqpTransport.Configurators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web;
    using Apache.NMS;


    public class ConfigurationHostSettings :
        ActiveMqHostSettings
    {
        readonly Lazy<Uri> _brokerAddress;
        readonly Lazy<Uri> _hostAddress;

        public ConfigurationHostSettings(Uri address)
        {
            var hostAddress = new ActiveMqHostAddress(address);

            Host = hostAddress.Host;
            Username = "";
            Password = "";

            //TransportOptions = new Dictionary<string, string>
            //{
            //    {"wireFormat.tightEncodingEnabled", "true"},
            //    {"nms.AsyncSend", "true"}
            //};
            TransportOptions = new Dictionary<string, string>();

            Port = hostAddress.Port ?? 5672;

            if (!string.IsNullOrEmpty(address.UserInfo))
            {
                string[] parts = address.UserInfo.Split(':');
                Username = parts[0];

                if (parts.Length >= 2)
                    Password = parts[1];
            }

            _hostAddress = new Lazy<Uri>(FormatHostAddress);
            _brokerAddress = new Lazy<Uri>(FormatBrokerAddress);
        }

        public string[] FailoverHosts { get; set; }
        public Dictionary<string, string> TransportOptions { get; set; }

        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool UseSsl { get; set; }

        public Uri HostAddress => _hostAddress.Value;
        public Uri BrokerAddress => _brokerAddress.Value;

        public IConnection CreateConnection()
        {
            // var factory = new NMSConnectionFactory(BrokerAddress);
            // var factory = new NMSConnectionFactory($"amqps://{BrokerAddress.Host}:{BrokerAddress.Port}");
            
            //var factory = new Apache.NMS.AMQP.ConnectionFactory(BrokerAddress);
             var factory = new Apache.NMS.AMQP.ConnectionFactory($"{BrokerAddress.Scheme}://{BrokerAddress.Host}:{BrokerAddress.Port}");

            return factory.CreateConnection(Username, Password);
        }

        Uri FormatHostAddress()
        {
            return new ActiveMqHostAddress(Host, Port, "/");
        }

        Uri FormatBrokerAddress()
        {
            var scheme = UseSsl ? "amqps" : "amqp";
            var queryPart = GetQueryString();

            // create broker URI: https://activemq.apache.org/components/nms/providers/amqp/uri-configuration
            if (FailoverHosts?.Length > 0)
            {
                var failoverPart = string.Join(",", FailoverHosts
                    .Select(failoverHost => new UriBuilder
                    {
                        Scheme = scheme,
                        Host = failoverHost,
                        Port = Port
                    }.Uri.ToString()
                    ));


                return new Uri($"failover:({failoverPart}){queryPart}");
            }


            var uri = new Uri($"{scheme}://{Host}:{Port}{queryPart}");
            return uri;
        }

        string GetQueryString()
        {
            var queryPart = string.Empty;

            //TransportOptions.Add("nms.username", Username);
            //TransportOptions.Add("nms.password", HttpUtility.UrlEncode(Password));

            if (TransportOptions?.Count > 0)
            {
                var queryString = string.Join("&", TransportOptions
                    .Select(pair => $"{pair.Key}={pair.Value}"));

                queryPart = $"?{queryString}";
            }

            return queryPart;
        }

        public override string ToString()
        {
            return new UriBuilder
            {
                Scheme = UseSsl ? "amqps" : "amqp",
                Host = Host,
                Port = Port
            }.Uri.ToString();
        }
    }
}
