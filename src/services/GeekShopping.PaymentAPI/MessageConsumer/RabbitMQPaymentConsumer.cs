using GeekShopping.PaymentAPI.Messages;
using GeekShopping.PaymentProcessor;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace GeekShopping.PaymentAPI.MessageConsumer
{
    public class RabbitMQCheckoutConsumer : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IProcessPayment _processPayment;

        public RabbitMQCheckoutConsumer(IProcessPayment processPayment)
        {
            _processPayment = processPayment;
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "admin",
                Password = "passw123"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "checkoutqueue", false, false, false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                PaymentMessage vo = JsonSerializer.Deserialize<PaymentMessage>(content);
                ProcessPayment(vo).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume("checkoutqueue", false, consumer);
            return Task.CompletedTask;
        }

        private async Task ProcessPayment(PaymentMessage vo)
        {
                

            try
            {
                //_rabbitMQMessageSender.SendMessage(payment, "orderpaymentprocessqueue");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
