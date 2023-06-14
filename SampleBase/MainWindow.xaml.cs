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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SampleBase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MaineFrame.Navigate(new LoginPassword()); // чтобы вернуть отображение приветсвия и переходна в услуги "LoginPassword"
            Manager.MainFrame = MaineFrame; // создали класс и присвоили ему значение. теперь сможем обращаться к нему через обработчик событий

        }

        private void Button_Click(object sender, RoutedEventArgs e) //дата лист вью может отображать картинки и распологаться не построчно вот и все его отличие от дата грид. думаю использовать я это не буду поэтому и запоминать не надо.
        {
            Manager.MainFrame.GoBack();
        }
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MaineFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else 
            {
                BtnBack.Visibility = Visibility.Hidden;
            }

        }
    }
}
