using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
$if$($UseWebAssembly$ == True)
using Uno.Wasm.Bootstrap.Server;
$endif$

namespace $ext_safeprojectname$.Server
{
	public sealed class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();

			var app = builder.Build();

			// Configure the HTTP request pipeline.

			app.UseAuthorization();

$if$($UseWebAssembly$ == True)
			app.UseUnoFrameworkFiles();
			app.MapFallbackToFile("index.html");
$endif$

			app.MapControllers();
			app.UseStaticFiles();

			app.Run();
		}
	}
}
