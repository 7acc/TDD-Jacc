using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    public class StringCalculator
    {


        private  List<string> Delimiters = new List<string> { ",", "\n" };
 
        private string CustomDelimiterThingy = "//";

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)) return 0;

            List<int> splitNumbers;
            if (numbers.StartsWith(CustomDelimiterThingy))
            {
                 splitNumbers = SplitNumbersWithCustomDelimiter(numbers);
            }
            else
            {
                 splitNumbers = SplitNumbers(numbers);

            }

            

       
            return splitNumbers.Sum();
        }

        private List<int> SplitNumbersWithCustomDelimiter(string numbers)
        {
            var delimiter = GetCustomDelimiter(numbers);
            Delimiters.Add(delimiter);
            

           return SplitNumbers(numbers.Remove(0, CustomDelimiterThingy.Length + delimiter.Length));
        }

        private string GetCustomDelimiter(string numbers)
        {
            return numbers.Substring(2, numbers.IndexOf('\n') - 2);
           
        }


        //-------------------------------------------------------------------------------------------------------

        public List<int> SplitNumbers(string numbers)
        {
           var splitNumbers = numbers.Split(Delimiters.ToArray(), StringSplitOptions.None).ToList();
            splitNumbers.RemoveAll(x => x == string.Empty);
        
         


            return splitNumbers.Select(int.Parse).ToList();
        }

    }
}
