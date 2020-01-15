using CookBook.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Tests
{
    public class DbContextInMemoryFactory : IDbContextFactory
    {
        private readonly string _databaseName;

        public DbContextInMemoryFactory(string databaseName)
        {
            _databaseName = databaseName;
        }
        public CookBookDbContext CreateDbContext()
        {
            var optionBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
            optionBuilder.UseInMemoryDatabase(_databaseName);
            return new CookBookDbContext(optionBuilder.Options);
        }
    }
}