using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ContactModel.POCOClasses
{
    public class Contact : BaseEntity
    {
        [Required(ErrorMessage ="FirstName required")]
        [StringLength(20,ErrorMessage ="Firstname should not exceed 20 characters")]
        [RegularExpression(@"^[a-zA-Z]{0,20}$", ErrorMessage = "FirstName contains invalid characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName required")]
        [StringLength(20, ErrorMessage = "Lastname should not exceed 20 characters")]
        [RegularExpression(@"^[a-zA-Z]{0,20}$", ErrorMessage = "LastName contains invalid characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email required")]
        [StringLength(40, ErrorMessage = "Email should not exceed 40 characters")]
        [RegularExpression(@"^[\w\.\-]+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PhoneNumber required")]
        [StringLength(15, ErrorMessage = "Phone# should not exceed 15 characters")]
        [RegularExpression(@"^[0-9]{0,15}$", ErrorMessage = "Phone# should contain only digits")]
        public string PhoneNumber { get; set; }
        
        public string Status { get; set; }
    }
}
