using System;
using System.Text.RegularExpressions;

namespace Perfect_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            string StringToCheck = "00111101011001";
            Console.WriteLine("Count 0s: " + Regex.Matches(StringToCheck, "0").Count);
            Console.WriteLine("Count 1s: " + Regex.Matches(StringToCheck, "1").Count);

            Console.WriteLine("Is good: " + IsGoodBinaryString(StringToCheck));
            Console.ReadKey();
        }

        static bool IsGoodBinaryString(string BinStr)
        {
            /*
             * The following two booleans will track our two conditions that have to be true to determine whether a binary
             * string is good.
            */

            // The number of 0's is equal to the number of 1's. Assume false, until true.
            bool EqualBitCounts = false;

            /* 
             * For every prefix of the binary string, the number of 1's should not be less than the number of 0's. 
                Assume true, mark false once we find that 0's outnumber 1's in prefix.
            */
            bool PrefixOnesNeverLessThanZeros = true;

            // The following two variables to keep count of 1s and 0s:
            int ZeroCount = 0;
            int OneCount = 0;

            foreach(char ch in BinStr.ToCharArray())
            {
                if (ch == '0')
                {
                    ZeroCount++;
                } 
                else if(ch == '1')
                {
                    OneCount++;
                }
                else
                {
                    throw new System.FormatException("Invalid character found in incoming string. Found " + ch + " in string. Expecting only 0s and 1s.");
                }

                /*
                 * The second condition requires that 0's should not outnumber 1's for any prefix. We could just return false
                 * here, but for clarity we'll just break the loop.
                */
                if(ZeroCount > OneCount)
                {
                    PrefixOnesNeverLessThanZeros = false;
                    break;
                }
            }

            // Both conditions should be true to determine a good binary string:
            return (EqualBitCounts && PrefixOnesNeverLessThanZeros);
        }
    }
}
