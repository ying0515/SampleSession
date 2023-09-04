using Autofac.Extensions.DependencyInjection;
using Autofac;
using SampleSession.Configs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".SampleSession.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.IsEssential = true;
});

//初始化並建立一個實例
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
//註冊autofac這個容器
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacConfig()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
