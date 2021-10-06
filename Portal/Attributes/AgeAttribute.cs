using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Attributes
{
    public class AgeAttribute : ValidationAttribute
    {
        readonly int _minAge;
        public AgeAttribute(int minAge)
        {
            _minAge = minAge;
        }

        public override bool IsValid(object value)
        {
            if (value is DateTime time)
            {
                return DateTime.Now.Year - time.Year >= _minAge;
            }

            return false;
        }
    }
}
