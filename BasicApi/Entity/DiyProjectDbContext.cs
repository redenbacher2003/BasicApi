using BackendPw;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Data.SqlClient;
namespace BasicApi.Entity;

public class DiyProjectDbContext : DbContext
{

    public DiyProjectDbContext() : base()
    {

    }

    public DiyProjectDbContext(DbContextOptions<DiyProjectDbContext> options) : base(options)
    {

    }
    static IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    public static IConfigurationRoot Configuration = builder.Build();

    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
        dbContextOptionsBuilder.UseSqlServer(Configuration.GetConnectionString("DiyProjectEntities"));
        base.OnConfiguring(dbContextOptionsBuilder);
    }



}
