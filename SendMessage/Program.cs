using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Queues;

namespace SendMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = args[0];
            const string queueName = "test-queue";
            int numberOfMessagesToSend = int.Parse(args[1]);

            Console.WriteLine($"Sending {numberOfMessagesToSend} to Queue");

            var random = new Random();
            var inc = 0;

            QueueClient client = new QueueClient(connectionString, queueName);
            var tasks = new List<Task>();

            while (inc < numberOfMessagesToSend)
            {
                tasks.Add(client.SendMessageAsync($"Random number is {random.Next(1000)}"));
                inc++;
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Send Complete");
        }
    }
}
