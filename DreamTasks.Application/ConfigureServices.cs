using Application.Contracts.Services;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // use mapper (Mapster)
        //var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        //typeAdapterConfig.Scan(AppDomain.CurrentDomain.GetAssemblies());
        ////builder.Services.AddSingleton(typeAdapterConfig);
        //services.AddSingleton<IMapper>(new Mapper(typeAdapterConfig));

		var config = TypeAdapterConfig.GlobalSettings;
		// Scan all mapping configurations (IRegister)
		config.Scan(AppDomain.CurrentDomain.GetAssemblies());
		services.AddSingleton(config);
		services.AddScoped<IMapper, Mapper>();

		//add application services injection here

        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IProjectTaskService, ProjectTaskService>();

		return services;
    }
}
