using System.ComponentModel.DataAnnotations;

namespace CarAssignment.Validators
{
    public class DateInPastAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            // accetpt nullable
            DateTime? dateTime = value as DateTime?;

            if (dateTime is null) return false;
           
            else return dateTime < DateTime.Now ;
            

        }
    }
}
