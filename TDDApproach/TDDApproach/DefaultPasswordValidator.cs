using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDApproach
{
    public class DefaultPasswordValidator : IPasswordValidator
    {
        public bool Validate(string password)
        {
            if (password.Length < 8) return false;
            if (!password.Any(x => char.IsUpper(x))) return false;

            return true;
        }
    }
}
