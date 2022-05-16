using Basket.API.GrpcServices;
using Discount.Grpc.Protos;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.API
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddMassTransitServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(config =>
            {
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration["EventBusSettings:HostAddress"]);
                });
            });

            services.AddMassTransitHostedService();

            return services;
        }

        public static IServiceCollection AddGrpcServises(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>
               (o => o.Address = new Uri(configuration["GrpcSettings:DiscountUrl"]));
            services.AddScoped<DiscountGrpcService>();

            return services;
        }
    }
}
