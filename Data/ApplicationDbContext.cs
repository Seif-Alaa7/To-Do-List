using Microsoft.EntityFrameworkCore;
using TaskToDoList.Models;

namespace TaskToDoList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<List> Lists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var Builder = new ConfigurationBuilder().AddJsonFile
            ("appsettings.json", true, true).Build();
            var Connection = Builder.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(Connection);
        }
    }
}
