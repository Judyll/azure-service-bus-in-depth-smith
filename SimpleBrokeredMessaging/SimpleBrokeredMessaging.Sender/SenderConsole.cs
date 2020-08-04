using Microsoft.Azure.ServiceBus;
using System;
using System.Text;

namespace SimpleBrokeredMessaging.Sender
{
    class SenderConsole
    {
        //ToDo: Enter a valid Serivce Bus connection string
        static readonly string _serviceBusConnectionString = "Endpoint=sb://judyllsamplequeue.servicebus.windows.net/;SharedAccessKeyName=testpolicy;SharedAccessKey=6lB3g12Iw4w7SrWCscTmiLl6g3BYdzRdPOO9HxP6jXw=";
        static readonly string _queueName = "testqueue1";

        static void Main(string[] args)
        {

            // Create a queue client
            var queueClient = new QueueClient(_serviceBusConnectionString, _queueName);

            // Send some messages
            for (int i = 0; i < 10; i++)
            {
                var content = $"Message: { i }";

                // Encode the message and send it to the service bus queue
                var messsage = new Message(Encoding.UTF8.GetBytes(content));
                queueClient.SendAsync(messsage).Wait();

                Console.WriteLine("Sent: " + i);
            }

            // Close the client
            queueClient.CloseAsync().Wait();            

            Console.WriteLine("Sent messages...");
            Console.ReadLine();
        }
    }
}
