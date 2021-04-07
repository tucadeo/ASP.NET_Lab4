using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ConferenceApp.Models
{
    public class RegisterConferenceUserViewModel
    {
        [Required]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Zdjęcie")]
        public IFormFile Photo { get; set; }

        [Required]
        [Display(Name = "Typ konferencji")]
        public ConferenceType? ConferenceType { get; set; }
    }
}