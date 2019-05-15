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

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Page
    {
        public EditUser()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Model.Rend context = new Model.Rend())
                {
                    var user = context.User.ToList()

                    .Where(c => c.Id == Convert.ToInt32(TB1.Text))
                    .FirstOrDefault();

                    if (TB2.Text.Trim() != "")
                    {
                        user.Login = TB2.Text;
                    }
                    else if (TB3.Text.Trim() != "")
                    {
                        user.Password = (TB3.Text);
                    }
                    else if (TB4.Text.Trim() != "")
                    {
                        user.Email = (TB4.Text);
                    }
                    else if (TB5.Text.Trim() != "")
                    {
                        user.Phone = (TB5.Text);
                    }

                    user.IsAdmin = CB.IsChecked;



                    context.SaveChanges();

                }
            }
            catch
            {
                MessageBox.Show("Input Correct Data!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
