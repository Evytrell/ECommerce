using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ECommerce.Models
{
    public class Seller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int SellerId { get; set; }
        [Required(ErrorMessage = "Please enter a valid name")]
        [Display(Name = " First Name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a valid name")]
        [Display(Name = " Last Name")]
        public string LastName { get; set; } = null!;
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; } = null!;
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;
        [Display(Name = "Store Name")]
        public string StoreName { get; set; } = null!;
        [Display(Name = "StoreAddress")]
        public string StoreAddress { get; set; } = null!;
        [Display(Name = "Registration Date")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
    }
}
