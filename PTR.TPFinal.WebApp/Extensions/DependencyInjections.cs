using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PTR.TPFinal.Domain.Data;
using PTR.TPFinal.Domain.Models.Configuration;
using PTR.TPFinal.Services.DTOs.Requests;
using PTR.TPFinal.Services.Interfaces;
using PTR.TPFinal.Services.NoSQLRepositories.Implementations;
using PTR.TPFinal.Services.NoSQLRepositories.Interfaces;
using PTR.TPFinal.Services.Profiles;
using PTR.TPFinal.Services.Repositories.Implementations;
using PTR.TPFinal.Services.Repositories.Interfaces;
using PTR.TPFinal.Services.Services;
using PTR.TPFinal.Services.Validators;

namespace PTR.TPFinal.WebApp.Extensions
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ECommerceApiContext>(options => options.UseSqlServer(configuration.GetConnectionString("ECommerceAPI")));

            return services;
        }

        public static IServiceCollection AddMongoDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<MongoDbConfiguration>(options =>
            {
                options.ConnectionString = configuration["MongoDbSettings:ConnectionString"]!;
                options.Database = configuration["MongoDbSettings:DatabaseName"]!;
            });

            services.AddSingleton<MongoDbContext>();
            services.AddSingleton<MongoDbInitializer>();

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var initializer = scope.ServiceProvider.GetRequiredService<MongoDbInitializer>();
                initializer.Initialize();
            }

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<AreaProfile>();
                cfg.AddProfile<ClientProfile>();
                cfg.AddProfile<EmployeeProfile>();
                cfg.AddProfile<ProductProfile>();
                cfg.AddProfile<ShoppingCartProfile>();
            });

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            services.AddScoped<IValidator<CreateProductRequestDto>, CreateProductRequestDtoValidator>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
