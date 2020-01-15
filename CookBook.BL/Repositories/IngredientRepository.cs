using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookBook.BL.DTO;
using CookBook.BL.Mappers;
using CookBook.DAL.Entity;
using CookBook.DAL.Interfaces;

namespace CookBook.BL.Repositories
{
    public class IngredientRepository
    {
        private readonly IDbContextFactory _contextFactory;

        public IngredientRepository(IDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public IEnumerable<IngredientDTO> GetAll()
        {
            using (var dbx = _contextFactory.CreateDbContext())
            {
                return dbx.Ingredients.Select(Mapper.MapDto).ToArray();
            }
        }

        public IngredientDTO GetById(Guid id)
        {
            using (var dbx = _contextFactory.CreateDbContext())
            {
                return Mapper.MapDto(dbx.Ingredients.Single(i=>i.Id==id));
            }
        }

        public void Delete(Guid id)
        {
            using (var dbx = _contextFactory.CreateDbContext())
            {
                var ingredient = new IngredientEntity(){Id = id};
                dbx.Ingredients.Remove(ingredient);
            }
        }


        public IngredientDTO InsertOrUpdate(IngredientDTO ingredient)
        {
            using (var dbx = _contextFactory.CreateDbContext())
            {
                var ingredientEntity = dbx.Ingredients.Update(Mapper.MapEntity(ingredient)).Entity;
                dbx.SaveChanges();

                return Mapper.MapDto(ingredientEntity);
            }
        }
    }
}
