using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_1
{
    class Program
    {
        static void Main(string[] args)
        {
            printLetters(3);
            Console.WriteLine();

            printLetters2(3, 5);
            Console.WriteLine();

            printLetters2(2, 0);
            Console.WriteLine();

            string testString = "was it a car or a cat I saw?";
            Console.WriteLine($"Is '{testString}' palindroom?: {isPalindroom(testString)}");
        }

        static void printLetters(int n)
        {
            if (n < 1) return;

            Console.Write("A");
            printLetters(n - 1);
            Console.Write("Z");
        }

        static void printLetters2(int p, int q)
        {
            if (p < 1 && q < 1) return;

            if (p > 0) Console.Write("A");
            printLetters2(p - 1, q - 1);
            if (q > 0) Console.Write("Z");
        }

        static bool isPalindroom(string s)
        {
            s = s.ToLower();
            if (s.Length <= 1) return true;

            if (!Char.IsLetter(s[0])) return isPalindroom(s.Substring(1));
            if (!Char.IsLetter(s[s.Length - 1])) return isPalindroom(s.Substring(0, s.Length - 1));

            if (s[0] == s[s.Length - 1])
            {
                return isPalindroom(s.Substring(1, s.Length - 2));
            }
            return false;
        }       
    }
}
