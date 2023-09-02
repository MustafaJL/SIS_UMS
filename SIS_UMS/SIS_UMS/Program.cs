using SIS_UMS.DatabaseHelper.Interface;
using SIS_UMS.DatabaseHelper.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Load environment variables from .env file
DotNetEnv.Env.Load();

builder.Services.AddControllersWithViews();

// Register the database connection string from the environment
var connectionString = DotNetEnv.Env.GetString("DB_CONNECTION_STRING");
builder.Configuration["ConnectionStrings:Default"] = connectionString;

builder.Services.AddScoped<IStudentRepository, StudentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
