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
using System.Windows.Navigation;
using WpfApp.Model;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public int UId;
        public string Login;
        public Window1(int _UId)
        {
         
            InitializeComponent();
            UId = _UId;

            using (Rend context = new Rend())
            {
               
                var n = context.User.Where(p => p.Id == UId);
                foreach(var i in n)
                {
                    TB1.Text =i.Login;
                    Login = i.Login;
                  
                    if (i.IsAdmin == true)
                    {
                        listViewItem5.Visibility = Visibility.Visible;
                    }
                }


            }
           
            
        }

     
      

        
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            Main.Content = new Home();
        }

        private void ListViewItem1_Selected(object sender, RoutedEventArgs e)
        {
            Main.Content = new Rendd(UId, Login);
        }

        private void ListViewItem2_Selected(object sender, RoutedEventArgs e)
        {
            Main.Content = new Promotions();
        }

        private void ListViewItem3_Selected(object sender, RoutedEventArgs e)
        {
            Main.Content = new Statistics(UId);
        }

        private void ListViewItem4_Selected(object sender, RoutedEventArgs e)
        {
            Main.Content = new About();
        }

     

        private void ListViewItem5_Selected(object sender, RoutedEventArgs e)
        {
            Main.Content = new Settings();
        }

        private void Main_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            WpfApp.MainWindow w = new MainWindow();
            w.Show();
        }
    }
}
