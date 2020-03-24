using System.Collections.Generic;

namespace Calculator
{
    public static class ExpressionEditor
    {
        private static readonly List<char> Numbers = new List<char>
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };
        private static readonly List<char> ActionSymbols = new List<char>
        {
            '-', '+', '*', '/'
        };

        public static string AddSymbol(string text, char symbol)
        {
            var exp = new Expression(text);

            if (IsNumber(symbol))
            {
                AddNumber(exp, symbol);
            }
            else if (IsAction(symbol))
            {
                AddAction(exp, symbol);
            }

            return exp.Text;
        }
        public static bool IsNumber(char symbol)
        {
            return Numbers.Contains(symbol);
        }
        public static bool IsAction(char? symbol)
        {
            if (!symbol.HasValue)
            {
                return false;
            }
            else
            {
                return ActionSymbols.Contains(symbol.Value);
            }
        }
        public static void AddNumber(Expression exp, char symbol)
        {
            if (exp != null)
            {
                exp.Text += symbol;
            }           
        }
        public static void AddAction(Expression exp, char symbol)
        {
            if (exp == null || exp.IsEmpty)
            {
                return;
            }
           
            else if (IsAction(exp.LastSymbol))
            {
                DeleteLastSymbol(exp);
                exp.Text += symbol;
            }
            else
            {
                exp.Text += symbol;
            }
            
        }
        public static void DeleteLastSymbol(Expression exp)
        {
            if (exp != null && !exp.IsEmpty)            
            {
                exp.Text = exp.Text.Remove(exp.LastSymbolIndex, 1);
            }
        }
    }
}
