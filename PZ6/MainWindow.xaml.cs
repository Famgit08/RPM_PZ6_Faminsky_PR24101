using System.Windows;
using PZ6.Pages;

namespace PZ6
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Autho());
        }
    }
}