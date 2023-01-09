using ECalendar.Web.Api.Brokers.DateTimes;
using ECalendar.Web.Api.Brokers.Logings;
using ECalendar.Web.Api.Brokers.Storages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StorageBroker>();

builder.Services.AddScoped<IStorageBroker, StorageBroker>();
builder.Services.AddTransient<ILogingBroker, LogingBroker>();
builder.Services.AddTransient<IDateTimeBroker, DateTimeBroker>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();