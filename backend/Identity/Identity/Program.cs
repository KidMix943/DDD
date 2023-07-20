using Identity.Routes;
using Identity.Infrastructure.Services;

var builder = WebApplication.CreateBuilder();

builder.Services.AddAuthorization();
builder.Services.AddJwtAuthentication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.AddIdentytiRouter();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.Run();