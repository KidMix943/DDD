using Messenger.Host.Route;
using Messenger.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBusinessLogic(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.AddUserRouter();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.Run();