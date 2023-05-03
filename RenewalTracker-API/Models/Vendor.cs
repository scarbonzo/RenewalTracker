namespace RenewalTracker_API.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string ContactInfo { get; set; }
        public bool Active { get; set; }
    }
}
