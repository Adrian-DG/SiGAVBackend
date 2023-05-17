using Application.DataAccess;

namespace API.Services
{
    public static class ApplicationServices
	{
		public static IServiceCollection GetApplicationServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
		{
			services.AddScoped(typeof(ISpecifaction<>), typeof(Specification<>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.GetDatabaseService(configuration, environment);
			services.GetAuthService(configuration);
			services.AddSingleton(typeof(GoogleSheetHelper));

			return services;
		}
	}
}
