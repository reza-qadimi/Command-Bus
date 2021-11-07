using Autofac;
using System.Linq;

namespace Core
{
	public class DependencyContainer : Autofac.Module
	{
		public DependencyContainer() : base()
		{
		}

		protected override
			void
			Load(Autofac.ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes
				(assemblies: typeof(Application.LogsFeature.CommandHandlers.CreateLogCommandHandler).Assembly)
				.As(serviceMapping: type => type.GetInterfaces()
				.Where(predicate: interfaceType => interfaceType.IsClosedTypeOf(typeof(Rez.Application.ICommandHandler<>))))
				.InstancePerLifetimeScope()
				;

			builder.RegisterType<Autofac.Framework.AutoFacCommandBus>()
				.As<Rez.Application.ICommandBus>().InstancePerLifetimeScope();

			base.Load(builder: builder);
		}
	}
}
