namespace MassTransit.AmqpTransport
{
    using System;
    using System.Diagnostics;
    using Util;


    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
    public readonly struct ActiveMqHostAddress
    {
        // public const string ActiveMqScheme = "activemq";
        public const string AmqpScheme = "amqp";
        public const string AmqpsScheme = "amqps";

        public readonly string Scheme;
        public readonly string Host;
        public readonly int? Port;
        public readonly string VirtualHost;

        public ActiveMqHostAddress(Uri address)
        {
            Scheme = default;
            Host = default;
            Port = default;
            VirtualHost = default;

            var scheme = address.Scheme.ToLowerInvariant();
            switch (scheme)
            {
                case AmqpScheme:
                case AmqpsScheme:
                    ParseLeft(address, out Scheme, out Host, out Port, out VirtualHost);
                    break;

                default:
                    throw new ArgumentException($"The address scheme is not supported: {address.Scheme}", nameof(address));
            }
        }

        public ActiveMqHostAddress(string host, int? port, string virtualHost)
        {
            Scheme = AmqpScheme;
            Host = host;
            Port = port;
            VirtualHost = virtualHost;

            if (port.HasValue)
            {
                if (port.Value == 0)
                {
                    Port = 5672;
                }

                if (port.Value == 5671)
                {
                    Scheme = AmqpsScheme;
                }
            }
        }

        static void ParseLeft(Uri address, out string scheme, out string host, out int? port, out string virtualHost)
        {
            scheme = address.Scheme;
            host = address.Host;

            port = address.IsDefaultPort
                ? scheme.EndsWith("s", StringComparison.OrdinalIgnoreCase) ? 5671 : 5672
                : address.Port;

            virtualHost = address.ParseHostPath();
        }

        public static implicit operator Uri(in ActiveMqHostAddress address)
        {
            var builder = new UriBuilder
            {
                Scheme = address.Scheme,
                Host = address.Host,
                Port = address.Port.HasValue
                    ? address.Scheme.EndsWith("s", StringComparison.OrdinalIgnoreCase)
                        ? address.Port.Value == 5671 ? 0 : address.Port.Value
                        : address.Port.Value == 5672
                            ? 0
                            : address.Port.Value
                    : 0,
                Path = address.VirtualHost == "/"
                    ? "/"
                    : $"/{Uri.EscapeDataString(address.VirtualHost)}"
            };

            return builder.Uri;
        }

        Uri DebuggerDisplay => this;
    }
}
