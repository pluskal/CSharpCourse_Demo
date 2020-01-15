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

        public static IngredientEntity MapEntity(IngredientDTO ingredient)
        {
            return new IngredientEntity()
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Description = ingredient.Description
            };
        }
    }
}