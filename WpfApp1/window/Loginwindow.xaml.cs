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
using WpfApp1.windowmodel;

namespace WpfApp1.window
{
    /// <summary>
    /// Logwindow.xaml 的交互逻辑
    /// </summary>
    public partial class Loginwindow : Window
    {
        public Loginwindow()
        {
            InitializeComponent();
            this.DataContext = new LoginWindowModel();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }



    }
}
