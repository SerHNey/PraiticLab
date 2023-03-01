using maska.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace maska
{
    /// <summary>
    /// Логика взаимодействия для Maski.xaml
    /// </summary>
    public partial class Masks : Page
    { 
        public IEnumerable<Result> currentList;
        public Masks()
        {
            InitializeComponent();
            if (CurrentList.workerr != null)
            {
                if (CurrentList.workerr.type == 1)
                    Add.Visibility = Visibility.Visible;
            }
            currentList = CurrentList.result;
            LViewTours.ItemsSource = currentList;
        }
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search.Text != "" && LViewTours != null)
            {
               // var filterName = currentList.Where(t => t.Title.ToLower().Contains(search.Text.ToLower()));
                //LViewTours.ItemsSource = filterName;
            }
            else
            {
                if(LViewTours != null)
                {
                    var current = currentList.ToList();
                    LViewTours.ItemsSource = current;
                }
                
            }
        }

        protected void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var track = ((ListView)sender).SelectedItem as Worker;
            if(track != null && CurrentList.workerr != null)
            {
                if(CurrentList.workerr.type == 1)
                    Manager.frame.Navigate(new AddEditProducts(track,this));
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Manager.frame.GoBack();
        }

        private void Basket_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new AddEditProducts(null,this));
        }

        private void Buy_click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
                return;
           // Product item = button.DataContext as Product;
           // BasketList.products.Add(item);
        }

        private void FilerBtn_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        private void SortBtn_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;

        }

        private void SortByАlphabet_Click(object sender, RoutedEventArgs e)
        {
           // currentList = currentList.OrderBy(product => product.Title);
            LViewTours.ItemsSource = currentList;
        }

        private void ReverseByАlphabet_Click(object sender, RoutedEventArgs e)
        {
           // currentList = currentList.OrderBy(product => product.Title);
            LViewTours.ItemsSource = currentList;
        }

        private void SortByCost_Click(object sender, RoutedEventArgs e)
        {
            //currentList = currentList.OrderBy(product => product.Cost);
            LViewTours.ItemsSource = currentList;
        }

        private void ReverseByCost_Click(object sender, RoutedEventArgs e)
        {
           // currentList = currentList.OrderByDescending(product => product.Cost);
            LViewTours.ItemsSource = currentList;
        }

        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            currentList = CurrentList.db.Result.ToList();
            LViewTours.ItemsSource = currentList;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = e.OriginalSource as MenuItem;
            FilterItemsByType(mi.Header.ToString());
        }

        private void FilterItemsByType(string type)
        {
            currentList = CurrentList.db.Result.ToList();
            //currentList = currentList.Where(product => product.ProductType.Title == type);
            LViewTours.ItemsSource = currentList;
        }
    }
}
