using EventSourcingApp.Core.Events;
using EventSourcingApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var eventstoreConnStr = builder.Configuration.GetConnectionString("eventstore");
builder.Services.AddSingleton<IEventSerializer>(new JsonEventSerializer(new[]
            {
                typeof(CreatedTask).Assembly
            })).AddEventStore(eventstoreConnStr);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
