using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

namespace SampleBase
{
    /// <summary>
    /// Логика взаимодействия для Services.xaml
    /// </summary>
    public partial class Services : Page
    {
        
        public Services()
        {

            InitializeComponent();
            DGridServices.ItemsSource = NikoBaseEntities.GetContext().Service.ToList();
        }
        
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEdit((sender as Button).DataContext as Service));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEdit(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var servicesForRemoving = DGridServices.SelectedItems.Cast<Service>().ToList();
            if (MessageBox.Show($"Вы действительно хотите удалить выбранные {servicesForRemoving.Count()} элементов?", "Внимание!",
                MessageBoxButton.YesNo, MessageBoxImage.Question)== MessageBoxResult.Yes)

                try
                {
                    NikoBaseEntities.GetContext().Service.RemoveRange(servicesForRemoving);
                    NikoBaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridServices.ItemsSource = NikoBaseEntities.GetContext().Service.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                        
        }
        private void Page_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility== Visibility.Visible)
            {
                NikoBaseEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p=> p.Reload());
                DGridServices.ItemsSource = NikoBaseEntities.GetContext().Service.ToList();

            }
        }
    }
}
