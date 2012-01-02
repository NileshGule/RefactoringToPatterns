using Product = ReplaceImplicitLanguageWithInterpreter.DomainObjects.Product;
using ProductSize = ReplaceImplicitLanguageWithInterpreter.DomainObjects.ProductSize;

namespace ReplaceImplicitLanguageWithInterpreter.Specifications
{
    public class SizeSpecification : Specification
    {
        private readonly ProductSize _productSize;

        public SizeSpecification(ProductSize productSize)
        {
            _productSize = productSize;
        }

        public override bool IsSatisfiedBy(Product product)
        {
            return product.Size.Equals(_productSize);
        }
    }
}