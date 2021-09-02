 namespace Test.Api
{
	using Application.Abstract;
	using Application.Implements;
	using CustomExceptionMiddleware;
	using Filters;
	using FluentValidation.AspNetCore;
	using Infrastructure.Extensions;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;
	using System;
	using System.Reflection;

	/// <summary>
	/// Class Startup.
	/// </summary>

	public class Startup
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Startup" /> class.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		/// <summary>
		/// Gets the configuration.
		/// </summary>
		/// <value>The configuration.</value>
		public IConfiguration Configuration { get; }

		/// <summary>
		/// Configures the services.
		/// </summary>
		/// <param name="services">The services.</param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc(options =>
			{
				options.Filters.Add<ValidatorActionFilter>();
			}).AddFluentValidation(options =>
			{
				options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
			});

			ConfigureServicesAdd(services);
		}

		/// <summary>
		/// Configures the service add.
		/// </summary>
		/// <param name="services">The services.</param>
		public void ConfigureServicesAdd(IServiceCollection services)
		{
			services.AddDbContexts(Configuration);

			AddApplicationService(services);

			services.AddServicesRepositories();

			services.AddSwagger($"{Assembly.GetExecutingAssembly().GetName().Name}.xml");

			services.AddCors(o => o.AddPolicy("AllowClientApp", builder =>
			{
				builder.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader();
			}));

			services.AddResponseCaching();
		}

		/// <summary>
		/// Configures the specified application.
		/// </summary>
		/// <param name="app">The application.</param>
		/// <param name="env">The env.</param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("swagger/v1/swagger.json", "V1");
				options.RoutePrefix = string.Empty;
				options.DefaultModelsExpandDepth(-1);
			});

			app.UseCors("AllowClientApp");
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseMiddleware<ExceptionMiddleware>();
			app.UseEndpoints(endpoints => endpoints.MapControllers());
		}

		/// <summary>
		/// Adds the application service.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <returns>IServiceCollection.</returns>
		public void AddApplicationService(IServiceCollection services)
		{
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IIdentificationTypeService, IdentificationTypeService>();
			services.AddTransient<IMunicipioService, MunicipioService>();
		}
	}
}