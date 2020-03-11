using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculaorV2
{
    class ProblemSolver
    {
       // public OperationList = new List<string>();
        public double calculate(double value1, double value2, string operacion)
        {
            double resultado=0;
            

             switch (operacion)//bro usaria char
             {
                  
                   

              case "+":
              resultado = value1 + value2;
                        // return result;
              break;

              case "-":
              resultado = value1 - value2;
                    //return result;
                    break;
              case "*":

              resultado = value1 * value2;
                        //return result;
              break;
              case "/":
              resultado = value1 / value2;
                        // return result
              break;
              case "_":
              break;
              default:
           
                    throw new InvalidOperationException("operation not recognized");


             }

           
            return resultado;
        }
        //operate priority */ new method
        public double OperateSection(int pointA, int pointB,ref List<string> OperationList)// calculate section //
        {
            double solution = 0;
            if (pointA == pointB)
            {
                if (!double.TryParse(OperationList[pointA], out solution)) throw new ArgumentException("expected numeric value in c0");
                return solution;
            }
            string viewoplist = "f";
            string viewoplist2 = "f";
            double auxValue1 = 0;
            double auxValue2 = 0;
            for (int i = pointA; i< pointB; i++)//punto a es 1a
            {
                viewoplist = OperationList[i];
                viewoplist2 = OperationList[i + 1];
                if (i== pointA )//first number
                {
                    if (!double.TryParse(OperationList[i], out auxValue1)) throw new ArgumentException("expected numeric value in c1");

                    
                    
                }
                else if (OperationList[i]=="+"|| OperationList[i] == "-"|| OperationList[i] == "*"|| OperationList[i] == "/")//ranges wrong
                {
                    if (!double.TryParse(OperationList[i+1], out auxValue2)) throw new ArgumentException("expected numeric value in c2");

                    solution = calculate(auxValue1, auxValue2, OperationList[i]);
                    i++;
                    auxValue1 = solution;
                }
                
                //solution = calculate(auxValue, d);
               
            }



            return solution;
        }
           
        public void GenerateStringList(string data, ref List<string> OperationList)//generates separated list// add detect calculator sign(-4)
        {
           char latestElement='_';
           bool negate = false;
           foreach(char element in data)
           {
                if (element == '+' || element == '-' )
                {
                    if (latestElement == '_' || latestElement == '(') 
                    { 
                        negate = true;
                        latestElement = element;
                        }
                    else
                    {
                        latestElement = element;
                        OperationList.Add(element.ToString());
                    }
                        
                }




                if ( element == '*' || element == '/'|| element == '('|| element == ')')
                {
                    
                    latestElement = element;
                    OperationList.Add(element.ToString());
                }
                else if (char.IsDigit(element))// o','
                {
                    if (char.IsDigit(latestElement))//o ','
                    {
                        latestElement = element;
                        OperationList[OperationList.Count -1] = Convert.ToString(string.Format("{0}{1}", OperationList[ OperationList.Count-1], element));//mirar si es count o count-1
                    }
                    else
                    {
                        if (negate == true)
                        {
                            OperationList.Add(Convert.ToString(string.Format("{0}{1}", '-', element)));
                            latestElement = element;
                            negate = false;
                        }
                        else 
                        {
                            latestElement = element;
                            OperationList.Add(element.ToString());
                        }
                        
                    }              
                }
           }
        }
        public double SolveOperation(string data , ref List<string> OperationList)
        {
            
            //OperationList = new List<string>();
            GenerateStringList(data,ref OperationList);
            double solution = ParesntesisDephtSearch(ref OperationList);

            return solution ;
        }
        public double ParesntesisDephtSearch(ref List<string> OperationList)
        {
            double solution = 0;
            while (OperationList.Count > 1)//outside condition 
            {
                int parentesisOpen = 0;
                int parentesisClosed = 0;
                bool triggerParentesisOpen = false;
                bool triggerParentesisClosed = false;
                for (int i = 0; i <= OperationList.Count; i++)// search parentesis
                {
                    if (OperationList[i] == "(")
                    {
                        parentesisOpen = i+1;
                        triggerParentesisOpen = true;
                    }
                    else if (OperationList[i] == ")")
                    {
                        parentesisClosed = i-1;
                        triggerParentesisClosed = true;
                    }
                    if (triggerParentesisOpen == true && triggerParentesisClosed == true)
                    {
                        solution = OperateSection(parentesisOpen, parentesisClosed, ref OperationList);//no opera correctamente
                        
                        OperationList.RemoveRange(parentesisOpen  ,parentesisClosed-parentesisOpen+2); ///peat aqui
                        OperationList[parentesisOpen-1] = solution.ToString();
                        break;
                        
                    }

                }
                if (!OperationList.Contains("("))
                {
                    solution = OperateSection(0, OperationList.Count-1, ref OperationList);
                    OperationList.RemoveRange(1,  OperationList.Count-1 ); ///peat aqui
                    OperationList[0] = solution.ToString();
                }
            }
            return solution;
        }


    }
}
