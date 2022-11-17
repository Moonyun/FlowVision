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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.window
{
    /// <summary>
    /// Maintain.xaml 的交互逻辑
    /// </summary>
    public partial class Maintain : UserControl
    {
        public Maintain()
        {
            InitializeComponent();
        }

        //液路初始化
        private void Fluidinit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("功能待接入!");
        }

        //整机排空
        private void EmptyComplete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("功能待接入!");
        }

        //整机冲灌
        private void FlushComplete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("功能待接入!");
        }

        //过滤器冲灌
        private void FilterCharging_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("功能待接入!");
        }

        //柱塞泵冲灌
        private void RamPumpCharging_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("功能待接入!");
        }

        //整流腔冲灌
        private void RectifierRoomCharging_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("功能待接入!");
        }

        //通道排堵
        private void ChannelBlock_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("功能待接入!");
        }

        //深度清洁
        private void ChannelClean_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("功能待接入!");
        }

        //鞘流更换
        private void ChangeSheethfluid_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("功能待接入!");
        }

        //清洁剂更换
        private void ChangeCleanfluid_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("功能待接入!");
        }
    }
}
