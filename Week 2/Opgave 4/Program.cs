using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDataStructures;

namespace Opgave_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var checks = new Checks();
            Console.WriteLine(checks.CheckBrackets("( ( ( ) ( ) ) ) "));
            Console.WriteLine(checks.CheckBrackets("( ) )"));
            Console.WriteLine(checks.CheckBracketsV2("[ ( ( [ ] ) ) ( ) ] "));
            Console.WriteLine(checks.CheckBracketsV2("( [ ) ]"));
        }
    }

    public class Checks : Stack<char>
    {
        public bool CheckBrackets(String s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    Push(s[i]);
                }
                if (s[i] == ')')
                {
                    if (!HasItems || Top() != '(')
                    {
                        return false;
                    }
                    Pop();
                }
            }

            return !HasItems;
        }

        public bool CheckBracketsV2(String s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '[')
                {
                    Push(s[i]);
                }
                if (s[i] == ')' || s[i] == ']')
                {
                    if (!HasItems || 
                        (s[i] == ')' && Top() != '(') ||
                        (s[i] == ']' && Top() != '['))
                    {
                        return false;
                    }
                    Pop();
                }
            }

            return !HasItems;
        }
    }
}
