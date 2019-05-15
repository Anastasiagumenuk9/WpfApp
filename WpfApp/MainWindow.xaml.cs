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
using System.Windows.Media.Animation;
using System.Data.Entity;
using WpfApp.Model;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using WpfApp.Singleton;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
    
            InitializeComponent();
            

    }

        public int UserId;
        


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool mes = false;
            bool win = false;
            using (Model.Rend context = new Model.Rend())
            {
                var users = context.User.ToList();

                foreach (Model.User p in users)

                {
                    if (TB1.Text.Trim() == p.Login && TB2.Text.Trim() == p.Password)
                    {
                        UserId = p.Id;             
                        win = true;
                        mes = false;
                        mw.Hide();
                        WpfApp.Window1 w = new Window1(UserId);
                        w.Show();
                        break;

                        

                    }
                    else
                    {

                        mes = true;
                        win = false;

                    }
                }


                ///MessageBoxResult result1 = MessageBox.Show(UserId.ToString());


                if (mes == true && win == false)
                {
                    MessageBoxResult result = MessageBox.Show("Enter correct login or password ! ");
                }


            }
        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WpfApp.Window1 w = new Window1(UserId);
            w.Show();
            this.Hide();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            this.Close();

        }

        private void B2_Click(object sender, RoutedEventArgs e)
        {
            using (Model.Rend context = new Model.Rend())
            {
                if (TBB1.Text.Trim() != "" && TBB2.Text.Trim() != "" && TBB3.Text.Trim() != "" && TBB4.Text.Trim() != "" && TBB3.Text.Contains(("@")))
                {

                    Model.User user = new Model.User();
                    user.Login = TBB1.Text;
                    user.Password = TBB2.Text;
                    user.IsAdmin = CB.IsChecked;
                    user.Email = TBB3.Text;
                    user.Phone = TBB4.Text;

                    SignIn userr = new SignIn();
                    userr.Sign(TB1.Text + " " + TB2.Text);


                    context.User.Add(user);
                    context.SaveChanges();

                    GR1.Visibility = Visibility.Visible;
                    GR2.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Enter correct information ! ");
                }

            }
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            GR1.Visibility = Visibility.Hidden;
            GR2.Visibility = Visibility.Visible;
        }
    }
}
