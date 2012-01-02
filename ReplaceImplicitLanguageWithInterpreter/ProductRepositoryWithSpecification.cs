using System.Collections.Generic;
using System.Linq;

using ReplaceImplicitLanguageWithInterpreter.DomainObjects;
using ReplaceImplicitLanguageWithInterpreter.Specifications;

namespace ReplaceImplicitLanguageWithInterpreter
{
    public class ProductRepositoryWithSpecification
    {
        private IList<Product> _products = new List<Product>();

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public IList<Product> FindProducts(Specification specification)
        {
            return _products.Where(specification.IsSatisfiedBy).ToList();
        }
    }
}