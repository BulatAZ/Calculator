using System.Windows.Controls;

namespace Calculator
{
    public class ControlsTextEditor : IEditTextBox
    {     
        public void AddSymbolToText(TextBox textbox, string symbol)
        {
            if(textbox != null)
            {
                textbox.Text = ExpressionEditor.AddSymbol(textbox.Text, symbol);
            }                      
        }
        public void DeleteLastSymbol(TextBox textbox)
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
