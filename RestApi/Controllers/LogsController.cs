namespace RestApi.Controllers
{
	public class LogsController : Utilities.ControllerBase
	{
		public LogsController(Rez.Application.ICommandBus commandBus) : base(commandBus: commandBus)
		{
		}

		//[Microsoft.AspNetCore.Mvc.HttpPost(template: "Send")]
		//public
		//	void
		//	SendCommand(Contract.Logs.LogCommand command)
		//{
		//	CommandBus.Send(command: command);
		//}

		[Microsoft.AspNetCore.Mvc.HttpPost]
		public async
			System.Threading.Tasks.Task
			SendCommandAsync(
			[Microsoft.AspNetCore.Mvc.FromBody]
			Application.Contract.Logs.LogCommand command)
		{
			await CommandBus.SendAsync(command: command);
		}
	}
}
