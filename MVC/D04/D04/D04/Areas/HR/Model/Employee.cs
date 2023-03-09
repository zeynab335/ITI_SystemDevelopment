using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace D04.Areas.HR.Model
{

    public enum Gender{
        Female , Male
    }

    [Table("Employee")]
    public class Employee
    {
        //- empID
        //- Name
        //- Username
        //- Password
        //- Gender
        //- Salary

        //- joinDate
        //- email
        //- phoneNum

        [Key]
        public int empID { get; set; }

        [MaxLength(20, ErrorMessage = "Too long Name char!!!!!!")]
        [Required(ErrorMessage ="Name of Employee is Required")]
        [DisplayName("Name")]
        public string name { get; set; }


        [EmailAddress]
        [Required(ErrorMessage = "email is Required")]
        //[DataType(DataType.EmailAddress)]
        public string email { get; set; }


        [Required(ErrorMessage = "you have to Enter username")]
        [Compare("email" , ErrorMessage = "Email Not match!!!")]
        public string confirmEmail { get; set; }


        [Required(ErrorMessage = "you have to Enter Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }


        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender gender { get; set; }


        [Required]
        [Column(TypeName = "money")]

        public decimal salary { get; set; }


        [MaxLength(11 , ErrorMessage ="PhoneNumber must be 11 numbers")]
        [DataType(DataType.PhoneNumber)]

        public string phoneNum { get; set; }


        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime joinDate { get; set; }




    }
}