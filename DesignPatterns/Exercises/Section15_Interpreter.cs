using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Exercises.Section15_Interpreter
{
    public class ExpressionProcessor
    {
        public Dictionary<char, int> Variables = new Dictionary<char, int>();

        public int Calculate(string expression)
        {
            int result = 0;
            char operation = '+';

            for (int i = 0; i < expression.Length; i++)
            {
                switch (expression[i])
                {
                    case '+':
                    case '-':
                        if (operation != ' ') return 0;
                        operation = expression[i];
                        break;
                    default:
                        if (operation == ' ') return 0;
                        if (char.IsDigit(expression[i]))
                        {
                            var builder = new StringBuilder(expression[i]);
                            for (; i < expression.Length && char.IsDigit(expression[i]); i++)
                            {
                                builder.Append(expression[i]);
                            }
                            result = Operate(operation, result, int.Parse(builder.ToString()));
                            operation = ' ';
                            i--;
                        }
                        else if (char.IsLower(expression[i]))
                        {
                            if (!Variables.ContainsKey(expression[i])) return 0;
                            result = Operate(operation, result, Variables[expression[i]]);
                            operation = ' ';
                        }
                        else return 0;
                        break;
                }
            }

            return result;
        }

        private static int Operate(char operation, int left, int right)
        {
            var result = operation switch
            {
                '+' => left + right,
                '-' => left - right,
                _ => 0
            };
            return result;
        }
    }
}
