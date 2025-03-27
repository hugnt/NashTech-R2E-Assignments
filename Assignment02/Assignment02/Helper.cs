using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02;

public static class Helper
{
    public static (bool, char) IsValidCharacter(this string str, List<char> lstCharacters)
    {
        return (char.TryParse(str,out char strParsed)&& lstCharacters.Contains(strParsed), strParsed);
    }
    public static (bool, string) IsValidInputString(this string str)
    {
        return (str != null && str.Trim() != "", str?.Trim()??"");
    }
    public static bool IsBetweenNumber(this int currentNumber, int minNumber, int maxNumber)
    {
        return currentNumber > minNumber && currentNumber < maxNumber;
    }

    public static (bool,DateTime) IsValidDateFormat(this string dateTimeStr, string format)
    {
        if(DateTime.TryParseExact(dateTimeStr, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime))
        {
            return (true, dateTime);
        }
        return (false, DateTime.Now);
    }

    public static T GetInputValidated<T>(string label, string strError, Func<string, (bool, T)> validateFunc)
    {
        var isValidMake = true;
        T returnVal = default(T);
        do
        {
            Console.Write(label);
            var inputVal = validateFunc(Console.ReadLine());
            isValidMake = inputVal.Item1;

            if (!isValidMake) Console.WriteLine(strError);
            else returnVal = inputVal.Item2;
        } while (!isValidMake);
        return returnVal;

    }
}
