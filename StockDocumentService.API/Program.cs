using Microsoft.EntityFrameworkCore;
using StockDocument.Application.Features.StkCikBasliks.Queries.GetStkCikBaslikById;
using StockDocument.Application.Features.StkCikHarekets.Queries.GetStkCikHareketById;
using StockDocument.Application.Features.StkGirBasliks.Queries.GetStkGirBaslikById;
using StockDocument.Application.Features.StkGirHarekets.Queries.GetStkGirHareketById;
using StockDocument.Application.Repositories;
using StockDocument.Application.Strategies;
using StockDocument.Application.Strategies.Factory;
using StockDocument.Infrastructure.Data;
using StockDocument.Persistence.Repositories;
using StockDocument.Persistence.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IUnitOfWork, UnitOfWorks>();


builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetStkCikBaslikByIdQuery).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetStkCikHareketByIdQuery).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetStkGirBaslikByIdQuery).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetStkGirHareketByIdQuery).Assembly);
});

builder.Services.AddDbContext<StockDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<FirmaDonemContext>();

builder.Services.AddScoped<IStrategyFactory, StrategyFactory>();

builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();

builder.Services.AddScoped<StkGirFisStrategy>();
builder.Services.AddScoped<StkCikFisStrategy>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebUI",
        policy => policy
            .WithOrigins("https://localhost:7000")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddSwaggerGen();

var app = builder.Build();


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
