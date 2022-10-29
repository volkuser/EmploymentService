using Entities;
using Microsoft.EntityFrameworkCore;using WebAPI.Apis;
using WebAPI.Controls;
using WebAPI.Controls.Contracts;

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
    
    // logic
    services.AddScoped<IProfessionControl, ProfessionControl>();
    services.AddScoped<IEducationControl, EducationControl>();
    services.AddScoped<ISexControl, SexControl>();
    services.AddScoped<IEducationForProfessionControl, EducationForProfessionControl>();
    services.AddScoped<IPositionControl, PositionControl>();
    services.AddScoped<IEmployedControl, EmployedControl>();
    services.AddScoped<IEmployedEducationControl, EmployedEducationControl>();
    services.AddScoped<IEmployeeControl, EmployeeControl>();
    services.AddScoped<IEmployeePositionControl, EmployeePositionControl>();
    services.AddScoped<IEmployerControl, EmployerControl>();
    services.AddScoped<IVacancyControl, VacancyControl>();
    services.AddScoped<IJobApplicationControl, JobApplicationControl>();
    
    // using of logic
    services.AddTransient<IApi, ProfessionApi>();
    services.AddTransient<IApi, EducationApi>();
    services.AddTransient<IApi, SexApi>();
    services.AddTransient<IApi, EducationForProfessionApi>();
    services.AddTransient<IApi, PositionApi>();
    services.AddTransient<IApi, EmployedApi>();
    services.AddTransient<IApi, EmployedEducationApi>();
    services.AddTransient<IApi, EmployeeApi>();
    services.AddTransient<IApi, EmployeePositionApi>();
    services.AddTransient<IApi, EmployerApi>();
    services.AddTransient<IApi, VacancyApi>();
    services.AddTransient<IApi, JobApplicationApi>();
}

void Configure(WebApplication webapp)
{
    if (webapp.Environment.IsDevelopment())
    {
        webapp.UseSwagger();
        webapp.UseSwaggerUI();
    }
    
    webapp.UseHttpsRedirection();
}