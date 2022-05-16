using Basket.API;
using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Discount.Grpc.Protos;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddStackExchangeRedisCache(option =>
{
    option.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString");
});
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
    //config.ErrorResponses = new IErrorResponseProvider();
    config.ApiVersionReader = ApiVersionReader.Combine(
        new HeaderApiVersionReader("X-version"),
        new QueryStringApiVersionReader("api-version"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();

// MassTransit-RabbitMQ Configuration
builder.Services.AddMassTransitServices(builder.Configuration);

//grpc
builder.Services.AddGrpcServises(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
