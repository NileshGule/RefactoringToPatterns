using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ReplaceOneManyDistictionWithComposite;
using ReplaceOneManyDistictionWithComposite.Specifications;

namespace ReplaceOneManyDistinctionWithCompositeTest
{
    [TestClass]
    public class ProductRepositoryTest
    {
        private Product _fireTruck;

        private Product _barbieClassic;

        private Product _frisbee;

        private Product _baseball;

        private Product _toyConvertible;

        private ProductRepository _productRepository;

        [TestInitialize]
        public void Setup()
        {
            _fireTruck = new Product
                {
                    Id = "f1234",
                    Description = "Fire Truck",
                    Color = ProductColor.RED,
                    Price = 8.95,
                    Size = ProductSize.MEDIUM
                };

            _barbieClassic = new Product
            {
                Id = "b7654",
                Description = "Barbie Classic",
                Color = ProductColor.YELLOW,
                Price = 15.95,
                Size = ProductSize.SMALL
            };

            _frisbee = new Product
            {
                Id = "f4321",
                Description = "Frisbee",
                Color = ProductColor.GREEN,
                Price = 9.99,
                Size = ProductSize.LARGE
            };

            _baseball = new Product
            {
                Id = "b2343",
                Description = "Baseball",
                Color = ProductColor.WHITE,
                Price = 8.95,
                Size = ProductSize.NOT_APPLICABLE
            };

            _toyConvertible = new Product
            {
                Id = "p1112",
                Description = "Toy Porsche Convertible",
                Color = ProductColor.RED,
                Price = 230,
                Size = ProductSize.NOT_APPLICABLE
            };

            _productRepository = new ProductRepository();
            _productRepository.Add(_fireTruck);
            _productRepository.Add(_barbieClassic);
            _productRepository.Add(_frisbee);
            _productRepository.Add(_baseball);
            _productRepository.Add(_toyConvertible);
        }

        [TestMethod]
        public void ProductRepositoryConstructorTest()
        {
            Assert.IsNotNull(_productRepository);
        }

        [TestMethod]
        public void AddTest()
        {
            ProductRepository productRepository = new ProductRepository();
            Product product = new Product();
            productRepository.Add(product);
        }

        [TestMethod]
        public void FindByColourTest()
        {
            IList<Product> foundProducts = _productRepository.SelectBy(new ColorSpecification(ProductColor.RED));
            Assert.AreEqual(2, foundProducts.Count);
            Assert.IsTrue(foundProducts.Contains(_fireTruck));
        }

        [TestMethod]
        public void FindByBelowPriceColourAndSizeTest()
        {
            IList<Specification> specs = new List<Specification>
                {
                    new ColorSpecification(ProductColor.RED),
                    new SizeSpecification(ProductSize.SMALL),
                    new BelowPriceSpecification(10)
                };

            CompositeSpecification compositeSpecification = new CompositeSpecification(specs);

            IList<Product> foundProducts = _productRepository.SelectBy(compositeSpecification);

            Assert.AreEqual(0, foundProducts.Count);
        }
    }
}