using System;
using System.Threading;
using Azure.Storage.Queues;

namespace PrintMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            const string queueName = "test-queue";

            QueueClient client = new QueueClient(connectionString, queueName);
            var message = client.ReceiveMessage();

            if (message.Value != null)
            {
                Console.WriteLine(message.Value.Body);
                client.DeleteMessage(message.Value.MessageId, message.Value.PopReceipt);
            }
            else
            {
                Console.WriteLine("No message");
            }

            Thread.Sleep(2000);
        }
    }
}
