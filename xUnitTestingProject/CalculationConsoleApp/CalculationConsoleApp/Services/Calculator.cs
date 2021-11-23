using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationConsoleApp.Services
{
    public interface Calculator
    {
        int Add(int a, int b);
        double AddDouble(double a, double b);
    }
}
