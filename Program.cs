using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Ocorpus.AuthorizationService.Middlewares;
using OCorpus.AuthorizationService.Contexts;
using OCorpus.AuthorizationService.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwagger();
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();

