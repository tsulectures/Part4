using Core.Entities;
using Core.Specifications.Base;

namespace Core.Specifications.Products
{
    public class ProductWythTypesAndBrandsSpecification : BaseSpecification<Product> 
    {
         public ProductWythTypesAndBrandsSpecification()
        :base()
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=>x.ProductType);
        }

        public ProductWythTypesAndBrandsSpecification(int id)
        :base(x=>x.Id == id)
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=>x.ProductType);
        }
    }
}