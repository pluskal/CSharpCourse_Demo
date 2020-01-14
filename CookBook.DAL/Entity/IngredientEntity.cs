using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.DAL.Entity
{
    public class IngredientEntity : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
