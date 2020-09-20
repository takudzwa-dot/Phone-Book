using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PhoneBook.Data.Context;
using System.IO;

namespace PhoneBook.Data.Migration
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        class PhoneBookContextFactory : IDesignTimeDbContextFactory<PhoneBookContext>
        {
            private IConfigurationRoot _config;

            public PhoneBookContextFactory()
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

                _config = builder.Build();
            }

           PhoneBookContext IDesignTimeDbContextFactory<PhoneBookContext>.CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<PhoneBookContext>();
                optionsBuilder.UseNpgsql(_config.GetConnectionString("PhoneBookContext"));

                return new PhoneBookContext(optionsBuilder.Options);
            }
        }
    }
}
