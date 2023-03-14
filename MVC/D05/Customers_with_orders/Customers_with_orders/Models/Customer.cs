using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;


namespace Customers_with_orders.Models
{
    public enum GenderType
    {
        Female , Male
    }
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name of Employee is Required")]
        [StringLength(50)]
        [StartWith('x')]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Gender of Employee is Required")]
        public GenderType Gender { get; set; }


        [Required(ErrorMessage = "Email of Employee is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "phoneNum of Employee is Required")]
        [MaxLength(11, ErrorMessage = "PhoneNumber must be 11 numbers")]
        public string phoneNum { get; set; }
        
        public virtual ICollection<Customer> Customers { get; set; }

    }
}