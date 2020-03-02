using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Calculator
{
    class InputConverter
    {
        public double convertToDouble(string uImput)
        {
            double number;
            if (!double.TryParse(uImput, out number)) throw new ArgumentException("expected numeric value!");
            
               
            
                
            return number;
        }
    }
}
