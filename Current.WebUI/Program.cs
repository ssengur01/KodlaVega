var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();


builder.Services.AddHttpClient("CurrentServiceApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7227/");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
  
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
