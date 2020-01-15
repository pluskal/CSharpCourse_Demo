namespace CookBook.DAL.Interfaces
{
    public interface IDbContextFactory
    {
        CookBookDbContext CreateDbContext();
    }
}