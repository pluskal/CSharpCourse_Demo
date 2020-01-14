using System;
using CookBook.DAL.Enum;

namespace CookBook.DAL.Entity
{
    public class RecipeIngredientAmountEntity : EntityBase
    {
        public Guid RecipeId { get; set; }
        public RecipeEntity Recipe { get; set; }
        public Guid IngredientId { get; set; }
        public IngredientEntity Ingredient { get; set; }
        public double Amount { get; set; }
        public Unit Unit { get; set; }
    }
}