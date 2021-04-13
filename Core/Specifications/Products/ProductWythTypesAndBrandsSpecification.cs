using Core.Entities;
using Core.Specifications.Base;

namespace Core.Specifications.Products
{
    public class ProductWythTypesAndBrandsSpecification : BaseSpecification<Product> 
    {
         public ProductWythTypesAndBrandsSpecification(ProductSpecParams productParams)
        :base(x=>
        (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search))
        && (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId)
        && (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=>x.ProductType);

            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if(!string.IsNullOrEmpty(productParams.Sort))
            {
                switch(productParams.Sort)
                {
                    case "PriceAsc":
                        AddOrderBy(x=>x.Price);
                        break;
                    case "PriceDesc":
                        AddOrderByDescending(x=>x.Price);
                        break;
                    default:
                        AddOrderBy(x=>x.Name);
                        break;
                }
            }
        }

        public ProductWythTypesAndBrandsSpecification(int id)
        :base(x=>x.Id == id)
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=>x.ProductType);
        }
    }
}