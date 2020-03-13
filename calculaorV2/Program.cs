using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculaorV2
{
    class Program
    {
        

        static void Main(string[] args)
        {
            try
            {
                List<string> OperationList = new List<string>();
               // SortCalculations sortCalculaton = new SortCalculations();
                //Calculate calculate = new Calculate();
                ProblemSolver problemSolver = new ProblemSolver();
                string input = "-19+3*(-5-6)*2+(-32-+2)";
                //string input = "19+(7+(5+(1+3)))";
                // Console.ReadLine();

                //Array numbers = sortNumbers.sortO( input);
                //sortCalculaton.sortOperations(input, out List<double> numbers, out List<char> operation);
                // List<int> operation = SortCalculations.operation(input);
                // double [] numbers = new double [] { 1, 3, 5, 7, 9 };
                //List<double> operation = new List<double> { 0,1,1,1,1 };
                //Double result = calculate.calculate(numbers, operation);
                problemSolver.SolveOperation(input,ref OperationList);
                    
                Console.WriteLine("answer is:{0}",OperationList[0]);
                Console.ReadLine();
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message, ex.Source);
                Console.ReadLine();
            }


        }
    }
}
