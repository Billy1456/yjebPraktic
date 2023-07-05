using Rega.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Rega
{
    /// <summary>
    /// Логика взаимодействия для profil.xaml
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
    public partial class profil : Window
    {
        readonly private List<Profil> profils;
        readonly private zapolnenie inf = new zapolnenie();
        Random random = new Random();

        public profil()
        {
            InitializeComponent();
            profils = AfiasalesEntities4.GetContent().Profil.ToList();
            var obj = profils.Where(p => p.Login == zapolnenie.For_full_name);
            foreach (var profil in obj)
            {
                TBfio.Text = profil.Surname;
                TBfio.Text += " ";
                TBfio.Text += profil.Name;
                TBfio.Text += " ";
                TBfio.Text += profil.Otjestvo;
                
            }

            string check_photo = "";
            foreach (var item in obj)
            {
                check_photo = item.image;
            }
            if (check_photo.Contains(".jpg") || check_photo.Contains(".png"))
                Profile_photo.Source = new BitmapImage(new Uri(check_photo));
            Stat.IsReadOnly = true;

            int r = random.Next(3);
            int exclude = r;
            Photo_of_the_city.Source = new BitmapImage(new Uri(inf.url_cities[r]));
            LCD.Content = inf.cities[r];
            TBCD.Text = inf.short_description_cities[r];
            Photo_of_the_hotels.Source = new BitmapImage(new Uri(inf.url_hotels[r]));
            LHD.Content = inf.hotels[r];
            TBHD.Text = inf.short_description_hotels[r];
            Photo_of_the_city_s_attraction.Source = new BitmapImage(new Uri(inf.url_attractions[r]));
            LCA.Content = inf.attractions[r];
            TBCA.Text = inf.description_attractions[r];
            Photo_of_the_local_festival.Source = new BitmapImage(new Uri(inf.url_festivals[r]));
            LFD.Content = inf.festivals[r];
            TBFD.Text = inf.description_festivals[r];
            r = random.Next(3 - exclude);
            Photo_of_the_city2.Source = new BitmapImage(new Uri(inf.url_cities[r]));
            LCD2.Content = inf.cities[r];
            TBCD2.Text = inf.short_description_cities[r];
            Photo_of_the_hotels2.Source = new BitmapImage(new Uri(inf.url_hotels[r]));
            LHD2.Content = inf.hotels[r];
            TBHD2.Text = inf.short_description_hotels[r];
            Photo_of_the_local_festival2.Source = new BitmapImage(new Uri(inf.url_festivals[r]));
            LFD2.Content = inf.festivals[r];
            TBFD2.Text = inf.description_festivals[r];
            int d = random.Next(2);
            Photo_of_the_discounts.Source = new BitmapImage(new Uri(inf.url_discounts[d]));
            TBDD.Text = inf.description_discounts[d];
            d = random.Next(1000);
            r = random.Next(1000);
            TBview.Text = d.ToString();
            TBview1.Text = r.ToString();
            d = random.Next(1000);
            r = random.Next(1000);
            TBview2.Text = d.ToString();
            TBview3.Text = r.ToString();
            d = random.Next(1000);
            r = random.Next(1000);
            TBview4.Text = d.ToString();
            TBview5.Text = r.ToString();
            d = random.Next(1000);
            r = random.Next(1000);
            TBview6.Text = d.ToString();
            TBview7.Text = r.ToString();
        }


        private void Setings(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Stat.Width = Double.NaN;
            Stat.IsReadOnly = true;
            Stat.Visibility = Visibility.Hidden;
            Stat.Visibility = Visibility.Visible;
        }

        private void izmstat_Click(object sender, RoutedEventArgs e)
        {
            Stat.Width = 200;
            Stat.IsReadOnly = false;
            Stat.Visibility = Visibility.Hidden;
            Stat.Visibility = Visibility.Visible;
        }

        private void More_detailed(object sender, RoutedEventArgs e)
        {
            switch(LVposts.SelectedIndex)
            {
                case 0:
                    griddetailed.Visibility = Visibility.Visible;
                    Lname.Content = LCD.Content;
                    TBdescription.Text = TBCD2.Text;
                    Photo.Source = Photo_of_the_city.Source;
                    TBviews.Text = random.Next(1000, 1300).ToString();
                    break;
                case 1:
                    Lname.Content = LFD.Content;
                    Photo.Source = Photo_of_the_local_festival.Source;
                    TBdescription.Text = TBFD.Text;
                    TBviews.Text = random.Next(1000, 1300).ToString();
                    griddetailed.Visibility = Visibility.Visible;
                    break;
                case 2:
                    griddetailed.Visibility = Visibility.Visible;
                    Lname.Content = LCA.Content;
                    Photo.Source = Photo_of_the_city_s_attraction.Source;
                    TBdescription.Text = TBCA.Text;
                    TBviews.Text = random.Next(1000, 1300).ToString();
                    break;
                case 3:
                    griddetailed.Visibility = Visibility.Visible;
                    Lname.Content = LFD2.Content;
                    Photo.Source = Photo_of_the_local_festival2.Source;
                    TBdescription.Text = TBFD2.Text;
                    TBviews.Text = random.Next(1000, 1300).ToString();
                    break;
                case 4:
                    griddetailed.Visibility = Visibility.Visible;
                    Lname.Content = LFD2.Content;
                    Photo.Source = Photo_of_the_local_festival2.Source;
                    TBdescription.Text = TBFD2.Text;
                    TBviews.Text = random.Next(1000, 1300).ToString();          
                    break;
                case 5:
                    griddetailed.Visibility = Visibility.Visible;
                    Lname.Content = LHD.Content;
                    if (LHD.Content.ToString() == "Охтинская гостиница")
                    {
                        Photo.Source = new BitmapImage(new Uri(inf.url_hotels[0]));
                        TBdescription.Text = inf.description_hotel;
                    }
                    else
                    {
                        Photo.Source = Photo_of_the_hotels.Source;
                        TBdescription.Text = TBHD.Text;
                    }
                    TBviews.Text = random.Next(1000, 1300).ToString();              
                    break;
                case 6:
                    griddetailed.Visibility = Visibility.Visible;
                    Lname.Content = LHD2.Content;
                    if (LHD2.Content.ToString() == "Охтинская гостиница")
                    {
                        Photo.Source = new BitmapImage(new Uri(inf.url_hotels[0]));
                        TBdescription.Text = inf.description_hotel;
                    }
                    else
                    {
                        Photo.Source = Photo_of_the_hotels2.Source;
                        TBdescription.Text = TBHD2.Text;
                    }
                    TBviews.Text = random.Next(1000, 1300).ToString();
                    griddetailed.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            griddetailed.Visibility = Visibility.Hidden;
        }

        private void js(object sender, RoutedEventArgs e)
        {
            jsonwin r3 = new jsonwin();
            this.Close();
            r3.Show();
        }

        private void go(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow r7 = new MainWindow();
            r7.Show();
        }

        private void izbran(object sender, RoutedEventArgs e)
        {
            jsonwin r3 = new jsonwin();
            this.Close();
            r3.Show();
        }
    }
}
