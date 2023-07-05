using Rega.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace Rega
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private Profil ConnectionString = new Profil();
        private List<Profil> users;


        public Window2()
        {
            
            InitializeComponent();
            users = AfiasalesEntities4.GetContent().Profil.ToList();
            DataContext = ConnectionString;
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            var UN = TBlogin.Text;
            var obj = users.Where(i => i.Login == UN);
            string TUN = "";
            foreach (var inf in obj)
            {
                TUN = inf.Login;
            }
            if ((!string.IsNullOrEmpty(ConnectionString.Login)) && (TUN == UN))
                errors.AppendLine("Этот логин уже существует. Пожалуйста введите другой логин. Максимальная длина 50 символов\n\nЛОГИН НЕЛЬЗЯ ИЗМЕНИТЬ ПОСЛЕ ТОГО, КАК ВЫ УЖЕ ЗАРЕГИСТРИРОВАЛИСЬ!");
            if (string.IsNullOrWhiteSpace(ConnectionString.Surname) || (ConnectionString.Surname.Length > 50))
                errors.AppendLine("Пожалуйста, напишите свою фамилию. Максимальная длина 50 символов\n");
            if (string.IsNullOrWhiteSpace(ConnectionString.Name) || (ConnectionString.Name.Length > 50))
                errors.AppendLine("Пожалуйста, напишите своё имя. Максимальная длина 50 символов\n");
            if (string.IsNullOrWhiteSpace(ConnectionString.Otjestvo) || (ConnectionString.Otjestvo.Length > 50))
                errors.AppendLine("Пожалуйста, напишите своё отчество. Максимальная длина 50 символов\n");
            if (string.IsNullOrEmpty(ConnectionString.Password) || (ConnectionString.Password.Length < 4) || (ConnectionString.Password.Length > 8))
                errors.AppendLine("Пожалуйста, введите свой пароль. Минимальная длина 4, а максимальная 8\n");
            if (string.IsNullOrEmpty(ConnectionString.Login) || (ConnectionString.Login.Length > 50))
                errors.AppendLine("Пожалуйста, напишите свой логин. Максимальная длина 50 символов\n\nЛОГИН НЕЛЬЗЯ ИЗМЕНИТЬ ПОСЛЕ ТОГО, КАК ВЫ УЖЕ ЗАРЕГИСТРИРОВАЛИСЬ!");
            ConnectionString.image = "C:\\Users\\79256\\Pictures\\TfVD5fZ2QDs.jpg";
            if (errors .Length > 0)
            {
                MessageBox.Show(errors.ToString(), "sgd", MessageBoxButton.OK);
                return;
            }
            if (ConnectionString.Login.Length > 0)
                AfiasalesEntities4.GetContent().Profil.Add(ConnectionString);

            try
            {
                AfiasalesEntities4.GetContent().SaveChanges();
                MessageBox.Show("Информация сохранена!", "sgd", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            zapolnenie.For_full_name = TBlogin.Text;
            this.Hide();
            profil profil = new profil();
            profil.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow r1 = new MainWindow();
            this.Close();
            r1.Show();
        }
    }
}