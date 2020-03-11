using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculaorV2
{
    class SortCalculations
    {
        
        
        public void  sortOperations(string input,out List<double> numbers, out List<char> operation)
        {
                // numbers             = new List<double>();
            //operation           = new List<int>();
            var characterList   = new List<char>();                
            characterList.AddRange(input);
            numbers = new List<double>() ;
            operation = new List<char> { '0' };
            paresntesisDephtSearch(characterList, ref numbers, ref operation);

            //for tests
            //numbers = new List<double> { 1, 3, 5, 7, 9 };
            //operation = new List<char> { '0', '+', '+', '+', '+' };
            
        }
        public void paresntesisDephtSearch(List<char> characterList,ref List<double> numbers, ref List<char> operation)//depth search parentesis
        {
            int i = 0;
            int x1 = 0;
            int x2 = 0;
            bool trigger1 = false;
            bool trigger2 = false;

            while (characterList.Contains('(') == true)//depth search parentesis
            {
                if (characterList[i] == '(')
                {
                    x1 = i;
                    trigger1 = true;
                }
                else if (characterList[i] == ')')
                {
                    x2 = i;
                    trigger2 = true;
                }
                if ((trigger1 == true) && (trigger2 == true))
                {
                    characterInterpreter(x1, x2, characterList,ref  numbers, ref operation);
                    trigger1 = false;
                    trigger2 = false;
                    i = 0;
                }
                i++;
            }
        }
        public void characterInterpreter(int indexOpenParentesis, int indexCloseParentesis, List<char> charList,ref List<double> numbers,ref List<char> operation) //has to be a better way to get this variable acccesible
        {
            for (int i = indexOpenParentesis + 1; i <= indexCloseParentesis; i++)//revisar
            {//character is symbol
                if (charList[i] == '+')
                {
                    if (char.IsNumber(charList[i - 1])) { operation.Add(charList[i]); }         //if its a opertion marker add to operation
                    else { break; }                                                             //if it's a sign marker do nothing
                }                                                                               //break and iterate for next symbol
                if (charList[i] == '-')
                {
                    if (char.IsNumber(charList[i - 1])) { operation.Add(charList[i]); }         // if it is operation marker add to op
                    else                                                                        //if it's a sign marker
                    {
                        numbers.Add((Single)char.GetNumericValue(charList[i + 1]) * -1);        //save folowing number as a negative          
                        i++;                                                                    //break and fun for next character
                        break;
                    }

                }
                if (charList[i] == '*') { operation.Add(charList[i]); }
                if (charList[i] == '/') { operation.Add(charList[i]); }
                //character is number
                if (char.IsNumber(charList[i]))
                {
                    if (char.IsNumber(charList[i - 1]))                                               //if preciding number was a number ad character to number
                    {
                        double value = numbers[numbers.Count];
                        numbers[numbers.Count] = Convert.ToDouble(string.Format("{0}{1}", value, charList[i]));
                    }
                    else if (charList[i - 1] == ',')  //precidin number is coma add coma to number 
                    {
                        Console.WriteLine("implement comas");
                    }
                    else if (!char.IsNumber(charList[i - 1]))                                             //if preciding number was a number ad character to number
                    {
                        numbers.Add((Single)char.GetNumericValue(charList[i]));
                    }
                }

            }
           
         //   unwindParentesis(indexOpenParentesis, indexCloseParentesis, charList, numbers, operation);
            markAsTranscribed(indexOpenParentesis, indexCloseParentesis, charList);
        }
        //public void unwindparentesis(int x1, int x2, list<char> characterlist, list<double> numbers, list<char> operation)//out of the depht parentesis this function shall seach the numbers outside to feed to the function who orders the operations if a parentesis is found it shall save the the opertion and feed the modified char array back to depht search
        //{ // explore outside of parentesis (left & righ and feed the coordinades to char interpreter yet again)
        //  //has to remove o nullify sections already translated and feed them yet again to parentesis in depht  search
        //  //if no parentesis found finish & calculate
        //    if (x1 != 0) //search left
        //    {

        //        for (int i = x1; i == 0; i--)
        //        {
        //            if (characterlist[i] == '(')
        //            {
        //                characterinterpreter(i, x1, characterlist, ref numbers, ref operation);
        //                //markastranscribed(i, x1, characterlist);
        //                break;
        //            }
        //        }
        //    }
        //    if (x2 != characterlist.count())//search right
        //    {


        //        for (int i = x2; i == characterlist.count(); i++)
        //        {
        //            if (characterlist[i] == ')')
        //            {
        //                characterinterpreter(x2, i, characterlist, ref numbers, ref operation);
        //                //markastranscribed(x2, i, characterlist);
        //                break; //falta si  9+4()7+8
        //            }

        //        }

        //    }
        //}
        public void markAsTranscribed(int a, int b, List<char> charList)
        {
            for(int i =a; i<=b; i++)//it removes parentesis ad numbers
            {
                charList.RemoveAt(i);
            }
        }
    }
}
