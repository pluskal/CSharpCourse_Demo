using System;
using System.Linq;
using CookBook.BL.DTO;
using CookBook.BL.Repositories;
using CookBook.DAL;
using CookBook.DAL.Entity;
using CookBook.DAL.Tests;
using Xunit;

namespace CookBook.BL.Tests
{
    public class IngredientRepositoryTests : IDisposable
    {
        private IngredientRepository _ingredientRepositorySUT;
        private DbContextInMemoryFactory _dbContextFactory;

        public IngredientRepositoryTests()
        {
            _dbContextFactory = new DbContextInMemoryFactory(nameof(IngredientRepositoryTests));
            using (var dbx = _dbContextFactory.CreateDbContext())
            {
                dbx.Database.EnsureCreatedAsync().GetAwaiter().GetResult();
            }
            _ingredientRepositorySUT = new IngredientRepository(_dbContextFactory);
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

        [Fact]
        public void DeleteIngredientById()
        {
            _ingredientRepositorySUT.Delete(SeedingData.IngredientLemonEntity.Id);
        }

        [Fact]
        public void InsertNewIngredient()
        {
            //Arrange
            var ingredient = new IngredientDTO()
            {
                Name = nameof(IngredientDTO.Name),
                Description = nameof(IngredientDTO.Description)
            };

            //Act
            var retrievedIngredient = _ingredientRepositorySUT.InsertOrUpdate(ingredient);

            //Assert
            Assert.NotEqual(Guid.Empty, retrievedIngredient.Id);
            using (var dbx = _dbContextFactory.CreateDbContext())
            {
                dbx.Ingredients.Single(i => i.Id == retrievedIngredient.Id);
            }
        }

        [Fact]
        public void UpdateIngredient_MineralWater()
        {
            //Arrange
            var ingredient = new IngredientDTO()
            {
                Id = SeedingData.IngredientMineralWaterEntity.Id,
                Name = SeedingData.IngredientMineralWaterEntity.Name + Guid.NewGuid(),
                Description = SeedingData.IngredientMineralWaterEntity.Description + Guid.NewGuid(),
            };

            //Act
            _ingredientRepositorySUT.InsertOrUpdate(ingredient);

            //Assert
            using (var dbx = _dbContextFactory.CreateDbContext())
            {
                var retrievedIngredient = dbx.Ingredients.Single(i => i.Id == ingredient.Id);

                Assert.Equal(ingredient.Id, retrievedIngredient.Id);
                Assert.Equal(ingredient.Name, retrievedIngredient.Name);
                Assert.Equal(ingredient.Description, retrievedIngredient.Description);

            }
        }

        public void Dispose()
        {
            using(var dbx = _dbContextFactory.CreateDbContext())
            {
                dbx.Database.EnsureDeletedAsync().GetAwaiter().GetResult();
            }
        }
    }
}
