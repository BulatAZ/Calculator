
using CalculatorAPI;

namespace DesktopApp.APIConnectors
{
    public class Calculator : ICalculate<float>
    {
        public float GetResult(string expression)
        {
            var calc = new CalculateExpression();
            return calc.GetResult(expression);
        }
    }
}
