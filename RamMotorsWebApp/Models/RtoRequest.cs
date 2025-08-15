using System.ComponentModel.DataAnnotations;

namespace RamMotorsWebApp.Models
{
    public class RtoRequest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string ServiceType { get; set; }

        public string VehicleNumber { get; set; }

        public string Message { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;
    }
}
