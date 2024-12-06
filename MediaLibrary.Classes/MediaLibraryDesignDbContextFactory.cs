using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebApi;

namespace MediaLibrary.Classes;
public class MediaLibraryDesignDbContextFactory : IDesignTimeDbContextFactory<MediaLibraryDbContext>
{
    public MediaLibraryDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MediaLibraryDbContext>();
        var connectionString = "Host=localhost;Port=3306;Database=MediaLibrary;User=root;Password=1234;";
        optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 39)));

        return new MediaLibraryDbContext(optionsBuilder.Options);
    }
}
