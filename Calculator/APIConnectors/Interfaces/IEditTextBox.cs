
using System.Windows.Controls;

namespace DesktopApp
{
    public interface IEditTextBox
    {
        void AddSymbolToText (TextBox txtBox, string attribute);
        void DeleteLastSymbol (TextBox txtBox);
    }
}
