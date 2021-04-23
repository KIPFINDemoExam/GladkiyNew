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

namespace Gladkiy
{
    /// <summary>
    /// Логика взаимодействия для ManagerMenuPage.xaml
    /// </summary>
    public partial class ManagerMenuPage : Page
    {
        Manager manager;

        public ManagerMenuPage(Manager m)
        {
            InitializeComponent();
            manager = m;
        }

        private void Indices_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new IndicesPage(manager));
        }

        private void Tasks_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Tasks(manager));
        }
    }
}
