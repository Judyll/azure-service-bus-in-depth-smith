using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleBrokeredMessaging.Receiver
{
    class ReceiverConsole
    {
        //ToDo: Enter a valid Serivce Bus connection string
        static readonly string _serviceBusConnectionString = "Endpoint=sb://judyllsamplequeue.servicebus.windows.net/;SharedAccessKeyName=testpolicy;SharedAccessKey=6lB3g12Iw4w7SrWCscTmiLl6g3BYdzRdPOO9HxP6jXw=";
        static readonly string _queueName = "testqueue1";
        static void Main(string[] args)
        {
            // Create a queue client
            var queueClient = new QueueClient(_serviceBusConnectionString, _queueName);

            // Create a message handler to receive messages
            queueClient.RegisterMessageHandler(ProcessMessageAsync, HandleExceptionAsync);

            // When we register our message handler the above, the messages we received
            // will be on a different thread that is why we will see this "Presss enter to exist."
            // before the messages.
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();

            // Close the client
            queueClient.CloseAsync().Wait();
        }
        private static Task HandleExceptionAsync(ExceptionReceivedEventArgs arg)
        {
            throw new NotImplementedException();
        }
        private static async Task ProcessMessageAsync(Message message, CancellationToken token)
        {
            //Retrieve the content from the message body
            var content = Encoding.UTF8.GetString(message.Body);
            Console.WriteLine($"Received: {content}");
        }
    }
}
