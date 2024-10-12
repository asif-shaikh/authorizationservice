using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OCorpus.AuthorizationService.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<OCorpusDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OCorpusDbContext"))
);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OCorpus API", Version = "v1" });
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "OCorpus.AuthorizationService.xml"));
});

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseAuthorization();

app.MapControllers();


app.Run();

