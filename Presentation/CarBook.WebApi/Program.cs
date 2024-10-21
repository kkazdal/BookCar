using CarBook.Application.Features.CQRS.Handlers.AboutHandler;
using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<CarBookContext>();

builder.Services.AddScoped<GetAboutByIdQueryHandle>();
builder.Services.AddScoped<GetAboutQueryHandle>();
builder.Services.AddScoped<UpdateAboutHandle>();
builder.Services.AddScoped<RemoveAboutHandle>();
builder.Services.AddScoped<CreateAboutHandle>();

builder.Services.AddScoped<GetBannerByIdQueryHandle>();
builder.Services.AddScoped<GetBannerQueryHandle>();
builder.Services.AddScoped<UpdateBannerHandle>();
builder.Services.AddScoped<RemoveBannerHandle>();
builder.Services.AddScoped<CreateBannerHandle>();

builder.Services.AddScoped<GetBrandByIdQueryHandle>();
builder.Services.AddScoped<GetBrandQueryHandle>();
builder.Services.AddScoped<UpdateBrandHandle>();
builder.Services.AddScoped<RemoveBrandHandle>();
builder.Services.AddScoped<CreateBrandHandle>();

builder.Services.AddControllers(); // <-- Controller'ları ekledik
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers(); // Controller rotalarını uygulamaya dahil eder
app.Run();
