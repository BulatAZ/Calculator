namespace DesktopApp
{
    public class Expression
    {
        public string Text { get; set; }    

        public bool IsEmpty => string.IsNullOrWhiteSpace(Text);

        public int LastSymbolIndex => Text.Length - 1;

        public char? LastSymbol
        {
            get
            {
                if (!IsEmpty)
                {
                    return Text[LastSymbolIndex];
                }
                else
                {
                    return null;
                }
            }
        }

        public Expression(string text)
        {
            Text = text;
        }

    }
}
