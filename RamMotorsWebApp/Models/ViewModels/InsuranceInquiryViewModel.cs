using System.ComponentModel.DataAnnotations;

namespace RamMotorsWebApp.Models.ViewModels
{
    public class InsuranceInquiryViewModel
    {
        [Required] 
        public string Name { get; set; }
        [Required, EmailAddress] 
        public string Email { get; set; }
        [Required] 
        public string Phone { get; set; }
        [Required] 
        public string InsuranceType { get; set; }
        public string Message { get; set; }
    }
}
