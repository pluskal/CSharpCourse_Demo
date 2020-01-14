namespace CookBook.DAL.Interfaces
{
    public interface ICookBookDbContextFactory
    {
        CookBookDbContext CreateDbContext(string databaseName);
    }
}