using EventFlow;
using EventFlow.EntityFramework.ReadStores;
using EventFlow.Extensions;
using EventFlow.ReadStores;
using Microsoft.EntityFrameworkCore;

namespace MyEventFlow.ReadStore;

public static class EFReadStoreExtensions
{
    public static IEventFlowOptions UseEntityFrameworkCoreReadModel<TReadModel, TDbContext>(
        this IEventFlowOptions eventFlowOptions)
        where TDbContext : DbContext
        where TReadModel : class, IReadModel, new()
    {
        return eventFlowOptions
            .RegisterServices(f =>
            {
                f.Register<IEntityFrameworkReadModelStore<TReadModel>,
                    EntityFrameworkCoreReadModelStore<TReadModel, TDbContext>>();
                f.Register<IReadModelStore<TReadModel>>(r =>
                    r.Resolver.Resolve<IEntityFrameworkReadModelStore<TReadModel>>());
            })
            .UseReadStoreFor<IEntityFrameworkReadModelStore<TReadModel>, TReadModel>();
    }
}