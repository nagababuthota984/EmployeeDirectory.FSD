using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Data.DataConcerns;
using EmployeeDirectory.Domain.Providers;
using EmployeeDirectory.Domain.Repositories;
using EmployeeDirectory.Infra.Extensions;
using Mapster;
using MapsterMapper;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot configuration = new ConfigurationBuilder()
                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                            .AddJsonFile("appsettings.json")
                            .Build();

// Add services to the container.
builder.Services.AddControllersWithViews();

//mapster
var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
typeAdapterConfig.Scan(Assembly.GetExecutingAssembly());
var mapperConfig = new Mapper(typeAdapterConfig);
builder.Services.AddSingleton<IMapper>(mapperConfig);

builder.Services.ConfigureDbContext(configuration);

builder.Services.AddScoped<IRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IRepository<Department>, DepartmentRepository>();
builder.Services.AddScoped<IRepository<JobTitle>, JobTitleRepository>();
builder.Services.AddScoped<IRepository<Office>, OfficeRepository>();

builder.Services.AddTransient<IEmployeeProvider, EmployeeProvider>();
builder.Services.AddTransient<IDepartmentProvider, DepartmentProvider>();
builder.Services.AddTransient<IOfficeProvider, OfficeProvider>();
builder.Services.AddTransient<IJobTitleProvider, JobTitleProvider>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
