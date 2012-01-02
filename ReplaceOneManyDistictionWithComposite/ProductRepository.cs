using System.Collections.Generic;
using System.Linq;

using ReplaceOneManyDistictionWithComposite.Specifications;

namespace ReplaceOneManyDistictionWithComposite
{
    public class ProductRepository
    {
        private IList<Product> _products = new List<Product>();

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public IList<Product> SelectBy(Specification specification)
        {
            return _products.Where(specification.IsSatisfiedBy).ToList();
        }
    }
}