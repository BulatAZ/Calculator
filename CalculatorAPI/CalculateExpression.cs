using System.Collections.Generic;

namespace CalculatorAPI
{
    public class CalculateExpression
    {       
        private readonly List<char> ActionSymbol = new List<char>()
        {
            '/','*','+','-'
        };
        public float GetResult(string expression)
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
            
            if(float.TryParse(expression, out float result))
            {
                return result;
            }
            else
            {
                //TO DO: write to log
                return -1;
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
            if (string.IsNullOrWhiteSpace(exp))
            {
                return -1;
            }
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

            return exp.Replace(firstNumber + act + secondNumber, NumberToString(calcResult));


        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
        public float GetCalcResult(string firstNumber, string secondNumber, char act)
        {

            if(float.TryParse(firstNumber, out float first) && float.TryParse(secondNumber, out float second))
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
                return -1;
            }
        }

        private string NumberToString(float number)
        {
            if(number == 0)
            {
                return "0";
            }
            else
            {
                return number.ToString(".##");
            }
        }

        public bool IsFinish(string exp)
        {
            var lastActIndex = GetLastActSymIndex(exp);
            var firstActIndex = GetFirstActSymIndex(exp);
            if(lastActIndex == firstActIndex && firstActIndex == 0)
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
