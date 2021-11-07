namespace Autofac.Framework
{
	public class AutoFacCommandBus : Rez.Application.ICommandBus
	{
		public AutoFacCommandBus(Autofac.ILifetimeScope lifetimeScope)
		{
			LifetimeScope = lifetimeScope;
		}

		protected Autofac.ILifetimeScope LifetimeScope { get; }

		public void Send<T>(T command) where T : Rez.Application.ICommand
		{
			var commandHandler =
				LifetimeScope.Resolve<Rez.Application.ICommandHandler<T>>();

			commandHandler.Handle(command: command);
		}

		public async
			System.Threading.Tasks.Task
			SendAsync<T>(T command) where T : Rez.Application.ICommand
		{
			var commandHandler =
				LifetimeScope.Resolve<Rez.Application.ICommandHandler<T>>();

			await commandHandler.HandleAsync(command: command);
		}

		public void Publish<T>(T command) where T : Rez.Application.ICommand
		{
			var commandHandlers = LifetimeScope.Resolve
				<System.Collections.Generic.IEnumerable<Rez.Application.ICommandHandler<T>>>();

			foreach (var commandHandler in commandHandlers)
			{
				commandHandler.Handle(command: command);
			}
		}

		public async
			System.Threading.Tasks.Task
			PublishAsync<T>(T command) where T : Rez.Application.ICommand
		{
			var commandHandlers = LifetimeScope.Resolve
				<System.Collections.Generic.IEnumerable<Rez.Application.ICommandHandler<T>>>();

			foreach (var commandHandler in commandHandlers)
			{
				await commandHandler.HandleAsync(command: command);
			}
		}
	}
}
