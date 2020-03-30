using System;
using System.Collections.Generic;

namespace Calculator
{
    public class CalculateExpression : ICalculate
    {       
        private readonly List<char> ActionSymbol = new List<char>()
        {
            '/','*','+','-'
        };
        public int GetResult(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                return 0;
            }
            foreach (var act in ActionSymbol)
            {
                var actId = expression.IndexOf(act);
                while (actId > -1)
                {
                    if(actId == 0)
                    {
                        var dd = expression.Substring(1);
                        actId = dd.IndexOf(act)+1;
                    }
                    expression = GetChangedExp(expression, actId, act);
                    if (IsFinish(expression))
                    {
                        break;
                    }
                    actId = expression.IndexOf(act);
                    
                }
            }
            
            if(Int32.TryParse(expression, out int result))
            {
                return result;
            }
            else
            {
                //TO DO: write to log
                return 0;
            }            
        }
        
        public string GetLeftNumber(string exp, int index)
        {
            if(string.IsNullOrWhiteSpace(exp))
            {
                return null;
            }
            var ddd = exp.Remove(index);
            var lastAcrSymIndex = GetLastActSymIndex(ddd);
            if (lastAcrSymIndex == 0)
            {
                return ddd;
            }
            else
            {
                return ddd.Substring(GetLastActSymIndex(ddd) + 1);
            }
                
        }
        public int GetLastActSymIndex(string exp)
        {
            if(exp == null)
            {
                return -1;
            }
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
        public string GetRightNumber(string exp, int index)
        {
            if(exp == null)
            {
                return null;
            }
            var dd = exp.Substring(index + 1);
            var ind = GetFirstActSymIndex(dd);
            if (ind == dd.Length || ind == -1)
            {
                return dd;
            }
            else
            {
                return dd.Remove(ind);
            }
        }
        public int GetFirstActSymIndex(string exp)
        {
            var firstIndex = exp.Length;
            foreach (var ch in ActionSymbol)
            {
                var ind = exp.IndexOf(ch);
                if (ind < firstIndex && ind != -1)
                {
                    firstIndex = ind;
                }
            }
            return firstIndex;

        }
        public string GetChangedExp(string exp, int startindex, char act)
        {
            if (string.IsNullOrWhiteSpace(exp))
            {
                return exp;
            }
            var firstNumber = GetLeftNumber(exp, startindex);
            var secondNumber = GetRightNumber(exp, startindex);
            if(string.IsNullOrWhiteSpace(firstNumber) || string.IsNullOrWhiteSpace(secondNumber))
            {
                return exp;
            }
            var calcResult = GetCalcResult(firstNumber, secondNumber, act);
            return exp.Replace(firstNumber + act + secondNumber, calcResult.ToString());


        }
        public int GetCalcResult(string firstNumber, string secondNumber, char act)
        {
            if(Int32.TryParse(firstNumber, out int first) && Int32.TryParse(secondNumber, out int second))
            {
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
            else
            {
                //TODO write to log
                return 0;
            }
        }

        public bool IsFinish(string exp)
        {
            var lastActIndex = GetLastActSymIndex(exp);
            var firstActIndex = GetFirstActSymIndex(exp);
            if(lastActIndex == firstActIndex)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
