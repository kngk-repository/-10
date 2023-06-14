using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для AddEdit.xaml
    /// </summary>
    public partial class AddEdit : Page
    {
        private Service _currentServices = new Service();
        public AddEdit(Service selectedServices)
        {
            InitializeComponent();

            if (selectedServices != null)
            {
              _currentServices = selectedServices;
            }

            DataContext = _currentServices;
            //ComboTime.ItemsSource = BaaseEntities1.GetContext().Servises.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentServices.Title))
                errors.AppendLine("укажите название услуги");
            if (_currentServices.Cost == null)
                errors.AppendLine("укажите стоимость");
            if (_currentServices.DurationInSeconds == null)
                errors.AppendLine("Укажите длительность");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentServices.ID == 0)
                BaseEntities.GetContext().Service.Add(_currentServices);
            try
            {
                BaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Новая услуга сохранена");
                Manager.MainFrame.GoBack();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

    
    }
}
