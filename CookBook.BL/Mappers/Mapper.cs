using CookBook.BL.DTO;
using CookBook.DAL.Entity;

namespace CookBook.BL.Mappers
{
    public class Mapper
    {
        public static IngredientDTO MapDto(IngredientEntity entity)
        {
            return new IngredientDTO()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
        }
    }
}