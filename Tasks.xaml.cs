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
    /// Логика взаимодействия для Tasks.xaml
    /// </summary>
    public partial class Tasks : Page
    {
        //Manager manager;
        //Executor executor;

        public List<Task> TasksList { get; set; }

        public Tasks(Manager manager)
        {
            InitializeComponent();

            TasksList = Core.db.Task.ToList();

            DataContext = this;
        }

        public Tasks(Executor executor)
        {
            InitializeComponent();

            TasksList = Core.db.Task.ToList().Where((a) => a.Executor == executor).ToList();

            DataContext = this;
        }
    }
}
