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
        private readonly ICookBookDbContextFactory _contextFactory;

        public IngredientRepository(ICookBookDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public IEnumerable<IngredientDTO> GetAll()
        {
            using (var dbx = _contextFactory.CreateDbContext("CookBook"))
            {
                return dbx.Ingredients.Select(Mapper.MapDto).ToArray();
            }
        }

        public IngredientDTO GetById(Guid id)
        {
            using (var dbx = _contextFactory.CreateDbContext("CookBook"))
            {
                return Mapper.MapDto(dbx.Ingredients.Single(i=>i.Id==id));
            }
        }
    }
}
