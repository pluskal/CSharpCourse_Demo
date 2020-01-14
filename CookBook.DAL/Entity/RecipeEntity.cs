using System;
using System.Collections.Generic;
using CookBook.DAL.Enum;

namespace CookBook.DAL.Entity
{
    public class RecipeEntity : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public FoodType FoodType { get; set; }
        public ICollection<RecipeIngredientAmountEntity> Ingredients { get; set; }
    }
}