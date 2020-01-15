using CookBook.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CookBook.DAL
{
    public class CookBookDbContext : DbContext
    {
        public CookBookDbContext()
        {
        }

        public CookBookDbContext(DbContextOptions<CookBookDbContext> contextOptions)
            : base(contextOptions)
        {
        }


        public DbSet<IngredientEntity> Ingredients { get; set; }
        public DbSet<RecipeEntity> Recipe { get; set; }
        public DbSet<RecipeIngredientAmountEntity> IngredientAmount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(
                    @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = CookBook; Integrated Security = SSPI; ");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedIngredients();
            base.OnModelCreating(modelBuilder);
        }
    }
}