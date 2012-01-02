using ReplaceImplicitLanguageWithInterpreter.DomainObjects;

namespace ReplaceImplicitLanguageWithInterpreter.Specifications
{
    public class NotSpecification : Specification
    {
        private readonly Specification _specification;

        public NotSpecification(Specification specification)
        {
            _specification = specification;
        }

        public override bool IsSatisfiedBy(Product product)
        {
            return !_specification.IsSatisfiedBy(product);
        }
    }
}