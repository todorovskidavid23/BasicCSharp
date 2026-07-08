using System.ComponentModel.DataAnnotations;

namespace ASP.NET.Core.MVC.Class07.Models.ViewModels
{
    public class CreateStudentVM
    {
        [Required]
        [MinLength(2,ErrorMessage ="The First name must have at least 2 characters")]
        [MaxLength(50,ErrorMessage = "The First name must have at most 50 characters")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50,MinimumLength =2,ErrorMessage ="The last name must have at least 2 characters and the most 50 characters")]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="The email address is not valid")]
        public string Email { get; set; }
        [Phone]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name ="Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        //samiot mu dodavame dopolnitelni infomacii za validacija
        //si dodavame Data Anotacija
    }
}
