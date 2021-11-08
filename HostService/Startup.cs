using Autofac;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Server
{
	public class Startup : object
	{
		public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
		{
			Configuration = configuration;
		}

		protected Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

		public void
			ConfigureServices
			(Microsoft.Extensions.DependencyInjection.IServiceCollection services)
		{
			services.AddControllers();
		}

		public void Configure
			(Microsoft.AspNetCore.Builder.IApplicationBuilder app,
			Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		public void ConfigureContainer(Autofac.ContainerBuilder builder)
		{
			builder.RegisterModule(new Core.DependencyContainer());
		}
	}
}
