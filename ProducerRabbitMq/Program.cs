using MassTransit;
using ProducerRabbitMq;
using ProducerRabbitMq.Repositories;
using ProducerRabbitMq.Settings;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((ctx, cfg) =>
    {
        var rabbitMqSetting = configuration.GetSection(RabbitMqOptions.Config).Get<RabbitMqOptions>();
        cfg.Host(rabbitMqSetting.Host,"/", host =>
        {
            host.Username(rabbitMqSetting.Username);
            host.Password(rabbitMqSetting.Password);
        });
        cfg.ConfigureEndpoints(ctx, new KebabCaseEndpointNameFormatter("Producer",false));
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();