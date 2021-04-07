using System.ComponentModel.DataAnnotations;

namespace ConferenceApp.Models
{
    public enum ConferenceType
    {
        [Display(Name = "Warsztaty")]
        Workshop,
        [Display(Name = "Wykłady")]
        Lecture,
        [Display(Name = "Zdalnie")]
        Remote
    }
}