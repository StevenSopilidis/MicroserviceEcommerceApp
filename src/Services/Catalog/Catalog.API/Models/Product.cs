namespace Catalog.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; }
        public IList<string> Category { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}