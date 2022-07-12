using EventFlow;
using EventFlow.Configuration;
using EventFlow.EntityFramework;
using EventFlow.EntityFramework.Extensions;
using EventFlow.Extensions;
using EventFlow.MsSql.Extensions;

namespace MyEventFlow.ReadStore;

public class ReadStoreModule : IModule
{
    public void Register(IEventFlowOptions eventFlowOptions)
    {
        eventFlowOptions.ConfigureEntityFramework(EntityFrameworkConfiguration.New)
            .AddDefaults(typeof(ReadStoreModule).Assembly)
            .AddDbContextProvider<MyReadStoreDbContext, MyReadStoreDbContextProvider>()
            .UseEntityFrameworkCoreReadModel<MyReadModel, MyReadStoreDbContext>();
    }
}