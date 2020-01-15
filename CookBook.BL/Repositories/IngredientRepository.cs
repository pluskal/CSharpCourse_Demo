using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookBook.BL.DTO;
using CookBook.BL.Mappers;
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
    }
}
