using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

//_exercise_1_
namespace ValidationEngine
{
    public class Validator
    {
        public bool ValidateEmailAddress(string emailAdress)
        {
            if (emailAdress == null)                    throw new ArgumentNullException();
            if (emailAdress.Any(char.IsDigit))          throw new AdressContainsNumbersException();
            if (emailAdress.Count(x => x == '@') > 1)   throw new AdressContainsmultipleShnabelAException();
            if (emailAdress.Count(x => x == '.') > 1)   throw new AdressdoublePunctioationException();

            if (Regex.IsMatch(

                input: emailAdress,
                pattern: @"\A(?:[a-z!#$%&'*+/=?^_`{|}~-]*@(?:[a-z](?:[a-z-]+[a-z])?\.)+[a-z](?:[a-z-]*[a-z])?)\Z",
                options: RegexOptions.IgnoreCase

                )) return true;

            throw new AdressBadFormatException();
        }

    }
    #region Exceptions

    public class AdressContainsNumbersException : Exception
    {
        public AdressContainsNumbersException()
        {

        }
        public AdressContainsNumbersException(string message)
            : base(message)
        {

            message = "the addres contains numbers\n numbers in address is not allowed";
        }
    }

    public class AdressContainsmultipleShnabelAException : Exception
    {
        public AdressContainsmultipleShnabelAException()
        {

        }

        public AdressContainsmultipleShnabelAException(string message)
            : base(message)
        {

            message = @"the adress contains more than one '@'" + "\n multiple ShnabelA is not allowed";
        }
    }

    public class AdressBadFormatException : Exception
    {
        public AdressBadFormatException()
        {

        }

        public AdressBadFormatException(string message)
            : base(message)
        {
            message =
                "the adress suffers from bad formating,\n the correct format is - onlyalphabetics@email.whatever - plz refactor and try again";
        }
    }

    public class AdressdoublePunctioationException : Exception
    {
        public AdressdoublePunctioationException()
        {

        }

        public AdressdoublePunctioationException(string message)
            : base(message)
        {
            message = "you cant use punctioations like crazy!!";
        }
    }

    #endregion
}
