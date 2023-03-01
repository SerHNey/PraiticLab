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

namespace maska
{
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            if(CurrentList.workerr!= null)
            {
                if (CurrentList.workerr.type == 1)
                {
                    userInfo.Text = "ФИО: "+ CurrentList.workerr.name + "   " + "\nРоль: Администратор";
                }
                if (CurrentList.workerr.type == 2)
                {
                    userInfo.Text = "ФИО: "+CurrentList.workerr.name + "   " + "\nРоль: Пользователь";
                }
            }


        }

        private void ProductsCatalog(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new Masks());
        }

        private void MaterialsCatalog(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new Materials());
        }
    }
}
