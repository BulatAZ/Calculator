

using System.Windows.Controls;
using System.Windows.Input;

namespace DesktopApp.Handlers
{
    public class KeyPressHandler
    {
        public bool TryParseToCalculatorButtonValue(KeyEventArgs keyEvent, out string buttonValue )
        {
            if(keyEvent == null)
            {
                buttonValue = null;
                return false; 
            }
            switch (keyEvent.Key.ToString())
            {
                case "NumPad1":
                    buttonValue = "1";
                    return true;
                case "NumPad2":
                    buttonValue = "2";
                    return true;
                case "NumPad3":
                    buttonValue = "3";
                    return true;
                case "NumPad4":
                    buttonValue = "4";
                    return true;
                case "NumPad5":
                    buttonValue = "5";
                    return true;
                case "NumPad6":
                    buttonValue = "6";
                    return true;
                case "NumPad7":
                    buttonValue = "7";
                    return true;
                case "NumPad8":
                    buttonValue = "8";
                    return true;
                case "NumPad9":
                    buttonValue = "9";
                    return true;
                case "NumPad0":
                    buttonValue = "0";
                    return true;
                case "Add":
                    buttonValue = "+";
                    return true;
                case "Subtract":
                    buttonValue = "-";
                    return true;
                case "Back":
                    buttonValue = "Del";
                    return true;
                case "Return": // Enter
                    buttonValue = "=";
                    return true;
                case "Multiply":
                    buttonValue = "*";
                    return true;
                case "Divide":
                    buttonValue = "/";
                    return true;
                default:                    
                    buttonValue = null;
                    return false;
            }
        } 
    }
}
