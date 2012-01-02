using ReplaceImplicitLanguageWithInterpreter.DomainObjects;

namespace ReplaceImplicitLanguageWithInterpreter.Specifications
{
    public class OrSpecification : Specification
    {
        private readonly Specification _leftSpecification;

        private readonly Specification _rightSpecification;

        public OrSpecification(Specification leftSpecification, Specification rightSpecification)
        {
            _leftSpecification = leftSpecification;
            _rightSpecification = rightSpecification;
        }

        public override bool IsSatisfiedBy(Product product)
        {
            return _leftSpecification.IsSatisfiedBy(product) || _rightSpecification.IsSatisfiedBy(product);
        }
    }
}