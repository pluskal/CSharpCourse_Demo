using System;
using CookBook.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL
{
    public static class SeedingData
    {
        public static readonly IngredientEntity IngredientEntity = new IngredientEntity()
        {
            Id = Guid.Parse("84837F2C-D69A-4299-938B-39D9F604CB34"),
            Name = "Water",
            Description = "Mineral"
        };

        public static void SeedIngredients(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientEntity>().HasData(
                IngredientEntity);
        }
    }
}