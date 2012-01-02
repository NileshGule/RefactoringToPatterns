using Product = ReplaceImplicitLanguageWithInterpreter.DomainObjects.Product;

namespace ReplaceImplicitLanguageWithInterpreter.Specifications
{
    public abstract class Specification
    {
        public abstract bool IsSatisfiedBy(Product product);
    }
}