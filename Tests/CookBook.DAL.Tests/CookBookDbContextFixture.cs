namespace CookBook.DAL.Tests
{
    public class CookBookDbContextFixture<TFixture> 
    {
        public CookBookDbContextInMemoryFactory CookBookDbContextFactory { get; }
        public CookBookDbContext CookBookDbContextSUT { get; }

        public CookBookDbContextFixture()
        {
            CookBookDbContextFactory = new CookBookDbContextInMemoryFactory();
            CookBookDbContextSUT = 
                CookBookDbContextFactory.CreateDbContext(typeof(TFixture).Name);
        }
    }
}