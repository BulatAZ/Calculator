
using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICalculate Calc = new CalculateExpression();
        private readonly IEditTextBox TextBoxEditor = new ControlsTextEditor();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_AC_Click(object sender, RoutedEventArgs e)
        {
            txtConsole.Text = string.Empty;
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            TextBoxEditor.DeleteLastSymbol(txtConsole);          
        }

        private void btn_result_Click(object sender, RoutedEventArgs e)
        {
            var result = Calc.GetResult(txtConsole.Text);
            txtConsole.Text = result.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var btn = new Button();
            try
            {
                btn = (Button)sender;
            }
            catch (Exception ex)
            {
                //TO DO
                // write log
                MessageBox.Show("Error" + ex.Message);
            }
            TextBoxEditor.AddSymbolToText(txtConsole, btn.Content.ToString());
        }
        
    }
}
