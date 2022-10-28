using Entities;
using Microsoft.EntityFrameworkCore;using WebAPI.Apis;
using WebAPI.Controls;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder.Services);

var app = builder.Build();

Configure(app);

var apis = app.Services.GetServices<IApi>();
foreach(var api in apis)
{
    if (api is null) throw new InvalidProgramException("Api not found");
    api.Register(app);
}

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    
    services.AddDbContext<Db>(options
        => options.UseNpgsql(builder.Configuration.GetConnectionString("connectionString")));

    services.AddScoped<IProfessionControl, ProfessionControl>();
    services.AddTransient<IApi, ProfessionApi>();
}

void Configure(WebApplication webapp)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
    webapp.UseHttpsRedirection();
}