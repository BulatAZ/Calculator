
using System.Collections.Generic;
using System.Windows;


namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> NumbersChar = new List<string>
        {
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
        };
        private List<string> ActionSymbols = new List<string>
        {
            "-", "+", "*", "/"
        };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_1_Click(object sender, RoutedEventArgs e)
        {
            AddSymbolOnConsole("1");
        }

        private void btn_2_Click(object sender, RoutedEventArgs e)
        {
            AddSymbolOnConsole("2");
        }

        private void btn_3_Click(object sender, RoutedEventArgs e)
        {
            AddSymbolOnConsole("3");
        }

        private void btn_4_Click(object sender, RoutedEventArgs e)
        {
            AddSymbolOnConsole("4");
        }

        private void btn_5_Click(object sender, RoutedEventArgs e)
        {
            AddSymbolOnConsole("5");
        }

        private void btn_6_Click(object sender, RoutedEventArgs e)
        {
            AddSymbolOnConsole("6");
        }

        private void btn_7_Click(object sender, RoutedEventArgs e)
        {
            AddSymbolOnConsole("7");
        }

        private void btn_8_Click(object sender, RoutedEventArgs e)
        {
            AddSymbolOnConsole("8");
        }

        private void btn_9_Click(object sender, RoutedEventArgs e)
        {
            AddSymbolOnConsole("9");
        }

        private void btn_0_Click(object sender, RoutedEventArgs e)
        {
            AddSymbolOnConsole("0");
        }

        private void btn_plus_Click(object sender, RoutedEventArgs e)
        {
            AddSymbolOnConsole("+");
        }

        private void btn_minus_Click(object sender, RoutedEventArgs e)
        {
            AddSymbolOnConsole("-");
        }

        private void btn_multiplication_Click(object sender, RoutedEventArgs e)
        {
            AddSymbolOnConsole("*");
        }

        private void btn_division_Click(object sender, RoutedEventArgs e)
        {
            AddSymbolOnConsole("/");
        }

        private void btn_AC_Click(object sender, RoutedEventArgs e)
        {
            txtConsole.Text = string.Empty;
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            txtConsole.Text = StringEditor.GetTextWithOutLastSymbol(txtConsole.Text);
        }

        private void btn_result_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddSymbolOnConsole(string symbol)
        {

            txtConsole.Text = StringEditor.AddSymbol(txtConsole.Text, symbol);

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
