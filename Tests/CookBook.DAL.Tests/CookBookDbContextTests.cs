using System;
using System.Linq;
using CookBook.DAL.Entity;
using CookBook.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CookBook.DAL.Tests
{
    public class CookBookDbContextTests : IClassFixture<CookBookDbContextFixture<CookBookDbContextTests>>
    {
        private readonly CookBookDbContextFixture<CookBookDbContextTests> _testContext;

        public CookBookDbContextTests(CookBookDbContextFixture<CookBookDbContextTests> testContext)
        {
            _testContext = testContext;
        }

        [Fact]
        public void Add_Ingredient_IngredientAdded()
        {
            //Arrange
            var ingredient = new IngredientEntity();

            //Act
            _testContext.CookBookDbContextSUT.Ingredients.Add(ingredient);
            _testContext.CookBookDbContextSUT.SaveChanges();

            //Assert
            using (var dbx = _testContext.CookBookDbContextFactory.CreateDbContext(nameof(CookBookDbContextTests)))
            {
                var _ = dbx.Ingredients.Single(i => i.Id == ingredient.Id);
            }
        }
    }
}
