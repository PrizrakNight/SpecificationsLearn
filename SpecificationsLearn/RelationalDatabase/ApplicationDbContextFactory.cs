using Microsoft.EntityFrameworkCore;
using System;

namespace SpecificationsLearn.RelationalDatabase
{
    public enum DataProvider { Sqlite, InMemory, Mssql }

    public static class ApplicationDbContextFactory
    {
        public static ApplicationDbContext CreateNew(DataProvider dataProvider, string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            switch (dataProvider)
            {
                case DataProvider.Sqlite:

                    optionsBuilder.UseSqlite(connectionString);

                    break;

                case DataProvider.InMemory:

                    optionsBuilder.UseInMemoryDatabase(connectionString);

                    break;

                case DataProvider.Mssql:

                    optionsBuilder.UseSqlServer(connectionString);

                    break;

                default: throw new InvalidOperationException("Unknown data provider type");
            }

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
