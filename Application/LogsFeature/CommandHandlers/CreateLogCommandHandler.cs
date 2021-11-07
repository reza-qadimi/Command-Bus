namespace Application.LogsFeature.CommandHandlers
{
	public class CreateLogCommandHandler :
		Rez.Application.ICommandHandler<Contract.Logs.LogCommand>
	{
		public void Handle(Contract.Logs.LogCommand command)
		{
			if (command is null)
			{
				return;
			}
			else
			{
				// Working With Database and...

				string message = null;

				if (string.IsNullOrWhiteSpace(value: command.Message) is false)
				{
					message =
						command.Message.ToUpper();
				}

				System.Console.WriteLine(value: message);
			}
		}

		public async
			System.Threading.Tasks.Task
			HandleAsync(Contract.Logs.LogCommand command)
		{
			await System.Threading.Tasks.Task.Run(() =>
			{
				if (command is null)
				{
					return;
				}
				else
				{
					// Working With Database and...

					string message = null;

					if (string.IsNullOrWhiteSpace(value: command.Message) is false)
					{
						message =
							command.Message.ToUpper();
					}

					System.Console.WriteLine(value: message);
					System.Diagnostics.Debug.WriteLine(value: message);
				}
			});
		}
	}
}
