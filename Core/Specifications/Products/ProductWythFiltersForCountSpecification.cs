using Core.Entities;
using Core.Specifications.Base;

namespace Core.Specifications.Products
{
    public class ProductWythFiltersForCountSpecification : BaseSpecification<Product> 
    {
        public ProductWythFiltersForCountSpecification(ProductSpecParams productParams)
        :base(x=>
        (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search))
        && (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId)
        && (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        {
        }
    }
}