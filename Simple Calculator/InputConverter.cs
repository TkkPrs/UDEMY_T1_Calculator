using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Calculator
{
    class getAllDigits
    {
        public static double ConvertToDouble(string uImput)
        {
            if (!double.TryParse(uImput, out double number)) throw new ArgumentException("expected numeric value!");
            return number;
        }

        public static List<string> ParseInput(string input)
        {
            List<string> parsedInput = new List<string>();
            for (int i=0; i<input.Length; i++)
            {
                char currentChar = input[i];
                if (IsNumber(currentChar))
                {
                    int lastDigitIndex;
                    string number = GetFullNumber(input, i, out lastDigitIndex);
                    parsedInput.Add(number);
                    // as we have read more than one index, we must update the i with the last index of the number 
                    i = lastDigitIndex;
                }
                else if (IsOperation(currentChar))
                {
                    parsedInput.Add(currentChar.ToString());
                }
                else if (IsParenthesis(currentChar))
                {
                    parsedInput.Add(currentChar.ToString());
                }
            }
            return parsedInput;
        }
        public static bool IsNumber(char input)
        {
            return char.IsNumber(input);
        }

        public static bool IsOperation(char input)
        {
            switch(input)
            {
                case '+':
                case '-':
                case '*':
                case '/':
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsParenthesis(char input)
        {
            return (('(' == input) || (')' == input));
        }

        /// <summary>
        /// PRE: startIndex is a number
        /// </summary>
        /// <param name="charArray"></param>
        /// <param name="startIndex"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string GetFullNumber(string inputString, int startIndex, out int lastDigitIndex)
        {
           int index = startIndex;
            do
            {
                index++;
            } while (index < inputString.Length && IsNumber(inputString[index]));
            lastDigitIndex = index - 1;
            int length = lastDigitIndex - startIndex;
            return inputString.Substring(startIndex, length);
        }
    }
}
