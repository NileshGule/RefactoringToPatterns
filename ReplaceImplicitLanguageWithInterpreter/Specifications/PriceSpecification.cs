using ReplaceImplicitLanguageWithInterpreter.DomainObjects;

namespace ReplaceImplicitLanguageWithInterpreter.Specifications
{
    public class PriceSpecification : Specification
    {
        private readonly double _price;

        public PriceSpecification(double price)
        {
            _price = price;
        }

        public override bool IsSatisfiedBy(Product product)
        {
            return product.Price == _price;
        }
    }
}