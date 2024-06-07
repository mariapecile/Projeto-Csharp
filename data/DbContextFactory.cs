using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace loja.data
{
    public class LojaDbContextFactory : IDesignTimeDbContextFactory<LojaDbContext>
    {
       public LojaDbContext CreateDbContext(string[] args)
       {
        var optionsBuilder = new DbContextOptionsBuilder<LojaDbContext>();

        //Build configuration
        IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

        var connectionStrings = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseMySql(connectionStrings, new MySqlServerVersion(new Version(8, 0 , 26)));
        
        return new LojaDbContext(optionsBuilder.Options);

       }
    }
}
