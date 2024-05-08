using BackendPw;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Data.SqlClient;
namespace BasicApi.Entity
{
    public class PWDbContext : DbContext
    {

        public PWDbContext() : base()
        {

        }

        public PWDbContext(DbContextOptions<PWDbContext> options)  : base(options)
        { 

        }
        static IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        public static IConfigurationRoot Configuration = builder.Build();

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(Configuration.GetConnectionString("PWEntities"));
            base.OnConfiguring(dbContextOptionsBuilder);
        }


    
    }
}
