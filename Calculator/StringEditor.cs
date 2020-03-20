

using System;
using System.Collections.Generic;

namespace Calculator
{
    public static class StringEditor
    {
        private static List<string> NumbersChar = new List<string>
        {
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
        };
        private static List<string> ActionSymbols = new List<string>
        {
            "-", "+", "*", "/"
        };
        public static int GetLastSymbolIndex(string text)
        {
            return text.Length - 1;
        }

        public static string GetLastSymbol(string text)
        {
            var index = GetLastSymbolIndex(text);
            if (index < 0)
            {
                return null;
            }
            else
            {
                return text.Substring(index, 1);
            }
        }
        public static string GetTextWithOutLastSymbol(string text)
        {
            var indexOfLastChar = StringEditor.GetLastSymbolIndex(text);
            if (indexOfLastChar >= 0)
            {
                return text.Remove(indexOfLastChar, 1);
            }
            else return text;
        }

        public static bool IsNumber(string symbol)
        {
            return NumbersChar.Contains(symbol);
        }
        public static bool IsAction(string symbol)
        {
            return ActionSymbols.Contains(symbol);
        }

        public static string AddSymbol(string text, string symbol)
        {
            if (IsNumber(symbol))
            {
                text += symbol;
            }
            else if (IsAction(symbol))
            {
                text = AddAction(text, symbol);
            }

            return text;
        }

        public static string AddAction(string text, string symbol)
        {
            if (text.Length < 1)
            {
                return string.Empty; 
            }
            var lastSymbol = GetLastSymbol(text);
            if (IsAction(lastSymbol))
            {
                text = text.Remove(text.Length - 1, 1);
                text += symbol;
            }
            else
            {
                text += symbol;
            }
            return text;
        }

    }
}
