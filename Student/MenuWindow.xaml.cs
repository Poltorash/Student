using Student.Windows;
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
using System.Windows.Shapes;

namespace Student
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            UpdateStudent();
        }

        private void UpdateStudent()
        {
            using (var DB = new StudentModel())
            {
                DGR_Student.ItemsSource = null;
                DGR_Student.ItemsSource = DB.Students.ToList();
            }
        }

        private void CuratorWin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GroupWin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReportWin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddStudent add = new AddStudent(this,(Student)DGR_Student.SelectedItems, false);
            add.Show();
            this.IsEnabled = false;
        }
    }
}
