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
    /// Логика взаимодействия для IndicesPage.xaml
    /// </summary>
    public partial class IndicesPage : Page
    {
        Manager manager;
        Salary salary;

        public IndicesPage(Manager manager)
        {
            InitializeComponent();

            this.manager = manager;
            this.salary = Core.db.Salary.ToList().Find((a) => a.Manager == manager);

            juniorTextBox.Text = salary.Junior__мин_ЗП_.ToString();
            middleTextBox.Text = salary.Middle__мин_ЗП_.ToString();
            seniorTextBox.Text = salary.Senior__мин_ЗП_.ToString();

            complexityTextBox.Text = salary.Коэффициент_сложности.ToString();
            timeTextBox.Text = salary.Коэффициент_Времени.ToString();
            moneyTextBox.Text = salary.Коэффициент_Денег.ToString();

            w1TextBox.Text = salary.Коэффициент_для_Анализ_и_проектирование.ToString();
            w2TextBox.Text = salary.Коэффициент_для_Установка_оборудования.ToString();
            w3TextBox.Text = salary.Коэффициент_для_Техническое_обслуживание_и_сопровождение.ToString();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            var result = TryParseData();
            if (result == null)
            {
                Core.db.SaveChanges();
                MessageBox.Show("Сохранено");
            }
            else
            {
                MessageBox.Show(result.Value.message, "Произошла ошибка при считывании данных", MessageBoxButton.OK, MessageBoxImage.Error);
                result.Value.invalidInput.Focus();
            }
        }

        private (TextBox invalidInput, string message)? TryParseData()
        {
            if (!decimal.TryParse(juniorTextBox.Text.Trim(), out var junior))
                return (juniorTextBox, "Поле 'Junior__мин_ЗП_' должно быть числом");
            if (junior < 0)
                return (juniorTextBox, "Поле 'Junior__мин_ЗП_' не должно быть отрицательным");

            if (!decimal.TryParse(middleTextBox.Text.Trim(), out var middle))
                return (middleTextBox, "Поле 'Middle__мин_ЗП_' должно быть числом");
            if (middle < 0)
                return (middleTextBox, "Поле 'Middle__мин_ЗП_' не должно быть отрицательным");

            if (!decimal.TryParse(seniorTextBox.Text.Trim(), out var senior))
                return (seniorTextBox, "Поле 'Senior__мин_ЗП_' должно быть числом");
            if (senior < 0)
                return (seniorTextBox, "Поле 'Senior__мин_ЗП_' не должно быть отрицательным");


            if (!int.TryParse(complexityTextBox.Text.Trim(), out var complexity))
                return (complexityTextBox, "Поле 'Коэффициент_сложности' должно быть числом");
            if (complexity < 0)
                return (complexityTextBox, "Поле 'Коэффициент_сложности' не должно быть отрицательным");

            if (!int.TryParse(timeTextBox.Text.Trim(), out var time))
                return (timeTextBox, "Поле 'Коэффициент_Времени' должно быть числом");
            if (time < 0)
                return (timeTextBox, "Поле 'Коэффициент_Времени' не должно быть отрицательным");

            if (!int.TryParse(moneyTextBox.Text.Trim(), out var money))
                return (moneyTextBox, "Поле 'Коэффициент_Денег' должно быть числом");
            if (money < 0)
                return (moneyTextBox, "Поле 'Коэффициент_Денег' не должно быть отрицательным");


            if (!double.TryParse(w1TextBox.Text.Trim(), out var w1))
                return (w1TextBox, "Поле 'Коэффициент_для_Анализ_и_проектирование' должно быть числом");
            if ((w1<0 )&&(w1>=1))
                return (w1TextBox, "Поле 'Коэффициент_для_Анализ_и_проектирование' должно быть в диапазоне от 0 до 1");

            if (!double.TryParse(w2TextBox.Text.Trim(), out var w2))
                return (w2TextBox, "Поле 'Коэффициент_для_Установка_оборудования' должно быть числом");
            if ((w2 < 0) && (w2 >= 1))
                return (w2TextBox, "Поле 'Коэффициент_для_Установка_оборудования' должно быть в диапазоне от 0 до 1");

            if (!double.TryParse(w3TextBox.Text.Trim(), out var w3))
                return (w3TextBox, "Поле 'Коэффициент_для_Техническое_обслуживание_и_сопровождение' должно быть числом");
            if ((w3 < 0) && (w3 >= 1))
                return (w3TextBox, "Поле 'Коэффициент_для_Техническое_обслуживание_и_сопровождение' должно быть в диапазоне от 0 до 1");



            salary.Junior__мин_ЗП_ = junior;
            salary.Middle__мин_ЗП_ = middle;
            salary.Senior__мин_ЗП_ = senior;

            salary.Коэффициент_сложности = complexity;
            salary.Коэффициент_Времени = time;
            salary.Коэффициент_Денег = money;

            salary.Коэффициент_для_Анализ_и_проектирование = w1;
            salary.Коэффициент_для_Установка_оборудования = w2;
            salary.Коэффициент_для_Техническое_обслуживание_и_сопровождение = w3;

            return null;
        }
    }
}
