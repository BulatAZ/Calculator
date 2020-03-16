using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for GameAskMe.xaml
    /// </summary>
    public partial class GameAskMe : Window
    {
        public GameAskMe()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            Thread.Sleep(1000);
            txtAnswer.Text = "ответ";
            this.Cursor = null;
        }
    }
}
