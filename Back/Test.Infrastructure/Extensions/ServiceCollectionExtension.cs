using Test.Common.Enumerations;
using Test.Infrastructure.DataAccess;
using Test.Infrastructure.Interfaces.Repositories;
using Test.Infrastructure.Repository;

namespace Test.Infrastructure.Extensions
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.OpenApi.Models;
	using System;
	using System.IO;

	/// <summary>
	/// Class ServiceCollectionExtension.
	/// </summary>

	public static class ServiceCollectionExtension
	{
		/// <summary>
		/// Adds the database contexts.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="configuration">The configuration.</param>
		/// <returns>IServiceCollection.</returns>
		public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration[ConnectionString.Test.Name];

			services.AddDbContext<TestContext>(options =>
				 options.UseSqlServer(connectionString,
				   sqlOptions =>
				   {
					   sqlOptions.EnableRetryOnFailure(
					   10,
					   TimeSpan.FromSeconds(30),
					   null);
				   })
		   );

			return services;
		}
		 
		/// <summary>
		/// Adds the services.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <returns>IServiceCollection.</returns>
		public static IServiceCollection AddServicesRepositories(this IServiceCollection services)
		{
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IIdentificationTypeRepository, IdentificationTypeRepository>();
			services.AddTransient<IMunicipioRepository, MunicipioRepository>();
			return services;
		}

		/// <summary>
		/// Adds the swagger.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="xmlFileName">Name of the XML file.</param>
		/// <returns>IServiceCollection.</returns>
		public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
		{
			services.AddSwaggerGen(doc =>
			{
				doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Prueba Tecnica ", Version = "v1" });

				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
				doc.IncludeXmlComments(xmlPath); 
			});

			return services;
		}
	}
}