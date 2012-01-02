namespace ReplaceImplicitLanguageWithInterpreter.DomainObjects
{
    public class Product
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public ProductColor Color { get; set; }

        public double Price { get; set; }

        public ProductSize Size { get; set; }
    }
}