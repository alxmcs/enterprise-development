using WebApi;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MediaLibrary.Classes;
using MediaLibrary.Classes.IRepositories;
using MediaLibrary.Classes.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ����������� ������� ��� DbContext
builder.Services.AddSingleton<IMediaLibraryDbContextFactory, MediaLibraryDbContextFactory>();

// ��������� ��������� ���� ������ � �������������� �������
builder.Services.AddScoped<MediaLibraryDbContext>(provider =>
{
    var factory = provider.GetRequiredService<IMediaLibraryDbContextFactory>();
    return factory.CreateDbContext();
});

// ��������� ��������
ConfigureServices(builder.Services);

var app = builder.Build();

// ������������ �����
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ������������� HTTPS � ������������� ������������
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

/// <summary>
/// ����� ��� ��������� ���� ��������
/// </summary>
/// <param name="services"></param>
void ConfigureServices(IServiceCollection services)
{
    // ���������� ��������� ������������
    services.AddControllers();

    // ��������� Swagger
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(options =>
    {
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
    });

    // ����������� ������������
    services.AddSingleton<IRepositoryAlbum, RepositoryAlbum>();
    services.AddSingleton<IRepositoryArtist, RepositoryArtist>();
    services.AddSingleton<IRepositoryGenre, RepositoryGenre>();
    services.AddSingleton<IRepositoryTrack, RepositoryTrack>();
    services.AddSingleton<IRepositoryParticipationArtistGenre, RepositoryParticipationArtistGenre>();

    // ����������� ��������
    services.AddSingleton<IServiceAlbum, ServiceAlbum>();
    services.AddSingleton<IServiceArtist, ServiceArtist>();
    services.AddSingleton<IServiceGenre, ServiceGenre>();
    services.AddSingleton<IServiceTrack, ServiceTrack>();
    services.AddSingleton<IServiceParticipationArtistGenre, ServiceParticipationArtistGenre>();

    // ��������� AutoMapper
    services.AddAutoMapper(typeof(Mapping));
}