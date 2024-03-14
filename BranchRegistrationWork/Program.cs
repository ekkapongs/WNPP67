using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BranchRegistrationWork.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<BranchRegistrationWorkContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BranchRegistrationWorkContext") ?? throw new InvalidOperationException("Connection string 'BranchRegistrationWorkContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
