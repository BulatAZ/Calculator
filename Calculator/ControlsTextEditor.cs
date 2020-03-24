

using System.Windows.Controls;

namespace Calculator
{
    public static class ControlsTextEditor
    {
        public static void AddSymbolToText(TextBox textbox, char symbol)
        {
            if(textbox != null)
            {
                textbox.Text = ExpressionEditor.AddSymbol(textbox.Text, symbol);
            }                      
        }
        public static void DeleteLastSymbol(TextBox textbox)
        {
            if (textbox != null)
            {
                var exp = new Expression(textbox.Text);
                ExpressionEditor.DeleteLastSymbol(exp);
                textbox.Text = exp.Text;
            }
        }
    }
}
