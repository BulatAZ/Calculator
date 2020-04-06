
namespace Calculator
{
    public interface ICalculate <T>
    {
        T GetResult(string expression);
    }
}
