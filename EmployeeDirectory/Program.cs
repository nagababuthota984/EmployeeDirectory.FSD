using EmployeeDirectory.Application.Contracts;
using EmployeeDirectory.Domain.Providers;
using EmployeeDirectory.Domain.Repositories;
using EmployeeDirectory.Infra.Extensions;

var builder = WebApplication.CreateBuilder(args);

IConfigurationRoot configuration = new ConfigurationBuilder()
                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                            .AddJsonFile("appsettings.json")
                            .Build();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.ConfigureDbContext(configuration);
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<DepartmentRepository>();
builder.Services.AddScoped<JobTitleRepository>();
builder.Services.AddScoped<OfficeRepository>();

builder.Services.AddTransient<IEmployeeProvider, EmployeeProvider>();


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
