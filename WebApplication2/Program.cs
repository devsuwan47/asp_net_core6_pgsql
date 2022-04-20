using WebApplication2.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// ApplicationDbContext ------------------------------------------
var pg_constring = builder.Configuration.GetConnectionString("SandboxConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(pg_constring));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // 1
app.UseAuthorization(); // 2

//app.MapControllers();
//app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
