global using Judah_Kahler_Portfolio.Services.EmailService;
global using Judah_Kahler_Portfolio.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(    
    name: "default",    
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


