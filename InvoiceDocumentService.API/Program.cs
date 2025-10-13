using Document.Application.Features.AlFatBasliks.Queries.GetAlFatBaslikById;
using Document.Application.Features.AlFatHarekets.Queries.GetAlFatHareketById;
using Document.Application.Features.SatFatBasliks.Queries.GetSatFatBaslikById;
using Document.Application.Features.SatFatHarekets.Queries.GetSatFatHareketById;
using Document.Application.Repositories;
using Document.Application.Strategies;
using Document.Application.Strategies.Factory;
using Document.Infrastructure.Data;
using Document.Persistence.Repositories;
using Document.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetAlFatBaslikByIdQuery).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetAlFatHareketByIdQuery).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetSatFatBaslikByIdQuery).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetSatFatHareketByIdQuery).Assembly);
});

builder.Services.AddScoped<FirmaDonemContext>();

builder.Services.AddScoped<IStrategyFactory, StrategyFactory>();

builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();

builder.Services.AddScoped<AlisFaturasiStrategy>();
builder.Services.AddScoped<SatisFaturasiStrategy>();
builder.Services.AddScoped<AlisIadeStrategy>();
builder.Services.AddScoped<SatisIadeStrategy>();
builder.Services.AddScoped<ArcAlisIadeFaturasýStrategy>();
builder.Services.AddScoped<ArcSatisFaturasiIadeStrategy>();
builder.Services.AddScoped<PosFaturasiStrategy>();
builder.Services.AddScoped<PosFaturasý2Strategy>();
builder.Services.AddScoped<PosFisStrategy>();
builder.Services.AddScoped<ImfAlisFaturasiStrategy>();
builder.Services.AddScoped<ImfAlisIadeFaturasiStrategy>();
builder.Services.AddScoped<ImfSatisFaturasiStrategy>();
builder.Services.AddScoped<ImfSatisIadeFaturasiStrategy>();
builder.Services.AddScoped<PesinAlisFaturasiStrategy>();
builder.Services.AddScoped<PesinAlisIadeStrategy>();
builder.Services.AddScoped<PesinSatisFaturasiStrategy>();
builder.Services.AddScoped<PesinSatisIadeStrategy>();
builder.Services.AddScoped<ProformaFaturasiStrategy>();


builder.Services.AddDbContext<DocumentDbContext>(options =>
    options.UseSqlServer(connectionString));


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
