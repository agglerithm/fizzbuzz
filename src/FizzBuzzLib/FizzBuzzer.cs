using System;
using System.Collections.Generic; 

namespace FizzBuzzLib
{
    public interface IFizzBuzzer
    {
        string[] GetFizzBuzzList(int upperBound);
        string[] GetCustomFizzBuzzList(int upperBound, IDictionary<int, string> customDefinition);
    }

    public class FizzBuzzer : IFizzBuzzer
    {
        public string[] GetFizzBuzzList(int upperBound)
        {
            var dic = new Dictionary<int, string>();
            dic[3] = "Fizz";
            dic[5] = "Buzz";
            return buildList(upperBound, dic);
        }

        private  string[] buildList(int upperBound, IDictionary<int, string> definition)
        {
            if (upperBound < 1)
                throw new ArgumentOutOfRangeException("Cannot produce a list with this upper bound!");
            var lst = new List<string>();
            var remainders = new List<int>();
            for (int i = 1; i <= upperBound; i++)
            {
                var tempStr = "";
                var matchFound = true;
                foreach (var pair in definition)
                {
                    var tempNum = i%pair.Key;
                    if (tempNum == 0)
                    {
                        matchFound = false;
                        tempStr += pair.Value;
                    }
                } 
                if (matchFound)
                    tempStr = i.ToString();
                lst.Add(tempStr); 
            }
            return lst.ToArray();
        }

        public string[] GetCustomFizzBuzzList(int upperBound, IDictionary<int, string> customDefinition)
        {
            return buildList(upperBound, customDefinition);
        }
         
    }
}
