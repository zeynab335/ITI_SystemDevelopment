using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Customers_with_orders.Models
{
    public class StartWith : ValidationAttribute
    {
        char Value;

       public StartWith(char c)
        {
            Value = c;
        }

        public override bool IsValid(object Object)
        {

            if (Object == null)
            {
                return false;
            }
            else
            {
                if (Object is string)
                {
                   string s = (string)Object;
                    if (s.ToCharArray()[0].Equals(Value))
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessage = "Name not start with this character + " + Value; //user validation error

                        return false;
                    }
                }
                else
                {
                    ErrorMessage = "not valid type " + Value; //user validation error
                    return false;

                }
            }
        }
    }

}