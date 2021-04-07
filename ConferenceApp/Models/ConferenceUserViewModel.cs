using System.ComponentModel.DataAnnotations;

namespace ConferenceApp.Models
{
    public class ConferenceUserViewModel
    {
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }
        public string Email { get; set; }
        
        [Display(Name = "Zdjęcie")]
        public string PhotoUrl { get; set; }

        [Display(Name = "Typ konferencji")]
        public ConferenceType? ConferenceType { get; set; }
    }
}
