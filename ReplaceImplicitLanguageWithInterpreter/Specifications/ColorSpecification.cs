using Product = ReplaceImplicitLanguageWithInterpreter.DomainObjects.Product;
using ProductColor = ReplaceImplicitLanguageWithInterpreter.DomainObjects.ProductColor;

namespace ReplaceImplicitLanguageWithInterpreter.Specifications
{
    public class ColorSpecification : Specification
    {
        private readonly ProductColor _productColor;

        public ColorSpecification(ProductColor productColor)
        {
            _productColor = productColor;
        }

        public override bool IsSatisfiedBy(Product product)
        {
            return product.Color.Equals(_productColor);
        }
    }
}