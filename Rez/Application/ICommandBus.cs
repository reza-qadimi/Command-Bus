namespace Rez.Application
{
	public interface ICommandBus
	{
		void Send<T>(T command) where T : ICommand;

		System.Threading.Tasks.Task
			SendAsync<T>(T command) where T : ICommand;

		void Publish<T>(T command) where T : ICommand;

		System.Threading.Tasks.Task
			PublishAsync<T>(T command) where T : ICommand;
	}
}
