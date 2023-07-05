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
    /// Логика взаимодействия для jsonwin.xaml
    /// </summary>
    public partial class jsonwin : Window
    {
        work_js fwwj = new work_js();
        public jsonwin()
        {
            InitializeComponent();
            Load_data();
        }

        private void Load_data()
        {
            var all_data = fwwj.Get_all_display_data();
            Grid1.ItemsSource = all_data;
        }

        private void Go_back_Click(object sender, RoutedEventArgs e)
        {
            profil r6 = new profil();
            this.Close();
            r6.Show();
        }

        private void Get_message_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Точно хотите купить билет?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                MessageBox.Show("Деньги списанны! По всем вопросам оброщайтесь вслужбу поддержки", "Вас заскамили!", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Покупка отменена", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
