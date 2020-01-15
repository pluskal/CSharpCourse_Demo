using System;
using System.Collections.Generic;
using System.ComponentModel;
using CookBook.DAL.Entity;
using CookBook.DAL.Enum;
using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL
{
    public static class SeedingData
    {
        public static readonly IngredientEntity IngredientMineralWaterEntity = new IngredientEntity()
        {
            Id = Guid.Parse("84837F2C-D69A-4299-938B-39D9F604CB34"),
            Name = "Water",
            Description = "Mineral"
        };

        public static readonly IngredientEntity IngredientQuinineEntity = new IngredientEntity
        {
            Id = Guid.Parse("85837F2C-D69A-4299-938B-39D9F604CB35"),
            Name = "Quinine",
            Description = "Medical"
        };

        public static readonly IngredientEntity IngredientBrownSugarEntity = new IngredientEntity
        {
            Id = Guid.Parse("86837F2C-D69A-4299-938B-39D9F604CB36"),
            Name = "Sugar",
            Description = "Brown"
        };

        public static readonly IngredientEntity IngredientLemonEntity = new IngredientEntity
        {
            Id = Guid.Parse("87837F2C-D69A-4299-938B-39D9F604CB37"),
            Name = "Lemon",
            Description = "Mashed"
        };

        public static readonly RecipeEntity RecipeEntity = new RecipeEntity()
        {
            Id = Guid.Parse("94837F2C-D69A-4299-938B-39D9F604CB41"),
            Name = "Tonic",
            Description = "Bitter Tonic",
            FoodType = FoodType.Drink,
            Duration = TimeSpan.FromMinutes(1),
            //Ingredients = new List<IngredientAmountEntity>()
            //{
            //    IngredientAmountQuinineEntity,
            //    IngredientAmountBrownSugarEntity,
            //    IngredientAmountLemonEntity
            //}
        };

        public static readonly IngredientAmountEntity IngredientAmountQuinineEntity = new IngredientAmountEntity
        {
            Id = Guid.Parse("10837F2C-D69A-4299-938B-39D9F604CB10"),
            Amount = 1,
            Unit = Unit.L,
            IngredientId = IngredientQuinineEntity.Id,
            RecipeId = RecipeEntity.Id
        };

        public static readonly IngredientAmountEntity IngredientAmountBrownSugarEntity = new IngredientAmountEntity
        {
            Id = Guid.Parse("11837F2C-D69A-4299-938B-39D9F604CB11"),
            Amount = 100,
            Unit = Unit.G,
            IngredientId = IngredientBrownSugarEntity.Id,
            RecipeId = RecipeEntity.Id
        };

        public static readonly IngredientAmountEntity IngredientAmountLemonEntity = new IngredientAmountEntity
        {
            Id = Guid.Parse("12837F2C-D69A-4299-938B-39D9F604CB12"),
            Amount = 50,
            Unit = Unit.Ml,
            IngredientId = IngredientLemonEntity.Id,
            RecipeId = RecipeEntity.Id
        };

        

        public static void SeedIngredients(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientEntity>().HasData(SeedingData.IngredientMineralWaterEntity);
            modelBuilder.Entity<IngredientEntity>().HasData(SeedingData.IngredientQuinineEntity);
            modelBuilder.Entity<IngredientEntity>().HasData(SeedingData.IngredientBrownSugarEntity);
            modelBuilder.Entity<IngredientEntity>().HasData(SeedingData.IngredientLemonEntity);
        }

        public static void SeedIngredientAmounts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientAmountEntity>().HasData(IngredientAmountQuinineEntity);
            modelBuilder.Entity<IngredientAmountEntity>().HasData(IngredientAmountBrownSugarEntity);
            modelBuilder.Entity<IngredientAmountEntity>().HasData(IngredientAmountLemonEntity);
        }

        public static void SeedRecipes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeEntity>().HasData(RecipeEntity);
        }

        //public static readonly RecipeEntity RecipeEntity = new RecipeEntity()
        //{
        //    Id = Guid.Parse("94837F2C-D69A-4299-938B-39D9F604CB41"),
        //    Name = "Tonic",
        //    Description = "Bitter Tonic",
        //    FoodType = FoodType.Drink,
        //    Duration = TimeSpan.FromMinutes(1),
        //    Ingredients =
        //    {
        //        new IngredientAmountEntity
        //        {
        //            Id = Guid.Parse("10837F2C-D69A-4299-938B-39D9F604CB10"),
        //            Amount = 1,
        //            Unit = Unit.L,
        //            Ingredient = IngredientQuinineEntity
        //        },
        //        new IngredientAmountEntity
        //        {
        //            Id = Guid.Parse("11837F2C-D69A-4299-938B-39D9F604CB11"),
        //            Amount = 100,
        //            Unit = Unit.G,
        //            Ingredient = IngredientBrownSugarEntity
        //        },
        //        new IngredientAmountEntity
        //        {
        //            Id = Guid.Parse("12837F2C-D69A-4299-938B-39D9F604CB12"),
        //            Amount = 50,
        //            Unit = Unit.Ml,
        //            Ingredient = IngredientLemonEntity
        //        }
        //    }
        //};
    }
}