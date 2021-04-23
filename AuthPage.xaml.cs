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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        List<Manager> managers;
        List<Manager> executors;

        public AuthPage()
        {
            InitializeComponent();

            managers = Core.db.Manager.ToList();
            executors = Core.db.Manager.ToList();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text.Trim();
            var password = passwordTextBox.Password.Trim();

            foreach (var manager in managers)
            {
                if (manager.Логин == login && manager.Пароль == password)
                {
                    MessageBox.Show("Вы вошли как менеджер");
                    NavigationService.Navigate(new ManagerMenuPage(manager));
                    return;
                }
            }

            foreach (var executor in executors)
            {
                if (executor.Логин == login && executor.Пароль == password)
                {
                    MessageBox.Show("Вы вошли как исполнитель");
                    NavigationService.Navigate(new Tasks(executor));
                    return;
                }
            }

            MessageBox.Show("Неправильный логин или пароль");
        }
    }
}
