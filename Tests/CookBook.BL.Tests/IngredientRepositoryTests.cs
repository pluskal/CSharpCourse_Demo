using System;
using CookBook.BL.Repositories;
using CookBook.DAL;
using CookBook.DAL.Tests;
using Xunit;

namespace CookBook.BL.Tests
{
    public class IngredientRepositoryTests
    {
        private IngredientRepository _ingredientRepositorySUT;

        public IngredientRepositoryTests()
        {
            var dbContextFactory = new DbContextInMemoryFactory(nameof(IngredientRepositoryTests));
            using (var dbx = dbContextFactory.CreateDbContext())
            {
                dbx.Database.EnsureCreatedAsync().GetAwaiter().GetResult();
            }
            _ingredientRepositorySUT = new IngredientRepository(dbContextFactory);
        }

        [Fact]
        public void GetAllIngredients()
        {
            var ingredients = _ingredientRepositorySUT.GetAll();

            Assert.NotEmpty(ingredients);
        }

        [Fact]
        public void GetIngredientById()
        {
            var ingredient = _ingredientRepositorySUT.GetById(SeedingData.IngredientLemonEntity.Id);
            Assert.NotNull(ingredient);
        }
    }
}
