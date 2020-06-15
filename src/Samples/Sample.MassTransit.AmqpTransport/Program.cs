using Apache.NMS;
using Apache.NMS.AMQP;
using GreenPipes.Internals.Extensions;
using MassTransit;
using MassTransit.AmqpTransport;
using MassTransit.TestFramework.Messages;
using MassTransit.Util;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.MassTransit.AmqpTransport
{
    class Program
    {
        //const string Scheme = "amqps";
        //const string TestBrokerHost = "b-265bcc9b-dd45-4355-bfdc-098afa1af2fa-1.mq.ap-southeast-1.amazonaws.com";
        //const string TestUsername = "mqadmin";
        //const string TestPassword = "Maado7jRx12@";
        //const int Port = 5671;

        const string Scheme = "amqp";
        const string TestBrokerHost = "localhost";
        const string TestUsername = "admin";
        const string TestPassword = "admin";
        const int Port = 5672;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Should_succeed_and_connect_when_properly_configured().GetAwaiter().GetResult();
            // Should_do_a_bunch_of_requests_and_responses().GetAwaiter().GetResult();
            Should_connect_locally().GetAwaiter().GetResult();

            //var address = GetAddress(Scheme, TestBrokerHost, Port);
            //string queue = "input_queue";

            //NmsAmqpTest(address, queue, TestUsername, TestPassword);

            Console.WriteLine("Done.");
            Console.Read();
        }

        public static async Task Should_succeed_and_connect_when_properly_configured()
        {
            TaskCompletionSource<bool> received = TaskUtil.GetTask<bool>();

            Uri sendAddress = null;

            var busControl = Bus.Factory.CreateUsingActiveMq(cfg =>
            {
                var host = cfg.Host(TestBrokerHost, Port, h =>
                {
                    h.Username(TestUsername);
                    h.Password(TestPassword);

                    // h.UseSsl();
                });

                cfg.ReceiveEndpoint("input_queue", x =>
                {
                    x.Handler<PingMessage>(async context =>
                    {
                        Console.WriteLine("PingHandler received: " + context.Message.CorrelationId);
                        await context.Publish(new PongMessage(context.Message.CorrelationId));
                    });

                    sendAddress = x.InputAddress;
                });

                cfg.ReceiveEndpoint("input_queue_2", x =>
                {
                    x.Handler<PongMessage>(async context =>
                    {
                        Console.WriteLine("PongHandler received: " + context.Message.CorrelationId);
                        received.TrySetResult(true);
                    });
                });
            });

            await busControl.StartAsync(new CancellationTokenSource(TimeSpan.FromMinutes(15)).Token);

            var sendEndpoint = await busControl.GetSendEndpoint(sendAddress);

            await sendEndpoint.Send(new PingMessage());

            await received.Task.OrTimeout(TimeSpan.FromSeconds(5));

            await busControl.StopAsync();
        }

        public static async Task Should_do_a_bunch_of_requests_and_responses()
        {
            var bus = Bus.Factory.CreateUsingActiveMq(sbc =>
            {
                var host = sbc.Host(TestBrokerHost, Port, h =>
                {
                    h.Username(TestUsername);
                    h.Password(TestPassword);

                    // h.UseSsl();
                });

                sbc.ReceiveEndpoint("input_queue", e =>
                {
                    e.Handler<PingMessage>(async context => await context.RespondAsync(new PongMessage(context.Message.CorrelationId)));
                });
            });

            await bus.StartAsync();
            try
            {
                for (var i = 0; i < 10; i = i + 1)
                {
                    var result = await bus.Request<PingMessage, PongMessage>(new PingMessage());
                }
            }
            finally
            {
                await bus.StopAsync();
            }
        }

        public static async Task Should_connect_locally()
        {
            var busControl = Bus.Factory.CreateUsingActiveMq(cfg =>
            {
                cfg.Host(TestBrokerHost, Port, h =>
                {
                    h.Username(TestUsername);
                    h.Password(TestPassword);
                });
            });

            await busControl.StartAsync(new CancellationTokenSource(60000).Token);

            await Task.Delay(10000);

            await busControl.StopAsync(new CancellationTokenSource(60000).Token);
        }

        static void NmsAmqpTest(string address, string queue, string userName, string password)
        {
            var connectionFactory = new NmsConnectionFactory(address);

            var connection = connectionFactory.CreateConnection(userName, password);
            var session = connection.CreateSession();

            connection.Start();
            var dest = session.GetQueue(queue);
            var prod = session.CreateProducer(dest);

            var outgoingMessage = prod.CreateTextMessage($"{DateTime.Now.ToString("yyyyMMddHHmmss")}: Hello World!");
            prod.Send(outgoingMessage);
            outgoingMessage.ClearBody();
            prod.Close();

            var consumer = session.CreateConsumer(dest);
            var incomingMessage = consumer.Receive() as ITextMessage;
            Console.WriteLine("Received: " + incomingMessage.Text);

            session.Close();

            if (connection.IsStarted)
                connection.Close();
        }

        private static string GetAddress(string scheme, string host, int port)
        {
            return $"{scheme}://{host}:{port}";
        }
    }
}
