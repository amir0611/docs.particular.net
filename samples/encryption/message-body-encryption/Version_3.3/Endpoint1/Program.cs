﻿using System;
using NServiceBus;
using NServiceBus.Installation.Environments;

class Program
{
    static void Main()
    {
        var configure = Configure.With();
        configure.DefineEndpointName("Samples.MessageBodyEncryption.Endpoint1");
        configure.DefaultBuilder();
        configure.RijndaelEncryptionService();
        configure.MsmqTransport();
        configure.InMemorySagaPersister();
        configure.UseInMemoryTimeoutPersister();
        configure.InMemorySubscriptionStorage();
        configure.JsonSerializer();
        configure.RegisterMessageEncryptor();
        var bus = configure.UnicastBus()
            .CreateBus()
            .Start(() => Configure.Instance.ForInstallationOn<Windows>().Install());

        var completeOrder = new CompleteOrder
        {
            CreditCard = "123-456-789"
        };
        bus.Send("Samples.MessageBodyEncryption.Endpoint2", completeOrder);

        Console.WriteLine("Message sent. Press any key to exit");
        Console.ReadLine();
    }
}