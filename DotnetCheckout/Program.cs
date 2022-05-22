using DotnetCheckout.Contracts;
using DotnetCheckout.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add as a singleton because it has internal state.
// A real implementation just be a service with a data layer for persistence.
builder.Services.AddSingleton<IBasketManager, BasketManager>();

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