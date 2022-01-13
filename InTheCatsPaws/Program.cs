using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

var options = new StaticFileOptions();
var contentTypeProvider = (FileExtensionContentTypeProvider)options.ContentTypeProvider ?? new FileExtensionContentTypeProvider();
contentTypeProvider.Mappings.Add(".unityweb", "application/octet-stream");
contentTypeProvider.Mappings.Add(".data", "application/octet-stream");
options.ContentTypeProvider = contentTypeProvider;
app.UseStaticFiles(options);


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();