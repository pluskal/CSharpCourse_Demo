using CookBook.DAL.Tests;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Tests
{
    public class CookBookDbContextFixture<TFixture>
    {
        public DbContextInMemoryFactory DbContextFactory { get; }
        public CookBookDbContext CookBookDbContextSUT { get; }

        public CookBookDbContextFixture()
        {
            DbContextFactory = new DbContextInMemoryFactory(typeof(TFixture).Name);
            CookBookDbContextSUT = DbContextFactory.CreateDbContext();
            CookBookDbContextSUT.Database.EnsureCreated();
        }
    }
}