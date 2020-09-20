using Microsoft.EntityFrameworkCore;
using PhoneBook.Data.Entities;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace PhoneBook.Data.Context
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options)
        {

        }

        public DbSet<Entities.PhoneBook> PhoneBook { get; set; }

        public DbSet<Entry> Entry { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasPostgresExtension("uuid-ossp")
                .Entity<Entities.PhoneBook>().ToTable("PhoneBook")
                .Property(x => x.ID).HasDefaultValueSql("uuid_generate_v1()");
                
            modelBuilder
                .HasPostgresExtension("uuid-ossp")
                .Entity<Entry>().ToTable("Entry")
                
                .Property(x => x.ID).HasDefaultValueSql("uuid_generate_v1()");
        }
    }
}
