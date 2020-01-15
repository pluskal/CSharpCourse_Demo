using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.BL.DTO;
using CookBook.BL.Mappers;
using CookBook.DAL.Entity;
using CookBook.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<IngredientDTO>> GetAllAsync()
        {
            using (var dbx = _contextFactory.CreateDbContext())
            {
                return (await dbx.Ingredients.ToArrayAsync()).Select(Mapper.MapDto);
            }
        }

        public IngredientDTO GetById(Guid id)
        {
            using (var dbx = _contextFactory.CreateDbContext())
            {
                return Mapper.MapDto(dbx.Ingredients.Single(i=>i.Id==id));
            }
        }

        public async Task<IngredientDTO> GetByIdAsync(Guid id)
        {
            using (var dbx = _contextFactory.CreateDbContext())
            {
                return Mapper.MapDto(await dbx.Ingredients.SingleAsync(i => i.Id == id));
            }
        }

        public void Delete(Guid id)
        {
            using (var dbx = _contextFactory.CreateDbContext())
            {
                var ingredient = new IngredientEntity(){Id = id};
                dbx.Ingredients.Remove(ingredient);

                dbx.SaveChanges();
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            using (var dbx = _contextFactory.CreateDbContext())
            {
                var ingredient = new IngredientEntity() { Id = id };
                dbx.Ingredients.Remove(ingredient);
                await dbx.SaveChangesAsync();
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

        public async Task<IngredientDTO> InsertOrUpdateAsync(IngredientDTO ingredient)
        {
            using (var dbx = _contextFactory.CreateDbContext())
            {
                var ingredientEntity = dbx.Ingredients.Update(Mapper.MapEntity(ingredient)).Entity;
                await dbx.SaveChangesAsync();

                return Mapper.MapDto(ingredientEntity);
            }
        }
    }
}
