
namespace Calculator
{
    public class InputExpression
    {
        public string Text { get; set; }

        public bool IsEmpty => string.IsNullOrWhiteSpace(Text);

        public int LastSymbolIndex => Text.Length - 1;

        public string LastSymbol
        {
            get
            {
                if (!IsEmpty)
                {
                    return Text.Substring(LastSymbolIndex, 1); 
                }
                else
                {
                    return null;
                }
                  
            }
        }
       

    }
}
