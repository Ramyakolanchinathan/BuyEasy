namespace BuyEasy.Models.DataModel
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int ProductId { get; set; }  // Foreign key

        public int Quantity { get; set; }

        // Add navigation property
        public ProductViewModel Product { get; set; }
    }
}
