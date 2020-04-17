
using DesktopApp.APIConnectors;
using DesktopApp.Handlers;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICalculate<float> Calc = new Calculator();
        private readonly IEditTextBox TextBoxEditor = new ControlsTextEditor();
        private readonly KeyPressHandler KeyPress = new KeyPressHandler();
        private readonly MouseClickHandler MouseClick = new MouseClickHandler();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MouseClick.TryParseToCalculatorButtonValue(sender, out string buttonValue))
            {
                AnswerToButtonEvent(buttonValue);
            }           
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (KeyPress.TryParseToCalculatorButtonValue(e, out string buttonValue))
            {
                AnswerToButtonEvent(buttonValue);
            }
        }

        private void AnswerToButtonEvent(string buttonValue)
        {
            if (string.IsNullOrWhiteSpace(buttonValue))
            {
                return;
            }
            switch (buttonValue)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                case "+":
                case "-":
                case "*":
                case "/":
                    TextBoxEditor.AddSymbolToText(txtConsole, buttonValue);
                    break;
                case "Del":
                    TextBoxEditor.DeleteLastSymbol(txtConsole);
                    break;
                case "=":
                    var result = Calc.GetResult(txtConsole.Text);
                    txtConsole.Text = result.ToString();
                    break;
                case "AC":
                    txtConsole.Text = string.Empty;
                    break;             
                default:
                    break;

            }
        }
    }
}
