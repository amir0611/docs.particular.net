using NServiceBus;

public class EndpointConfig :
    IConfigureThisEndpoint,
    AsA_Server,
    IWantCustomInitialization
{
    public void Init()
    {
        var configure = Configure.With();
        configure.DefineEndpointName("Samples.Logging.HostProfiles");
        configure.DefaultBuilder();
        configure.InMemorySagaPersister();
        configure.UseInMemoryTimeoutPersister();
        configure.InMemorySubscriptionStorage();
        configure.JsonSerializer();
    }
}