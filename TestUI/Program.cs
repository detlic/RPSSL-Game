using TestUI.Services;
using TestUI.Services.IService;
using TestUI.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IGameService, GameService>();
builder.Services.AddHttpClient<IChoiceService, ChoiceService>();

builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IChoiceService, ChoiceService>();
builder.Services.AddScoped<ICommunicationService, CommunicationService>();


ApiBasic.ChoiceAPIBase = builder.Configuration["ServiceUrls:ChoicesAPI"];
ApiBasic.PlayAPIBase = builder.Configuration["ServiceUrls:PlayAPI"];
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
