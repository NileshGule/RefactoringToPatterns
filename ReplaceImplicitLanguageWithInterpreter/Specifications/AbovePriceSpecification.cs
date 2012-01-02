using ReplaceImplicitLanguageWithInterpreter.DomainObjects;

namespace ReplaceImplicitLanguageWithInterpreter.Specifications
{
    public class AbovePriceSpecification : Specification
    {
        private readonly int _price;

        public AbovePriceSpecification(int price)
        {
            _price = price;
        }

        public override bool IsSatisfiedBy(Product product)
        {
            return product.Price > _price;
        }
    }
}