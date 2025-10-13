using CurrentService.WEBUI.Services.DocumentStrategies;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddHttpClient();

builder.Services.AddTransient<AlFatStrategy>();
builder.Services.AddTransient<SatFatStrategy>();
builder.Services.AddTransient<CarGirStrategy>();
builder.Services.AddTransient<CarCikStrategy>();
builder.Services.AddTransient<StkGirFisStrategy>();
builder.Services.AddTransient<StkCikFisStrategy>();

builder.Services.AddSingleton<DocumentStrategy>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
