using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculaorV2
{
    class Calculate
    {
        public double calculate (List<double> number, List<char> opertion)
        {
            double value = 0;
            for (int i=0; i<number.Count; i++) //foreach is better? for this?no bacuse i need th i var


            {
               
                switch (opertion[i])//bro usaria char
                {
                    case '0'://get number
                        value = number[i];
                        break;

                    case '+':

                        value = value+ number[i] ;
                        // return result;
                        break;

                    case '-':
                   
                        value = value-number[i] ;
                        //return result;
                        break;
                    case '*':
                    
                        value = value * number[i];
                        //return result;
                        break;
                  
                    case '/':
                        value = value/ number[i];
                        // return result;
                        break;
                    default:
                        throw new InvalidOperationException("operation not recognized");


                }

            }
            return value;
        }
    }
}
