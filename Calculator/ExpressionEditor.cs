using System.Collections.Generic;

namespace Calculator
{
    public static class ExpressionEditor
    {
        private static readonly List<string> Numbers = new List<string>
        {
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
        };
        private static readonly List<string> ActionSymbols = new List<string>
        {
            "-", "+", "*", "/"
        };

        public static string AddSymbol(string text, string symbol)
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
        public static bool IsNumber(string symbol)
        {
            return Numbers.Contains(symbol);
        }
        public static bool IsAction(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                return false;
            }
            else
            {
                return ActionSymbols.Contains(symbol);
            }
        }
        public static void AddNumber(Expression exp, string symbol)
        {
            if (exp != null)
            {
                exp.Text += symbol;
            }           
        }
        public static void AddAction(Expression exp, string symbol)
        {
            if (exp == null || exp.IsEmpty)
            {
                return;
            }
           
            else if (IsAction(exp.LastSymbol?.ToString()))
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
