namespace ReplaceOneManyDistictionWithComposite.Specifications
{
    public class BelowPriceSpecification : Specification
    {
        private readonly int _price;

        public BelowPriceSpecification(int price)
        {
            _price = price;
        }

        public override bool IsSatisfiedBy(Product product)
        {
            return product.Price < _price;
        }
    }
}