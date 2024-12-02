using DIPatternDemo.Data;
using DIPatternDemo.Repositories;
using DIPatternDemo.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var conn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(op=>op.UseSqlServer(conn));

builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();

builder.Services.AddScoped<IStudentRepo,StudentRepo>();
builder.Services.AddScoped<IStudentServices,StudentServices>();

builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();

builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductServices, ProductServices>();

builder.Services.AddScoped<IRegistrationRepo, RegistrationRepo>();
builder.Services.AddScoped<IRegistrationServices, RegistrationServices>();


//for cookies
//builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


//configuration of session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//for session
app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
