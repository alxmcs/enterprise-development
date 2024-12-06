using AutoMapper;
using WebApi;
using System.Reflection;
using MediaLibrary.Classes;
using MediaLibrary.Classes.IRepositories;
using MediaLibrary.Classes.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

// Регистрация фабрики для DbContext
builder.Services.AddSingleton<IMediaLibraryDbContextFactory, MediaLibraryDbContextFactory>();

// Настройка контекста базы данных с использованием фабрики
builder.Services.AddScoped<MediaLibraryDbContext>(provider =>
{
    var factory = provider.GetRequiredService<IMediaLibraryDbContextFactory>();
    return factory.CreateDbContext();
});

// Настройка сервисов
ConfigureServices(builder.Services);

var app = builder.Build();

// Конфигурация среды
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Использование HTTPS и маршрутизация контроллеров
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

/// <summary>
/// Метод для настройки всех сервисов
/// </summary>
/// <param name="services"></param>
void ConfigureServices(IServiceCollection services)
{
    // Добавление поддержки контроллеров
    services.AddControllers();

    // Настройка Swagger
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(options =>
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
    });

    // Регистрация репозиториев
    services.AddSingleton<IRepositoryAlbum, RepositoryAlbum>();
    services.AddSingleton<IRepositoryArtist, RepositoryArtist>();
    services.AddSingleton<IRepositoryGenre, RepositoryGenre>();
    services.AddSingleton<IRepositoryTrack, RepositoryTrack>();
    services.AddSingleton<IRepositoryParticipationArtistGenre, RepositoryParticipationArtistGenre>();

    // Регистрация сервисов
    services.AddSingleton<IServiceAlbum, ServiceAlbum>();
    services.AddSingleton<IServiceArtist, ServiceArtist>();
    services.AddSingleton<IServiceGenre, ServiceGenre>();
    services.AddSingleton<IServiceTrack, ServiceTrack>();
    services.AddSingleton<IServiceParticipationArtistGenre, ServiceParticipationArtistGenre>();

    // Настройка AutoMapper
    var mapperConfig = new MapperConfiguration(config => config.AddProfile(new Mapping()));
    IMapper? mapper = mapperConfig.CreateMapper();
    services.AddSingleton(mapper);
}