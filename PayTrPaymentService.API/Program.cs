using Microsoft.Extensions.Options;
using PaymentService.Application;
using PaymentService.Business;
using PaymentService.Domain.Entities;
using PaymentService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<PaynetSettings>(builder.Configuration.GetSection("Paynet"));

builder.Services.AddHttpClient<IPaynetService, PaynetPaymentService>((sp, client) =>
{
    var cfg = sp.GetRequiredService<IOptions<PaynetSettings>>().Value;
    if (!string.IsNullOrWhiteSpace(cfg.ApiBaseUrl))
        client.BaseAddress = new Uri(cfg.ApiBaseUrl);
});

builder.Services.AddScoped<PaynetManager>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("AllowWebUI", policy =>
{
    policy.WithOrigins("https://localhost:7000").AllowAnyHeader().AllowAnyMethod();
}));


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseCors("AllowWebUI");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
