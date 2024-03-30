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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для reg.xaml
    /// </summary>
    public partial class reg : Window
    {
        public reg()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }

        private void RegBtn_Копировать_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginBox.Text;

            var pass = PassBox.Text;

            var context = new AppDbContext();

            var user_exists = context.Users.FirstOrDefault(x=> x.Login == login);
            if (user_exists is not null)
            {
                MessageBox.Show("Такой пользователь уже зарегистрирован");
                return;
            }
            var user = new User { Login = login, Password = pass };
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("Вы успешно зарегестрировались");
        }
    }
}
