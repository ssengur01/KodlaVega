using Current.Application.Repositories;
using Current.Infrastructure.Data;
using Current.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connection string
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddSingleton<IConnectionMultiplexer>(sp => 
{ 
    var configuration = ConfigurationOptions.Parse("localhost:6379", true); 
    return ConnectionMultiplexer.Connect(configuration); 
});

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
    options.InstanceName = "CariApp:";
});


// Firma/Dönem context
builder.Services.AddScoped<FirmaDonemContext>();

builder.Services.AddScoped<RedisCacheRepository>();


// DbContext
builder.Services.AddDbContext<CurrentDbContext>(options =>
    options.UseSqlServer(connectionString));


// Repository kayýtlarý
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebUI",
        policy => policy
            .WithOrigins("https://localhost:7000")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();


//app.Use(async (context, next) =>
//{
 //   var firmaContext = context.RequestServices.GetService<FirmaDonemContext>();
   // firmaContext.FirmaInd = "101";
    //firmaContext.DonemInd = "0003";
    //await next();
//});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowWebUI");
app.UseAuthorization();
app.MapControllers();
app.Run();
