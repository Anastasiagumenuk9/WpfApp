using System;
using System.Collections.Generic;
using System.IO;
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
using WpfApp.Model;
using WpfApp.Strategy;
using System.Net;
using System.Net.Mail;
using System.ComponentModel;
using Nexmo.Api;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для Rend.xaml
    /// </summary>
    public partial class Rendd : Page
    {
        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;

        int uid;
        string n;
        public Rendd(int _uid, string _n)
        {
            uid = _uid;
            n = _n;
            InitializeComponent();

            try
            {
                if (n.Trim() != "")
                {
                    B.Visibility = Visibility.Visible;
                    B.IsEnabled = true;
                }
            }
            catch
            {
                B.Visibility = Visibility.Hidden;
                B.IsEnabled = false;

            }
            h.Items.Add("00");
            h.Items.Add("01");
            h.Items.Add("03");
            h.Items.Add("04");
            h.Items.Add("05");
            h.Items.Add("06");
            h.Items.Add("07");
            h.Items.Add("08");
            h.Items.Add("09");
            h.Items.Add("10");
            h.Items.Add("11");
            h.Items.Add("12");
            h.Items.Add("13");
            h.Items.Add("14");
            h.Items.Add("15");
            h.Items.Add("16");
            h.Items.Add("17");
            h.Items.Add("18");
            h.Items.Add("19");
            h.Items.Add("20");
            h.Items.Add("21");
            h.Items.Add("22");
            h.Items.Add("23");
            



            m.Items.Add("00");
            m.Items.Add("01");
            m.Items.Add("03");
            m.Items.Add("04");
            m.Items.Add("05");
            m.Items.Add("06");
            m.Items.Add("07");
            m.Items.Add("08");
            m.Items.Add("09");
            m.Items.Add("10");
            m.Items.Add("11");
            m.Items.Add("12");
            m.Items.Add("13");
            m.Items.Add("14");
            m.Items.Add("15");
            m.Items.Add("16");
            m.Items.Add("17");
            m.Items.Add("18");
            m.Items.Add("19");
            m.Items.Add("20");
            m.Items.Add("21");
            m.Items.Add("22");
            m.Items.Add("23");
            m.Items.Add("24");
            m.Items.Add("25");
            m.Items.Add("26");
            m.Items.Add("27");
            m.Items.Add("28");
            m.Items.Add("29");
            m.Items.Add("30");
            m.Items.Add("31");
            m.Items.Add("32");
            m.Items.Add("33");
            m.Items.Add("34");
            m.Items.Add("35");
            m.Items.Add("36");
            m.Items.Add("37");
            m.Items.Add("38");
            m.Items.Add("39");
            m.Items.Add("40");
            m.Items.Add("41");
            m.Items.Add("42");
            m.Items.Add("43");
            m.Items.Add("44");
            m.Items.Add("45");
            m.Items.Add("46");
            m.Items.Add("47");
            m.Items.Add("48");
            m.Items.Add("49");
            m.Items.Add("50");
            m.Items.Add("51");
            m.Items.Add("52");
            m.Items.Add("53");
            m.Items.Add("54");
            m.Items.Add("55");
            m.Items.Add("56");
            m.Items.Add("57");
            m.Items.Add("58");
            m.Items.Add("59");
          





            var today = DateTime.Now;
          
            DP1.DisplayDateStart = DateTime.Now;
         
            DP2.DisplayDateStart = today.AddDays(1);


            using (Model.Rend context = new Model.Rend())
            {
                ComBox.Items.Clear();
                var countries = context.Country.ToList();

                foreach (Country p in countries)

                {
                    ComBox.Items.Add(p.Name);
                }

                var cars = context.Car.ToList();

                foreach (Car c in cars)

                {
                    CB3.Items.Add(c.Name);
                }

            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
              ComBox1.Items.Clear();
              ComBox2.Items.Clear();
            TB.Text = "";
            TB1.Text = "";
              DP1.Text = "";
              DP2.Text = "";


            using (Model.Rend context = new Model.Rend())
             {

                  var cities = context.City.Join(context.Country, 
                  p => p.CountryId, 
                  c => c.Id, 
                  (p, c) => new 
                  {
                     city = p.Name,
                     country = c.Name,
                  });



                 foreach (var k in cities)
                 {
                     if(ComBox.SelectedValue.ToString() == k.country)
                     {
                         ComBox1.Items.Add(k.city);
                         ComBox1.SelectedItem = true;
                     }


                 }



             }


        }

        private void ComBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComBox2.Items.Clear();
            

            using (Model.Rend context = new Model.Rend())
            {

                var locations = context.City.Join(context.Location,
                p => p.Id,
                c => c.CityId,
                (p, c) => new
                {
                    city = p.Name,
                    location = c.Name,
                });



                foreach (var k in locations)
                {
                    try
                    {
                        if (ComBox1.SelectedValue.ToString() == k.city)
                        {
                            ComBox2.Items.Add(k.location);
                            ComBox2.SelectedItem = true;
                        }
                    }
                    catch
                    {
                        ComBox1.Items.Clear();
                        ComBox2.Items.Clear();
                    }
                   
                   

                }



            }
        }

        private void ComBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
                
            

        }

        private void CB3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int CarId = 0;
            CB4.Items.Clear();
            Label.Visibility = Visibility.Hidden;
            CB4.Visibility = Visibility.Hidden;
            TB1.Visibility = Visibility.Hidden;
            TB.Text = "";
            TB1.Text = "";
          

            using (Model.Rend context = new Model.Rend())
            {
                var names = context.Car.ToList()
                        .OrderBy(c => c.Photo)
                        .Select(c => c.Photo);

                var cars = context.Car.ToList();

                var car = context.Car.ToList().Where(p => p.Name == CB3.SelectedValue.ToString());

                var car1 = context.Car.Join(context.ClassCar, 
                p => p.ClassCarId, 
                c => c.ClassCarId, 
                (p, c) => new 
                {
                    Name = p.Name,
                    Cond = p.Conditioner,
                    Pet = p.Petrol,
                    Seat = p.CountOfSeets,
                    Class = c.Name,
                    Trans = p.Transmission.Name
                }).ToList().Where(p => p.Name == CB3.SelectedValue.ToString());

                TT.DataContext = car1;



                foreach (var c in cars)
                {
                    if(CB3.SelectedValue.ToString() == c.Name)
                    {
                        CarId = c.Id;
                        MemoryStream strmImg = new MemoryStream(c.Photo);
                        BitmapImage myBitmapImage = new BitmapImage();
                        myBitmapImage.BeginInit();
                        myBitmapImage.StreamSource = strmImg;
                        myBitmapImage.DecodePixelWidth = 200;
                        myBitmapImage.EndInit();
                        Img.Source = myBitmapImage;

                    }
                }

                var promotions = context.PromotionCar.Join(context.Promotion, 
                p => p.PromotionId, 
                c => c.PromotionId, 
                (p, c) => new 
                 {
                     Name = c.Name,
                     CI = p.CarId
                 });

               
                foreach(var p in promotions)
                {
                    
                    if(p.CI == CarId)
                    {
                        Label.Visibility = Visibility.Visible;
                        CB4.Visibility = Visibility.Visible;
                        TB1.Visibility = Visibility.Visible;
                        CB4.Items.Add(p.Name);
                       
                    }
                    
                        
                    
                }

               
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int CountOfDays;
            DateTime Start;
            DateTime End;
            double Price = 0;

            Start = Convert.ToDateTime(DP1.SelectedDate);
            End = Convert.ToDateTime(DP2.SelectedDate);
            CountOfDays = End.Date.Subtract(Start.Date).Days;


            if (ComBox.SelectedIndex != -1 && ComBox1.SelectedIndex != -1 && ComBox2.SelectedIndex != -1 && h.SelectedIndex != -1 && m.SelectedIndex != -1 && DP2.SelectedDate > DP1.SelectedDate)
            {
                IPrice component = new ConcretePrice(CB3.SelectedValue.ToString(), CountOfDays);
                BaseDecorator DecoratorTwo = new Driver(ChB.IsChecked, CountOfDays);

                DecoratorTwo.IPrice = component;
                TB.Text = Convert.ToString(DecoratorTwo.GetPrice()) + " $";
                Price = DecoratorTwo.GetPrice();
            }
            else if (ComBox.SelectedIndex == -1 && ComBox1.SelectedIndex == -1 && ComBox2.SelectedIndex == -1 || ComBox.SelectedIndex == -1 && ComBox1.SelectedIndex == -1 || ComBox1.SelectedIndex == -1 && ComBox2.SelectedIndex == -1 || ComBox2.SelectedIndex == -1)
            {
                MessageBoxResult result = MessageBox.Show("Choose Correct Location !");
            }

            else if (h.SelectedIndex == -1 && m.SelectedIndex == -1 || DP1.SelectedDate > DP2.SelectedDate)
            {
                MessageBoxResult result = MessageBox.Show("Choose Correct Time !");
            }



            using (Rend context = new Rend())
            {
                var promotions = context.Promotion.ToList();
                double per = 0;
                foreach (var p in promotions)
                {
                    try
                    {
                        if (CB4.SelectedValue.ToString() == p.Name)
                        {
                            per = p.Percent;
                            var promo = new WithPromotion(Price, per);
                            var cont = new Context(promo);
                            TB1.Text = cont.Price().ToString() + "$";
                            PricePromo = cont.Price();


                        }



                    }
                    catch
                    {
                        per = p.Percent;
                        var promo = new WithoutPromotion(Price);
                        var cont = new Context(promo);
                        TB1.Text = cont.Price().ToString() + "$";
                        PriceP = cont.Price();
                    }

                }

                if (TB.Text == "")
                {
                    TB1.Text = "";
                }


            }






        }
        public string nameCar;
        public string location;
        public double PricePromo;
        public double PriceP;
        public DateTime d;
        public DateTime dd;
        public string hour;
        public string min;


     

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            double price;
            if(ComBox.SelectedIndex != -1 && ComBox1.SelectedIndex != -1 && ComBox2.SelectedIndex != -1 && CB3.SelectedIndex != -1 && h.SelectedIndex!= -1 && m.SelectedIndex!= -1 && DP1.Text.Trim()!="" && DP2.Text.Trim() != "" && TB.Text.Trim() != "")
            {
                nameCar = CB3.SelectedValue.ToString();
                location = ComBox2.SelectedValue.ToString();
             
                if(CB4.SelectedIndex == -1)
                {
                    price = PriceP;
                }
                else
                {
                    price = PricePromo;
                }

                d = Convert.ToDateTime(DP1.Text);
                dd = Convert.ToDateTime(DP2.Text);
                hour = Convert.ToString(h.SelectedValue);
                min = Convert.ToString(m.SelectedValue);
                string mail = "";
                string phone = "";


                using (Rend context = new Rend())
                    {
                 
                    var user = context.User.ToList();
                    foreach(var u in user)
                    {
                        if(u.Id == uid)
                        {
                            mail = u.Email;
                            phone = u.Phone;
                        }
                    }
                        Lease lease = new Lease();
                        lease.UserId = uid;
                        lease.CarName = nameCar;
                        lease.DateStart = Convert.ToDateTime(d.ToString("d"));
                        lease.DateEnd = Convert.ToDateTime(dd.ToString("d"));
                        lease.Price = price;

                        context.Lease.Add(lease);
                        context.SaveChanges();
                  /*  
                    var clientt = new Client(creds: new Nexmo.Api.Request.Credentials
                    {
                        ApiKey = "99a97d92",
                        ApiSecret = "0nTT900jCcgI59lH"
                    });
                    var results = clientt.SMS.Send(request: new SMS.SMSRequest
                    {
                        from = "CarRend",
                        to = phone,
                        text = "Hello! You Rend Car '" + nameCar + "' . To Be Paid " + price + "$ . Thank You For Order!"
                    });
                    */
                    login = new NetworkCredential("CarrRend", "Rend1505");
                    client = new SmtpClient("smtp.gmail.com");
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = login;
                    msg = new MailMessage { From = new MailAddress("CarrRend" + "smtp.gmail.com".Replace("smtp.", "@"), "Rend", Encoding.UTF8) };
                    msg.To.Add(new MailAddress(mail));
                    if (!string.IsNullOrEmpty("")) ;
                    msg.To.Add(new MailAddress(mail));
                    msg.Subject = "Rend Of Car";
                    msg.Body = "Hello! You Rend Car '" + nameCar + "' . Please Take Your Car From " + location + " At " + hour + ":" + min + " " + d.ToString("d") + " . Turn Off The Car No Later Than 12:00 " + dd.ToString("d") + ". To Be Paid " + price + "$ . Thank You For Order!";
                    msg.BodyEncoding = Encoding.UTF8;
                    msg.IsBodyHtml = true;
                    msg.Priority = MailPriority.Normal;
                    msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                    string userstate = "Sending......";
                    client.SendAsync(msg, userstate);

                  
                }
               


               



            }
            else
            {
                MessageBox.Show("Choose all parameters!");
            }




        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show(string.Format("{0} send cancelled.", e.UserState), "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (e.Error!= null)
            {
                MessageBox.Show(string.Format("{0} {1}", e.UserState, e.Error), "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Your Order Has Been Successfully Accepted.", "Message", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
    }
}
