using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Shell;

namespace maska.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditProducts.xaml
    /// </summary>
    public partial class AddEditProducts : Page
    {
        string imagePath;
        string pathTo;
        Worker thisWorker;
        Masks Masks;
        bool add = false;
        public AddEditProducts(Worker worker, Masks masks)
        {
            InitializeComponent();
            Masks = masks;
            if (worker != null)
            {
                //Title.Text = user.Title;
                //Cost.Text = user.Cost.ToString();
                //CountPack.Text = user.ProductionPersonCount.ToString();
                int i = 0;
                //foreach (var item in CurrentList.db.ProductType.ToList())
                {
                //    Type.Items.Add(item.Title);
                //    if (item.ID == user.ProductTypeID)
                //        Type.SelectedIndex = i;
                 //   i++;
                }

                thisWorker = worker;
            }
            else
            {
                delete.Visibility = Visibility.Hidden;
                add = true;
                //foreach (var item in CurrentList.db.ProductType.ToList())
                //{
                 //   Type.Items.Add(item.Title);
                //}
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Masks.LViewTours.ItemsSource = CurrentList.userr;
            Manager.frame.GoBack();
        }

        private void Title_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Title.Text == "Title")
                Title.Text = "";
            else if (Title.Text == "")
                Title.Text = "Title";
        }
        private void Count_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CountPack.Text == "Count in pack")
                CountPack.Text = "";
            else if (CountPack.Text == "")
                CountPack.Text = "Count in pack";
        }
        private void Cost_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Cost.Text == "Cost")
                Cost.Text = "";
            else if (Cost.Text == "")
                Cost.Text = "Cost";
        }



        private void CountPack_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = ((TextBox)sender).Text;
            if (text == "" || text == "Count in pack" || text == "Cost")
                return;
            try
            {
                int.Parse(text[text.Length - 1].ToString());
            }
            catch
            {
                ((TextBox)sender).Text = text.TrimEnd(text[text.Length - 1]);
            }
        }

        //Функция добавления/изменения продукта
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Проверка того, какое действие выбрано: создание или редактирование
            if (add)
                thisWorker = new Worker();

            //Если редактирование вносятся данные данные в экземпляр класса Product
            //thisUser.Title = Title.Text;
            //thisUser.Cost = decimal.Parse(Cost.Text);
            //thisUser.ProductionPersonCount = int.Parse(CountPack.Text);
            //thisUser.ProductTypeID = CurrentList.db.ProductType.ToList().Where(x => x.Title == Type.SelectedValue).FirstOrDefault().ID;


            //Добавление продукта
            if (add)
            {
                CurrentList.db.Worker.Add(thisWorker);
                CurrentList.db.SaveChanges();
            }
            else //Редактирование продукта
            {
                CurrentList.db.SaveChanges();
            }
            CurrentList.userr = CurrentList.db.User.ToList();
            MessageBox.Show("OK");
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //Вывод диалогового окна для подтверждения действия от пользователя
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                //Удаление продукта из БД
                CurrentList.db.Worker.Remove(thisWorker);
                CurrentList.db.SaveChanges();

                //Обновление списка продуктов
                CurrentList.userr = CurrentList.db.User.ToList();
                Masks.LViewTours.ItemsSource = CurrentList.userr;
                Manager.frame.GoBack();
            }
        }

    }
}
