

using System;
using System.Windows;
using System.Windows.Controls;

namespace DesktopApp.Handlers
{
    public class MouseClickHandler
    {
        public bool TryParseToCalculatorButtonValue(object control, out string buttonValue)
        {
            if (control == null)
            {
                buttonValue = null;
                return false;
            }
            var btn = new Button();
            try
            {
                btn = (Button)control;
            }
            catch (Exception ex)
            {
                //TO DO: write log
                MessageBox.Show("Error" + ex.Message);
                buttonValue = null;
                return false;
            }
            switch (btn.Content.ToString())
            {
                case "1":
                    buttonValue = "1";
                    return true;
                case "2":
                    buttonValue = "2";
                    return true;
                case "3":
                    buttonValue = "3";
                    return true;
                case "4":
                    buttonValue = "4";
                    return true;
                case "5":
                    buttonValue = "5";
                    return true;
                case "6":
                    buttonValue = "6";
                    return true;
                case "7":
                    buttonValue = "7";
                    return true;
                case "8":
                    buttonValue = "8";
                    return true;
                case "9":
                    buttonValue = "9";
                    return true;
                case "0":
                    buttonValue = "0";
                    return true;
                case "+":
                    buttonValue = "+";
                    return true;
                case "-":
                    buttonValue = "-";
                    return true;
                case "Del":
                    buttonValue = "del";
                    return true;
                case "=":
                    buttonValue = "=";
                    return true;
                case "*":
                    buttonValue = "*";
                    return true;
                case "/":
                    buttonValue = "/";
                    return true;
                case "AC":
                    buttonValue = "AC";
                    return true;
                default:
                    buttonValue = null;
                    return false;
            }
        }
    }
}
