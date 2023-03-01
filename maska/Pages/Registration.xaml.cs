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

namespace maska.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }


        private void registration_Click(object sender, MouseButtonEventArgs e)
        {
            string log = login.Text;
            string fioo = fio.Text;
            string pas = password.Text;
            string pas1 = password_Copy.Text;
            if (log != "")
            {
                if (pas != "")
                {
                    if (pas1 != "")
                    {
                        if (pas == pas1)
                        {
                            Worker user = new Worker();
                            int count = Entities1Medicall.GetContext().Worker.Count();
                            user.login = log;
                            user.type = 2;
                            user.name = fioo;
                            user.password = pas;
                            Entities1Medicall.GetContext().Worker.Add(user);
                            Entities1Medicall.GetContext().SaveChanges();
                            Manager.frame.Navigate(new Authorization());
                        }
                        else
                        {
                            MessageBox.Show("Пароли не совпадают");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Повторите пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Введите пароль");
                }
            }
            else
            {
                MessageBox.Show("Введите логин");
            }

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new Authorization());
        }

        private void registration_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new Authorization());
        }

    }
}
