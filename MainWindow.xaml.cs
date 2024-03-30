﻿using System;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            reg reg = new reg();
            reg.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            var login = LoginBox.Text;

            var password = PassBox.Text;

            var context = new AppDbContext();

            var user = context.Users.SingleOrDefault(x=> x.Login ==  login && x.Password == password);
            if (user is null)
            {
                MessageBox.Show("Неправильный логин или пароль!");
                return;
            }
            MessageBox.Show("Вы успешно вошли в аккаунт!");
        }
    }
}
public class User
{
    public int Id { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }
}
