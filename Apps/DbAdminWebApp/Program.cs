using JJMasterData.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddJJMasterDataWeb().WithSettings(options =>
{
    options.BootstrapVersion = 5;
    options.ConnectionString = "Host=localhost;Port=5433;Database=EmploymentService;Username=postgres;Password=321";
});

var app = builder.Build();
app.UseRouting();
app.UseJJMasterDataWeb();
app.MapGet("/", () => "Hello World!");

app.Run();