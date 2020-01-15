using System;
using CookBook.BL.Repositories;
using Xunit;

namespace CookBook.BL.Tests
{
    public class IngredientRepositoryTests
    {
        private IngredientRepository _ingredientRepositorySUT;

        [Fact]
        public void GetAllIngredients()
        {
            _ingredientRepositorySUT = new IngredientRepository();
            var ingredients = _ingredientRepositorySUT.GetAll();
            Assert.NotEmpty(ingredients);
        }
    }
}
