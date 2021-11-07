namespace RestApi.Utilities
{
	[Microsoft.AspNetCore.Mvc.ApiController]
	[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
	public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
	{
		public ControllerBase(Rez.Application.ICommandBus commandBus) : base()
		{
			CommandBus = commandBus;
		}

		protected Rez.Application.ICommandBus CommandBus { get; }
	}
}
