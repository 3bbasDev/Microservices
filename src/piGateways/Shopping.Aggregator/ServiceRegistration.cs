using Shopping.Aggregator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Aggregator
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddHttpClientServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddHttpClient<ICatalogService, CatalogService>(c =>
                c.BaseAddress = new Uri(Configuration["ApiSettings:CatalogUrl"]));

            services.AddHttpClient<IBasketService, BasketService>(c =>
                c.BaseAddress = new Uri(Configuration["ApiSettings:BasketUrl"]));

            services.AddHttpClient<IOrderService, OrderService>(c =>
                c.BaseAddress = new Uri(Configuration["ApiSettings:OrderingUrl"]));
            return services;
        }
    }
}
