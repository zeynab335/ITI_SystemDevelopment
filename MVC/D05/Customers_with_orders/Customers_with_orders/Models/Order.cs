using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Customers_with_orders.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Date is Required")]
        [DataType(DataType.DateTime)]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "TotalPrice is Required")]
        public decimal TotalPrice { get; set; }

        [ForeignKey("Customer")]
        public int CustID { get; set; }

        public virtual Customer Customer { get; set; }
    }
}