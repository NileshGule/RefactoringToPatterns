using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ReplaceImplicitLanguageWithInterpreter;
using ReplaceImplicitLanguageWithInterpreter.DomainObjects;

namespace ReplaceImplicitLanguageWithInterpreterTests
{
    [TestClass]
    public class ProductRepositoryWithoutSpecificationTest
    {
        private Product _fireTruck;

        private Product _barbieClassic;

        private Product _frisbee;

        private Product _baseball;

        private Product _toyConvertible;

        private ProductRepositoryWithoutSpecification _productRepositoryWithoutSpecification;

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

            _productRepositoryWithoutSpecification = new ProductRepositoryWithoutSpecification();
            _productRepositoryWithoutSpecification.Add(_fireTruck);
            _productRepositoryWithoutSpecification.Add(_barbieClassic);
            _productRepositoryWithoutSpecification.Add(_frisbee);
            _productRepositoryWithoutSpecification.Add(_baseball);
            _productRepositoryWithoutSpecification.Add(_toyConvertible);
        }

        [TestMethod]
        public void ProductRepositoryConstructorTest()
        {
            Assert.IsNotNull(_productRepositoryWithoutSpecification);
        }

        [TestMethod]
        public void FindProductsByColorTest()
        {
            IList<Product> filteredProducts =
                _productRepositoryWithoutSpecification.FindProductsByColor(ProductColor.RED);

            Assert.AreEqual(2, filteredProducts.Count);
            Assert.AreEqual("Fire Truck", filteredProducts.First().Description);
            Assert.AreEqual("Toy Porsche Convertible", filteredProducts.Last().Description);
        }

        [TestMethod]
        public void FindProductsByPriceTest()
        {
            IList<Product> filteredProducts =
                _productRepositoryWithoutSpecification.FindProductsByPrice(9.99);

            Assert.AreEqual(1, filteredProducts.Count);
            Assert.AreEqual("Frisbee", filteredProducts.First().Description);
            Assert.AreEqual(9.99, filteredProducts.First().Price);
        }

        [TestMethod]
        public void FindProductsBelowPriceTest()
        {
            IList<Product> filteredProducts =
                _productRepositoryWithoutSpecification.FindProductsBelowPrice(9);

            Assert.AreEqual(2, filteredProducts.Count);
            Assert.AreEqual("Fire Truck", filteredProducts.First().Description);
            Assert.AreEqual("Baseball", filteredProducts.Last().Description);
        }

        [TestMethod]
        public void FindProductsAbovePriceTest()
        {
            IList<Product> filteredProducts =
                _productRepositoryWithoutSpecification.FindProductsAbovePrice(9);

            Assert.AreEqual(3, filteredProducts.Count);
            Assert.AreEqual("Barbie Classic", filteredProducts.First().Description);
            Assert.AreEqual("Toy Porsche Convertible", filteredProducts.Last().Description);
        }

        [TestMethod]
        public void FindProductsByColorAndBelowPriceTest()
        {
            IList<Product> filteredProducts =
                _productRepositoryWithoutSpecification.FindProductsByColorAndBelowPrice(ProductColor.GREEN, 10);

            Assert.AreEqual(1, filteredProducts.Count);
            Assert.AreEqual("Frisbee", filteredProducts.First().Description);
        }

        [TestMethod]
        public void FindProductsByColorAndSizeTest()
        {
            IList<Product> filteredProducts =
                _productRepositoryWithoutSpecification.FindProductsByColorAndSize(ProductColor.GREEN, ProductSize.SMALL);

            Assert.AreEqual(0, filteredProducts.Count);
        }

        [TestMethod]
        public void FindProductsByColorOrSizeTest()
        {
            IList<Product> filteredProducts =
                _productRepositoryWithoutSpecification.FindProductsByColorOrSize(ProductColor.GREEN, ProductSize.SMALL);

            Assert.AreEqual(2, filteredProducts.Count);
            Assert.AreEqual("Barbie Classic", filteredProducts.First().Description);
            Assert.AreEqual("Frisbee", filteredProducts.Last().Description);
        }

        [TestMethod]
        public void FindProductsBySizeNotEqualToTest()
        {
            IList<Product> filteredProducts =
                _productRepositoryWithoutSpecification.FindProductsBySizeNotEqualTo(ProductSize.SMALL);

            Assert.AreEqual(4, filteredProducts.Count);
            Assert.AreEqual("Fire Truck", filteredProducts.First().Description);
            Assert.AreEqual("Toy Porsche Convertible", filteredProducts.Last().Description);
        }
    }
}