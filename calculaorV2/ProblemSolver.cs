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
       
        public void SolveOperation(string data , ref List<string> OperationList)
        {   //OperationList = new List<string>();
            GenerateStringList(data,ref OperationList);
            ParesntesisDephtSearch(ref OperationList);
            
        }
        public void GenerateStringList(string data, ref List<string> OperationList)//generates separated list// add detect calculator sign(-4)
        {
            char latestElement = '_';
            bool negate = false;
            foreach (char element in data)
            {
                if (element == '+' || element == '-')
                {
                    if (latestElement == '_' || latestElement == '('|| latestElement == '*' || latestElement == '/' || latestElement == '-' || latestElement == '+')
                    {
                        if(element == '-') { negate = true; }
                        latestElement = element;
                    }
                    else
                    {
                        latestElement = element;
                        OperationList.Add(element.ToString());
                    }

                }
                if (element == '*' || element == '/' || element == '(' || element == ')')
                {

                    latestElement = element;
                    OperationList.Add(element.ToString());
                }
                else if (char.IsDigit(element))// o','
                {
                    if (char.IsDigit(latestElement))//o ','
                    {
                        latestElement = element;
                        OperationList[OperationList.Count - 1] = Convert.ToString(string.Format("{0}{1}", OperationList[OperationList.Count - 1], element));//mirar si es count o count-1
                    }
                    else
                    {
                        if (negate == true)
                        {
                            OperationList.Add(Convert.ToString(string.Format("{0}{1}", '-', element)));
                            //new 
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
        public void ParesntesisDephtSearch(ref List<string> OperationList)
        {
       
            while (OperationList.Count > 1)//outside condition 
            {
                int parentesisOpen = 0;
                int parentesisClosed = 0;
                bool triggerParentesisOpen = false;
                bool triggerParentesisClosed = false;
                for (int i = 0; i <= OperationList.Count; i++)// search parentesis
                {
                    if (!OperationList.Contains("("))
                    {
                        OperateSection(0, OperationList.Count - 1, ref OperationList);
                        break;
                    }
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
                        OperateSection(parentesisOpen, parentesisClosed, ref OperationList);//no opera correctamente
                        //new method operate
                        //OperationList.RemoveRange(parentesisOpen  ,parentesisClosed-parentesisOpen+2); ///peat aqui
                        OperationList.RemoveAt(parentesisOpen + 1);
                        OperationList.RemoveAt(parentesisOpen - 1);
                        break;
                    }
                        
                }
                
            }
        }
        public double Calculate(double value1, double value2, string operacion)
        {
            double resultado = 0;
            switch (operacion)//bro usaria char
            {
                case "+":
                    resultado = value1 + value2;
                    break;
                case "-":
                    resultado = value1 - value2;
                    break;
                case "*":
                    resultado = value1 * value2;
                    break;
                case "/":
                    resultado = value1 / value2;
                    break;
                default:
                    throw new InvalidOperationException("operation not recognized");
            }
            return resultado;
        }
        //operate priority */ new method
        public void OperateSection(int pointA, int pointB, ref List<string> OperationList)// calculate section //
        {
            double solution = 0;
            double auxValue1 = 0;
            double auxValue2 = 0;
            for (int i = pointA; i < pointB; i++)
            {
                if(OperationList[i]=="*"|| OperationList[i] == "/")
                {
                    if (!double.TryParse(OperationList[i-1], out auxValue1)) throw new ArgumentException("expected numeric value in c1");
                    if (!double.TryParse(OperationList[i+1], out auxValue2)) throw new ArgumentException("expected numeric value in c2");
                    solution=Calculate(auxValue1, auxValue2, OperationList[i]);
                    OperationList[i] = solution.ToString();
                    OperationList.RemoveAt(i + 1);
                    OperationList.RemoveAt(i - 1);
                    pointB = pointB - 2;
                    i--;
                }                                                          
            }
            for (int i = pointA; i < pointB; i++)
            {
                if (OperationList[i] == "+" || OperationList[i] == "-")
                {
                    if (!double.TryParse(OperationList[i-1], out auxValue1)) throw new ArgumentException("expected numeric value in c3");
                    if (!double.TryParse(OperationList[i+1], out auxValue2)) throw new ArgumentException("expected numeric value in c4");
                    solution = Calculate(auxValue1, auxValue2, OperationList[i]);
                    OperationList[i] = solution.ToString();
                    OperationList.RemoveAt(i + 1);
                    OperationList.RemoveAt(i - 1);
                    pointB = pointB - 2;
                    i--;
                }
            }
        }
    }
}
