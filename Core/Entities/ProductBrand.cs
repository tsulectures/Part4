using System.Collections.Generic;
using Core.Entities.Base;

namespace Core.Entities
{
    public class ProductBrand : Entity
    {
        public string Name { get; set; }

        ICollection<Product> Products { get; set; }
    }
}