using System;
using System.Collections.Generic;

namespace Calculator
{
    public class CalculateExpression : ICalculate
    {
        /// <summary>
        /// ActionSymbol - AS
        /// </summary>
        public static List<char> ActionSymbol = new List<char>()
        {
            '/','*','+','-'
        };
        public int GetResult(string expression)
        {
            
            foreach (var act in ActionSymbol)
            {
                var actId = expression.IndexOf(act);
                while (actId > -1)
                {
                    expression = GetChangedExp(expression, actId, act);
                    actId = expression.IndexOf(act);
                    Console.WriteLine(expression);
                }
            }


            return Int32.Parse(expression);
        }
        
        public static string GetLeftNumber(string exp, int index)
        {
            var ddd = exp.Remove(index);
            return ddd.Substring(GetLastASIndex(ddd) + 1);
        }
        public static int GetLastASIndex(string exp)
        {
            int lastIndex = -1;
            foreach (var ch in ActionSymbol)
            {
                var ind = exp.LastIndexOf(ch);
                if (ind > lastIndex)
                {
                    lastIndex = ind;
                }
            }
            return lastIndex;
        }

        public static string GetRightNumber(string exp, int index)
        {
            var dd = exp.Substring(index + 1);
            var ind = GetFirstASInd(dd);
            if (ind == dd.Length)
            {
                return dd;
            }
            else
            {
                return dd.Remove(ind);
            }
        }
        public static int GetFirstASInd(string exp)
        {
            var firstIndex = exp.Length;
            foreach (var ch in ActionSymbol)
            {
                var ind = exp.IndexOf(ch);
                if (ind < firstIndex && ind > 0)
                {
                    firstIndex = ind;
                }
            }
            return firstIndex;

        }

        public static string GetChangedExp(string exp, int startindex, char act)
        {
            var firstNumber = GetLeftNumber(exp, startindex);
            var secondNumber = GetRightNumber(exp, startindex);
            var calcResult = GetCalcResult(firstNumber, secondNumber, act);
            return exp.Replace(firstNumber + act + secondNumber, calcResult.ToString());


        }
        public static int GetCalcResult(string firstNumber, string secondNumber, char act)
        {
            var first = Int32.Parse(firstNumber);
            var second = Int32.Parse(secondNumber);
            switch (act)
            {
                case '+':
                    return first + second;
                case '-':
                    return first - second;
                case '/':
                    return first / second;
                case '*':
                    return first * second;
                default:
                    return 0;

            }


        }
    }
}
