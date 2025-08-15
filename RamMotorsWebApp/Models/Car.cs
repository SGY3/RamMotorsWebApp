using System.ComponentModel.DataAnnotations;

namespace RamMotorsWebApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        [Display(Name = "Registration Month")]
        public string RegistrationMonth { get; set; }
        [Required]
        [Display(Name = "Registration Year")]
        public int RegistrationYear { get; set; }
        [Required]
        [Display(Name = "Manufacture Year")]
        public int ManufactureYear { get; set; }
        [Required]
        [Display(Name = "Fuel Type")]
        public string FuelType { get; set; }
        public string OwnerCount { get; set; }
        public int KMDriven { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFeatured { get; set; }
        public string Insurance { get; set; }
        public int Seats { get; set; }
        public int Displacement { get; set; }
        public int Power { get; set; }
        public int Mileage { get; set; }
        public int DriveType { get; set; }
        public string Transmission { get; set; }
        public string GroundClearance { get; set; }
        public string City { get; set; }
    }
}
