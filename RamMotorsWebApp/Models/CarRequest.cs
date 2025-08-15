namespace RamMotorsWebApp.Models
{
    public class CarRequest
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime RequestDate { get; set; }

    }
}
