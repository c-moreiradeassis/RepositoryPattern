namespace Domain.Models.Database
{
    public class Product
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
