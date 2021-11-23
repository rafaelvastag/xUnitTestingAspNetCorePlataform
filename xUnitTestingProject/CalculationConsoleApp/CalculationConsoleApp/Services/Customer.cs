using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationConsoleApp.Services
{
    public class Customer
    {
        public string Name => "Aref";
        public int Age => 35;

        public virtual int GetOrdersByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Null Name");
            }

            return name.Length;
        }
    }
}
