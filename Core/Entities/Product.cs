using Core.Entities.Base;

namespace Core.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public int ProductTypeId { get; set; } 
        
        public int ProductBrandId { get; set; }

        public ProductBrand ProductBrand { get; set; }

        public ProductType ProductType { get; set; }
    }
}