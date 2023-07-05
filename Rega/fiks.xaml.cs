using Rega.Model;
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

namespace Rega
{
    /// <summary>
    /// Логика взаимодействия для fiks.xaml
    /// </summary>
    public partial class fiks : Window
    {
        readonly private List<Profil> information;
        public fiks()
        {
            InitializeComponent();
            information = AfiasalesEntities4.GetContent().Profil.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (information[0].Login != null)
            {
                zapolnenie.For_full_name = information[0].Login;
                profil profil = new profil();
                profil.Show();
                this.Hide();

            }
        }
    }
}
