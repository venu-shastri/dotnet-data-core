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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    string keyText = this.keyText.Text;
        //   Task<string> searchTask=  Task.Factory.StartNew<string>(() => {

        //        string result = Search(keyText);
        //         return result;
                
        //    });
        //    searchTask.ContinueWith(pt =>
        //    {

        //        this.resultLable.Content += $" {pt.Result}";
                


        //    }, TaskScheduler.FromCurrentSynchronizationContext());

        //}


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string keyText = this.keyText.Text;
            string result = await Task.Factory.StartNew<string>(()=> {

                return Search(keyText);
            
            });
            this.resultLable.Content = result;

        }
        private string Search(string key)
        {
            System.Threading.Thread.Sleep(10000);
            return key.ToUpper();
        }
    }
}
