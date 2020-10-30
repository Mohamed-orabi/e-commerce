using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecificication : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecificication(ProductSpecParams productSpec)
         :base(x => 
                (string.IsNullOrEmpty(productSpec.Search) || x.Name.ToLower().Contains(productSpec.Search)) &&
                (!productSpec.BrandId.HasValue || x.ProductBrandId == productSpec.BrandId) 
                && (!productSpec.TypeId.HasValue || x.ProductTypeId == productSpec.TypeId)
            )
        {
        }
    }
}