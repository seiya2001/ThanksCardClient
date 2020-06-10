using MahApps.Metro.Controls;
using System.Windows;

namespace ThanksCardClient.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            this.WindowState = WindowState.Maximized; //画面最大化
            
        }
    }
}
