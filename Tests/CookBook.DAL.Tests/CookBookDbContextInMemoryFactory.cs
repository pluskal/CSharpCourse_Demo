using CookBook.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Tests
{
    public class CookBookDbContextInMemoryFactory : ICookBookDbContextFactory
    {
        public CookBookDbContext CreateDbContext(string databaseName)
        {
            var optionBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
            optionBuilder.UseInMemoryDatabase(databaseName);
            return new CookBookDbContext(optionBuilder.Options);
        }
    }
}