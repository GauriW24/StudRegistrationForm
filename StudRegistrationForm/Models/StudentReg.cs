using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudRegistrationForm.Models
{
    public class StudentReg
    {
        [Required(ErrorMessage ="Please enter name!")]
        public string name { get; set; }

        [Required]
        [RegularExpression(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", ErrorMessage = "Invalid email!")]
        public string email { get; set; }

        [Required(ErrorMessage ="Please enter mobile number!")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})", ErrorMessage = "Invalid mobile number!")]
        public string mobno { get; set; }

        //public List<StudentReg> studRegInfo { get; set; }

    }
}