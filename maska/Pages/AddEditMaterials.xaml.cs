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
    /// Логика взаимодействия для AddEditMaterials.xaml
    /// </summary>
    public partial class AddEditMaterials : Page
    {
        string imagePath;
        string pathTo;
        Service thisservice;
        Materials Materials;
        bool add = false;
        public AddEditMaterials(Service service, Materials materials)
        {
            InitializeComponent();
            Materials = materials;
            if (service != null)
            {
                //Title.Text = result.Title;
                //Cost.Text = result.Cost.ToString();
                //CountPack.Text = result.CountInPack.ToString();
                int i = 0;

                thisservice = service;
            }
            else
            {
                delete.Visibility = Visibility.Hidden;
                add = true;
                //foreach (var item in CurrentList.db.MaterialType.ToList())
                //{
                //    Type.Items.Add(item.Title);
                //}
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Materials.LViewTours.ItemsSource = CurrentList.result;
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

       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (add)
                thisservice = new Service();
            //thisResult.Title = Title.Text;
            //thisResult.Cost = decimal.Parse(Cost.Text);
            //thisResult.CountInPack = int.Parse(CountPack.Text);
            //thisResult.MaterialTypeID = CurrentList.db.MaterialType.ToList().Where(x => x.Title == Type.SelectedValue).FirstOrDefault().ID;

            if (add)
            {
                CurrentList.db.Service.Add(thisservice);
                CurrentList.db.SaveChanges();
            }
            else
            {
                CurrentList.db.SaveChanges();
            }
            CurrentList.result = CurrentList.db.Result.ToList();
            MessageBox.Show("OK");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                CurrentList.db.Service.Remove(thisservice);
                CurrentList.db.SaveChanges();
                CurrentList.result = CurrentList.db.Result.ToList();
                Materials.LViewTours.ItemsSource = CurrentList.result;
                Manager.frame.GoBack();
            }
        }
    }
}
