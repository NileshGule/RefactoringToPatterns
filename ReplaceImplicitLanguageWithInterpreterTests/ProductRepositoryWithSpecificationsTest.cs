using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ReplaceImplicitLanguageWithInterpreter;
using ReplaceImplicitLanguageWithInterpreter.DomainObjects;
using ReplaceImplicitLanguageWithInterpreter.Specifications;

namespace ReplaceImplicitLanguageWithInterpreterTests
{
    [TestClass]
    public class ProductRepositoryWithSpecificationsTest
    {
        private Product _fireTruck;

        private Product _barbieClassic;

        private Product _frisbee;

        private Product _baseball;

        private Product _toyConvertible;

        private ProductRepositoryWithSpecification _productRepositoryWithSpecification;

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

            _productRepositoryWithSpecification = new ProductRepositoryWithSpecification();
            _productRepositoryWithSpecification.Add(_fireTruck);
            _productRepositoryWithSpecification.Add(_barbieClassic);
            _productRepositoryWithSpecification.Add(_frisbee);
            _productRepositoryWithSpecification.Add(_baseball);
            _productRepositoryWithSpecification.Add(_toyConvertible);
        }

        [TestMethod]
        public void ProductRepositoryConstructorTest()
        {
            Assert.IsNotNull(_productRepositoryWithSpecification);
        }

        [TestMethod]
        public void FindProductsByColorTest()
        {
            IList<Product> filteredProducts =
                _productRepositoryWithSpecification.FindProducts(new ColorSpecification(ProductColor.RED));

            Assert.AreEqual(2, filteredProducts.Count);
            Assert.AreEqual("Fire Truck", filteredProducts.First().Description);
            Assert.AreEqual("Toy Porsche Convertible", filteredProducts.Last().Description);
        }

        [TestMethod]
        public void FindProductsByPriceTest()
        {
            IList<Product> filteredProducts =
                _productRepositoryWithSpecification.FindProducts(new PriceSpecification(9.99));

            Assert.AreEqual(1, filteredProducts.Count);
            Assert.AreEqual("Frisbee", filteredProducts.First().Description);
            Assert.AreEqual(9.99, filteredProducts.First().Price);
        }

        [TestMethod]
        public void FindProductsBelowPriceTest()
        {
            IList<Product> filteredProducts =
                _productRepositoryWithSpecification.FindProducts(new BelowPriceSpecification(9));

            Assert.AreEqual(2, filteredProducts.Count);
            Assert.AreEqual("Fire Truck", filteredProducts.First().Description);
            Assert.AreEqual("Baseball", filteredProducts.Last().Description);
        }

        [TestMethod]
        public void FindProductsAbovePriceTest()
        {
            IList<Product> filteredProducts =
                       _productRepositoryWithSpecification.FindProducts(new AbovePriceSpecification(9));

            Assert.AreEqual(3, filteredProducts.Count);
            Assert.AreEqual("Barbie Classic", filteredProducts.First().Description);
            Assert.AreEqual("Toy Porsche Convertible", filteredProducts.Last().Description);
        }

        [TestMethod]
        public void FindProductsByColorAndBelowPriceTest()
        {
            ColorSpecification colorSpecification = new ColorSpecification(ProductColor.GREEN);

            BelowPriceSpecification belowPriceSpecification = new BelowPriceSpecification(10);

            Specification colorAndBelowPriceSpecification =
                new AndSpecification(colorSpecification, belowPriceSpecification);

            IList<Product> filteredProducts =
                _productRepositoryWithSpecification.FindProducts(colorAndBelowPriceSpecification);

            Assert.AreEqual(1, filteredProducts.Count);
            Assert.AreEqual("Frisbee", filteredProducts.First().Description);
        }

        [TestMethod]
        public void FindProductsByColorAndSizeTest()
        {
            ColorSpecification colorSpecification = new ColorSpecification(ProductColor.GREEN);

            SizeSpecification sizeSpecification = new SizeSpecification(ProductSize.SMALL);

            Specification colorAndSizeSpecification =
                new AndSpecification(colorSpecification, sizeSpecification);

            IList<Product> filteredProducts =
                _productRepositoryWithSpecification.FindProducts(colorAndSizeSpecification);

            Assert.AreEqual(0, filteredProducts.Count);
        }

        [TestMethod]
        public void FindProductsByColorOrSizeTest()
        {
            ColorSpecification colorSpecification = new ColorSpecification(ProductColor.GREEN);

            SizeSpecification sizeSpecification = new SizeSpecification(ProductSize.SMALL);

            Specification colorOrSizeSpecification =
                new OrSpecification(colorSpecification, sizeSpecification);

            IList<Product> filteredProducts =
                _productRepositoryWithSpecification.FindProducts(colorOrSizeSpecification);

            Assert.AreEqual(2, filteredProducts.Count);
            Assert.AreEqual("Barbie Classic", filteredProducts.First().Description);
            Assert.AreEqual("Frisbee", filteredProducts.Last().Description);
        }

        [TestMethod]
        public void FindProductsBySizeNotEqualToTest()
        {
            SizeSpecification sizeSpecification = new SizeSpecification(ProductSize.SMALL);

            Specification notSpecification = new NotSpecification(sizeSpecification);

            IList<Product> filteredProducts =
                _productRepositoryWithSpecification.FindProducts(notSpecification);

            Assert.AreEqual(4, filteredProducts.Count);
            Assert.AreEqual("Fire Truck", filteredProducts.First().Description);
            Assert.AreEqual("Toy Porsche Convertible", filteredProducts.Last().Description);
        }
    }
}