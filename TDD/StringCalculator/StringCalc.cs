using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    public class StringCalculator
    {

        private List<string> _delimiters = new List<string> { ",", "\n" };
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

            FilterNumbersList(splitNumbers);
            return splitNumbers.Sum();
        }




        private List<int> SplitNumbersWithCustomDelimiter(string numbers)
        {
            var delimiter = GetCustomDelimiter(numbers);
            _delimiters.Add(delimiter);


            return SplitNumbers(numbers.Remove(0, CustomDelimiterThingy.Length + delimiter.Length));
        }

        private List<int> SplitNumbers(string numbers)
        {
            var splitNumbers = numbers.Split(_delimiters.ToArray(), StringSplitOptions.None).ToList();
            splitNumbers.RemoveAll(x => x == string.Empty);


            return splitNumbers.Select(int.Parse).ToList();
        }

        private string GetCustomDelimiter(string numbers)
        {
            return numbers.Substring(2, numbers.IndexOf('\n') - 2);

        }

        private void FilterNumbersList(List<int> numbers)
        {
            if (numbers.Any(x => x < 0)) throw new NegativeNumbersException(numbers.Where(x => x < 0).ToList());
            numbers.RemoveAll(x => x > 1000);               

        }
    }

    public class NegativeNumbersException : Exception
    {
        public NegativeNumbersException(List<int> negatives) 
          
        {
            var numberstring = string.Join(", ", negatives);
            Message = "Negative Numbers Are Not Alowed: " + numberstring;

        }
        public override string Message { get; }
    }
}
