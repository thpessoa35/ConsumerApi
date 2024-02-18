using consumerApiUseCase;
using iConsumerApi;

using IntegrationApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IConsumerApi, ConsumerApi>();


builder.Services.AddSingleton<ConsumerApiUseCase>();

builder.Services.AddSingleton<ConsumerApiGetIdUseCase>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
