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

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //string str = "0:";
            int[] arr = new[] { 1, 2, 3, 4, 5, 6 };
            string str2 = "";
            foreach (var num in arr)
            {
                for (int i = 10; i <= 15; i++)
                {
                    if(i == 12)
                        continue;
                    str2 += $"'{i}'";
                }

                str2 += "\r\n";
            }


            MessageBox.Show(str2);
        }
    }
}
