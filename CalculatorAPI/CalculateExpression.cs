using System.Collections.Generic;

namespace CalculatorAPI
{
    public class CalculateExpression
    {       
        private readonly List<char> ActionSymbols = new List<char>()
        {
            '/','*','+','-'
        };
        public float GetResult(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                return 0;
            }

            expression = GetCalculatedExpression(expression);          

            if (float.TryParse(expression, out float result))
            {
                return result;
            }
            else
            {
                //TO DO: write to log
                return -1;
            }            
        }
        public string GetCalculatedExpression(string exp)
        {
            foreach (var action in ActionSymbols)
            {
                var actionInd = exp.IndexOf(action);
                while (actionInd > -1)
                {
                    if (actionInd == 0)
                    {
                        var subExp = exp.Substring(1);
                        actionInd = subExp.IndexOf(action) + 1;
                    }
                    exp = GetExpWithCalculatingOneOperation(exp, actionInd);
                    if (IsCalculatingFinish(exp))
                    {
                        break;
                    }
                    actionInd = exp.IndexOf(action);
                }
            }
            return exp;
        }
        public string GetExpWithCalculatingOneOperation(string expression, int actionInd)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                return expression;
            }
            var leftNumber = GetLeftNumber(expression, actionInd);
            var rightNumber = GetRightNumber(expression, actionInd);
            if (string.IsNullOrWhiteSpace(leftNumber) || string.IsNullOrWhiteSpace(rightNumber))
            {
                return expression;
            }
            var actionSymbol = expression[actionInd];
            var calcResult = GetCalcResult(leftNumber, rightNumber, actionSymbol);

            return expression.Replace(leftNumber + actionSymbol + rightNumber, NumberToString(calcResult));
        }
        public string GetLeftNumber(string exp, int actionInd)
        {
            if(string.IsNullOrWhiteSpace(exp))
            {
                return null;
            }
            var leftPartOfExpression = exp.Remove(actionInd);
            var startIndexOfLastNumber = GetStartIndexOfLastNumber(leftPartOfExpression);
            if (startIndexOfLastNumber == 0)
            {
                return leftPartOfExpression;
            }
            else
            {
                return leftPartOfExpression.Substring(startIndexOfLastNumber + 1);
            }               
        }
        public int GetStartIndexOfLastNumber(string exp)
        {
            if(exp == null)
            {
                return -1;
            }
            int actionSymbolIndexInFrontOfLastNumber = -1;
            foreach (var symbol in ActionSymbols)
            {
                var index = exp.LastIndexOf(symbol);
                if (index > actionSymbolIndexInFrontOfLastNumber)
                {
                    actionSymbolIndexInFrontOfLastNumber = index;
                }
            }
            return actionSymbolIndexInFrontOfLastNumber;
        }
        public string GetRightNumber(string exp, int actionInd)
        {
            if(exp == null)
            {
                return null;
            }
            var rightPartOfExpression = exp.Substring(actionInd + 1);
            var endIndexOfFirstNumber = GetEndIndexOfFirstNumber(rightPartOfExpression);
            if (endIndexOfFirstNumber == rightPartOfExpression.Length || endIndexOfFirstNumber == -1)
            {
                return rightPartOfExpression;
            }
            else
            {
                return rightPartOfExpression.Remove(endIndexOfFirstNumber);
            }
        }
        public int GetEndIndexOfFirstNumber(string exp)
        {
            if (string.IsNullOrWhiteSpace(exp))
            {
                return -1;
            }
            var EndIndexOfFirstNumber = exp.Length;
            foreach (var ch in ActionSymbols)
            {
                var index = exp.IndexOf(ch);
                if (index < EndIndexOfFirstNumber && index != -1)
                {
                    EndIndexOfFirstNumber = index;
                }
            }
            return EndIndexOfFirstNumber;

        }       

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
        public float GetCalcResult(string leftNumber, string rightNumber, char actionSymbol)
        {

            if(float.TryParse(leftNumber, out float first) && float.TryParse(rightNumber, out float second))
            {
                switch (actionSymbol)
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
        public bool IsCalculatingFinish(string exp)
        {
            var lastActIndex = GetStartIndexOfLastNumber(exp);
            var firstActIndex = GetEndIndexOfFirstNumber(exp);
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
