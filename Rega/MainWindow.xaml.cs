using Rega.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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

namespace Rega
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly private List<Profil> information;
        public MainWindow()
        {
            InitializeComponent();
            information = AfiasalesEntities4.GetContent().Profil.ToList();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 r1 = new Window2();
            this.Close();
            r1.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(log.Text) && string.IsNullOrEmpty(pas.Text))
                MessageBox.Show("Поля должны быть заполнены!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                if (string.IsNullOrEmpty(log.Text) && pas.Text != null)
                    MessageBox.Show("Поле логина не заполнено!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                {
                    if (log.Text != null && string.IsNullOrEmpty(pas.Text))
                        MessageBox.Show("Поле пароля не заполнено!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    else
                    {
                        var UN = log.Text;
                        var P = pas.Text;
                        var obj = information.Where(i => (i.Login == UN) && (i.Password == P));
                        string TUN = "";
                        string TP = "";
                        foreach (var users in obj)
                        {
                            TUN = users.Login;
                            TP = users.Password;
                        }

                        if ((UN == TUN) && (P == TP))
                        {
                            zapolnenie.For_full_name = UN;
                             MessageBox.Show("Добрый день, вы успешно вошли в систему!", "Отлично!", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Hide();
                            profil profile = new profil();
                            profile.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Пароль и логин неправильные! Попробуйте снова.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }
    }
}
