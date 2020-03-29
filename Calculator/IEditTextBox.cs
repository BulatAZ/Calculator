
using System.Windows.Controls;

namespace Calculator
{
    public interface IEditTextBox
    {
        void AddSymbolToText (TextBox txtBox, string attribute);
        void DeleteLastSymbol (TextBox txtBox);
    }
}
