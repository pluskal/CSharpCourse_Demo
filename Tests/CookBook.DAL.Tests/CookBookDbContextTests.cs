using System;
using System.Collections.Generic;
using System.Linq;
using CookBook.DAL.Entity;
using CookBook.DAL.Enum;
using Xunit;

namespace CookBook.DAL.Tests
{
    public class CookBookDbContextTests : IClassFixture<CookBookDbContextFixture<CookBookDbContextTests>>
    {
        public CookBookDbContextTests(CookBookDbContextFixture<CookBookDbContextTests> testContext)
        {
            _testContext = testContext;
        }

        private readonly CookBookDbContextFixture<CookBookDbContextTests> _testContext;

        [Fact]
        public void Add_Ingredient_IngredientAdded()
        {
            //Arrange
            var ingredient = new IngredientEntity();

            //Act
            _testContext.CookBookDbContextSUT.Ingredients.Add(ingredient);
            _testContext.CookBookDbContextSUT.SaveChanges();

            //Assert
            using (var dbx = _testContext.DbContextFactory.CreateDbContext())
            {
                var _ = dbx.Ingredients.Single(i => i.Id == ingredient.Id);
            }
        }

        [Fact]
        public void Add_Recipe_RecipeAdded()
        {
            //Arrange
            var entity = new RecipeEntity
            {
                Name = "Lemonade",
                Description = "Sweet Summer Refreshing Lemonade",
                FoodType = FoodType.Drink,
                Duration = TimeSpan.FromMinutes(1),
                Ingredients = new []
                {
                    new IngredientAmountEntity
                    {
                        Amount = 1,
                        Unit = Unit.L,
                        Ingredient = new IngredientEntity
                        {
                            Name = "Water",
                            Description = "Mineral"
                        }
                    },
                    new IngredientAmountEntity
                    {
                        Amount = 100,
                        Unit = Unit.G,
                        Ingredient = new IngredientEntity
                        {
                            Name = "Sugar",
                            Description = "Brown"
                        }
                    },
                    new IngredientAmountEntity
                    {
                        Amount = 50,
                        Unit = Unit.Ml,
                        Ingredient = new IngredientEntity
                        {
                            Name = "Lemon",
                            Description = "Mashed"
                        }
                    }
                }
            };

            //Act
            _testContext.CookBookDbContextSUT.Recipe.Add(entity);
            _testContext.CookBookDbContextSUT.SaveChanges();

            //Assert
            using (var dbx = _testContext.DbContextFactory.CreateDbContext())
            {
                var _ = dbx.Recipe.Single(i => i.Id == entity.Id);
            }
        }

        [Fact]
        public void Get_Ingredient_IngredientRetrieved()
        {
            var _ = _testContext.CookBookDbContextSUT.Ingredients.Single(i => i.Id == SeedingData.IngredientMineralWaterEntity.Id);
        }

        [Fact]
        public void Get_Recipe_RecipeRetrieved()
        {
            var _ = _testContext.CookBookDbContextSUT.Recipe.Single(i => i.Id == SeedingData.RecipeEntity.Id);
        }
    }
}