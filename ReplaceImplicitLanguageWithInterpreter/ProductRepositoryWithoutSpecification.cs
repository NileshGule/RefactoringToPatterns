using System.Collections.Generic;
using System.Linq;

using Product = ReplaceImplicitLanguageWithInterpreter.DomainObjects.Product;
using ProductColor = ReplaceImplicitLanguageWithInterpreter.DomainObjects.ProductColor;
using ProductSize = ReplaceImplicitLanguageWithInterpreter.DomainObjects.ProductSize;

namespace ReplaceImplicitLanguageWithInterpreter
{
    public class ProductRepositoryWithoutSpecification
    {
        private IList<Product> _products = new List<Product>();

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public IList<Product> FindProductsByColor(ProductColor color)
        {
            return _products.Where(product => product.Color == color).ToList();
        }

        public IList<Product> FindProductsByPrice(double price)
        {
            return _products.Where(product => product.Price == price).ToList();
        }

        public IList<Product> FindProductsBelowPrice(double price)
        {
            return _products.Where(product => product.Price < price).ToList();
        }

        public IList<Product> FindProductsAbovePrice(double price)
        {
            return _products.Where(product => product.Price > price).ToList();
        }

        public IList<Product> FindProductsByColorAndBelowPrice(ProductColor color, double price)
        {
            return _products.Where(product => product.Color == color && product.Price < price).ToList();
        }

        public IList<Product> FindProductsByColorAndSize(ProductColor color, ProductSize size)
        {
            return _products.Where(product => product.Color == color && product.Size == size).ToList();
        }

        public IList<Product> FindProductsByColorOrSize(ProductColor color, ProductSize size)
        {
            return _products.Where(product => product.Color == color || product.Size == size).ToList();
        }

        public IList<Product> FindProductsBySizeNotEqualTo(ProductSize size)
        {
            return _products.Where(product => product.Size != size).ToList();
        }
    }
}