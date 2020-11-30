using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productSpec)
            :base(x => 
                (string.IsNullOrEmpty(productSpec.Search) || x.Name.ToLower().Contains(productSpec.Search)) &&
                (!productSpec.BrandId.HasValue || x.ProductBrandId == productSpec.BrandId) 
                && (!productSpec.TypeId.HasValue || x.ProductTypeId == productSpec.TypeId)
            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(productSpec.PageSize * (productSpec.PageIndex -1),productSpec.PageSize);

            if(!string.IsNullOrEmpty(productSpec.Sort))
            {
                switch(productSpec.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) 
                : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}