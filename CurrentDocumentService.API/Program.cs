using CurrentDocument.Application.Features.CarCikBasliks.Queries.GetCarCikBaslikById;
using CurrentDocument.Application.Features.CarCikHarekets.Queries.GetCarCikHareketById;
using CurrentDocument.Application.Features.CarGirBasliks.Queries.GetCarGirBaslikById;
using CurrentDocument.Application.Features.CarGirHarekets.Queries.GetCarGirHareketById;
using CurrentDocument.Application.Repositories;
using CurrentDocument.Application.Strategies;
using CurrentDocument.Application.Strategies.Factory;
using CurrentDocument.Infrastructure.Data;
using CurrentDocument.Persistence.Repositories;
using CurrentDocument.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IUnitOfWork, UnitOfWorks>();


builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetCarCikBaslikByIdQuery).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetCarCikHareketByIdQuery).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetCarGirBaslikByIdQuery).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetCarGirHareketByIdQuery).Assembly);
});

builder.Services.AddDbContext<CurrentDocumentDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<FirmaDonemContext>();

builder.Services.AddScoped<IStrategyFactory, StrategyFactory>();

builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();

builder.Services.AddScoped<CarGirFaturasiStrategy>();
builder.Services.AddScoped<CarCikFaturasiStrategy>();

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
