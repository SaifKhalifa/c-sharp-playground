/*
    Task 5 – Stack & Queue
    
    Implement:
        - A Stack-based solution for a simple problem such as checking balanced parentheses.
        - A Queue-based solution representing a basic customer/service queue.
*/

namespace task_5_stack_queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> balance = new Stack<char>();

            Console.Write("your string: ");
            string parentheses = Console.ReadLine();

            if (parentheses == null || parentheses == "")
            {
                Console.WriteLine("\nNULL???, Please enter a valid value!");
                // exit
                Environment.Exit(0);
            }
            else
            {
                char[] chars = parentheses.ToArray();

                for (int i = 0; i < chars.Length; i++)
                {
                    if (chars[i] == '(')
                        balance.Push(chars[i]);
                    else if (chars[i] == ')')
                        balance.Pop();
                    else
                        continue;
                }

            }

            if (balance.Count == 0)
            {
                Console.WriteLine("VALID");
            }
            else
                Console.WriteLine("NOT VALID!");
        }
    }
}
