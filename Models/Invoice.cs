namespace SupermarketWEB.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int ProviderId { get; set; }
        public DateTime Date { get; set; }
        public int PayModeId { get; set; }

        public ICollection<PayMode>? PayModes { get; set; } = default!;
    }
}
