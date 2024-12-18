using CarBook.Application.Features.CQRS.Handlers.AboutHandler;
using CarBook.Application.Features.CQRS.Handlers.Car;
using CarBook.Application.Features.CQRS.Handlers.ContactHandler;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarRespositories;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;
using CarBook.Application.Services;
using CarBook.Application.Interfaces.BlogRepositories;
using CarBook.Persistence.Repositories.BlogRepositories;
using CarBook.Application.Features.CQRS.Handlers.Category;
using CarBook.Application.Interfaces.CategoryRepositories;
using CarBook.Persistence.Repositories.CategoryRepositories;
using CarBook.Persistence.Repositories.TagRepositories;
using CarBook.Application.Interfaces.TagRepositories;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Persistence.Repositories.CommentRepositories;
using CarBook.Application.Interfaces.StatisticsInterface;
using CarBook.Persistence.Repositories.StatisticsRepositories;
using CarBook.Application.Interfaces.RentACarInterface;
using CarBook.Persistence.Repositories.RentACarRespositories;
using CarBook.Persistence.Repositories.CarPricingRepositories;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CommentRepositories;
using CarBook.Application.Interfaces.CarFeaturesRepositories;
using CarBook.Persistence.Repositories.CarFeaturesRepositories;
using CarBook.Application.Interfaces.CarDescriptionRepositories;
using CarBook.Persistence.Repositories.CarDescriptionRepositories;
using CarBook.Persistence.Repositories.ReviewRepositories;
using CarBook.Application.Interfaces.ReviewRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CarBook.Application.Tools;
using CarBook.WebApi.Hubs;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder
            .WithOrigins("http://localhost:5001")  // Yalnızca bu kaynağa izin ver(WebUI)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();  // Kimlik doğrulama bilgilerine izin ver
    });
});
builder.Services.AddSignalR();

// Appsettings dosyasından JWT ayarlarını okuyoruz
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

// JwtService'i DI container'a ekliyoruz
builder.Services.AddSingleton<JwtService>(provider =>
{
    var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
    return new JwtService(jwtSettings.IssuerSigningKey, jwtSettings.ValidIssuer, jwtSettings.ValidAudience);
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidAudience = jwtSettings.ValidAudience,
            ValidIssuer = jwtSettings.ValidIssuer,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.IssuerSigningKey)),
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:5002") // İzin vermek istediğiniz kaynakları buraya ekleyin
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
builder.Services.AddScoped(typeof(ITagRepository), typeof(TagRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
builder.Services.AddScoped(typeof(IStaticticRepository), typeof(StatisticRepository));
builder.Services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ICommentRepository), typeof(CommentRepositoryMediator));
builder.Services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeaturesRepository));
builder.Services.AddScoped(typeof(ICarDescriptionRepository), typeof(CarDescriptionRepository));
builder.Services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));


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

builder.Services.AddScoped<GetCarsWithPricingsHandler>();
builder.Services.AddScoped<GetCarsByNumberHandle>();
builder.Services.AddScoped<GetCarByIdQueryHandle>();
builder.Services.AddScoped<GetCarQueryHandle>();
builder.Services.AddScoped<GetCarListWithBrandHandle>();
builder.Services.AddScoped<UpdateCarHandle>();
builder.Services.AddScoped<RemoveCarHandle>();
builder.Services.AddScoped<CreateCarHandle>();

builder.Services.AddScoped<GetCategoryByBlogNumberHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandle>();
builder.Services.AddScoped<GetCategoryQueryHandle>();
builder.Services.AddScoped<UpdateCategoryHandle>();
builder.Services.AddScoped<RemoveCategoryHandle>();
builder.Services.AddScoped<CreateCategoryHandle>();

builder.Services.AddScoped<GetContactByIdQueryHandle>();
builder.Services.AddScoped<GetContactQueryHandle>();
builder.Services.AddScoped<UpdateContactHandle>();
builder.Services.AddScoped<RemoveContactHandle>();
builder.Services.AddScoped<CreateContactHandle>();

builder.Services.AddSaveApplicationService(builder.Configuration);//Mediator için dependency injection yapıldı

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

// CORS politikasını ekleyin
app.UseCors("AllowSpecificOrigins");
app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers(); // Controller rotalarını uygulamaya dahil eder

app.MapHub<CarHub>("/carhub").RequireCors("CorsPolicy");

app.Run();
