using prmToolkit.NotificationPattern;
using System.Data.Entity;
using Unity;
using Unity.Lifetime;
using XGame.Infra.Persistence;
using XGame.Infra.Persistence.Repositories;
using XGame.Infra.Persistence.Repositories.Base;
using XGame.Infra.Transactions;
using XGame.Interfaces.Repositories.Base;
using XGame.Interfaces.Services;
using XGame.Services;

namespace XGame.IoC.Unity
{
    public class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<DbContext, XGameContext>(new HierarchicalLifetimeManager());
            //UnityOfWork
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            //Serviço de Domain
            container.RegisterType<IServiceJogador, ServiceJogador>(new HierarchicalLifetimeManager());

            //Repository
            container.RegisterType(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

            container.RegisterType<IRepositoryJogador, RepositoryJogador>(new HierarchicalLifetimeManager());
        }
    }
}
