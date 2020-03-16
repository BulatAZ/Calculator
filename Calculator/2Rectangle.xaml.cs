using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for _2Rectangle.xaml
    /// </summary>
    public partial class _2Rectangle : Window
    {
        public _2Rectangle()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Rectangle).Fill = Brushes.Transparent;
        }

        private void Rectangle_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Rectangle).Fill = Brushes.Red;
        }
    }
}
