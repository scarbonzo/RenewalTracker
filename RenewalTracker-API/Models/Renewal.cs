namespace RenewalTracker_API.Models
{
    public class Renewal
    {
        public int Id { get; set; }
        public DateTime Expiration { get; set; }
        public int Priority { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public int CategoryIds { get; set; }
        public int CurrentVendorId { get; set; }
        public string Notes { get; set; }
    }
}
