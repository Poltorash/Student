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

namespace Student.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        MenuWindow Menu;
        bool Edit;
        Student Students;
        public AddStudent()
        {
            InitializeComponent();
        }

        public void AddCombo()
        {
            CB_Curator.ItemsSource = null;
            CB_Group.ItemsSource = null;
            using (var Db = new StudentModel())
            {
                CB_Curator.ItemsSource = Db.Curators.ToList();
                CB_Group.ItemsSource = Db.Groups.ToList();
            }
        }
        public AddStudent(MenuWindow menu,Student student,bool edit)
        {
            InitializeComponent();
            Menu = menu;
            Students = student;
            Edit = edit;
            for (int i = 2007; i < 2020; i++) 
            {
                CB_Year_of_admission.Items.Add(i);
            }
            
            if (Edit == true) 
            {
                TB_Title.Text = "Студент редактирование";
                TB_FirstName.Text = Students.FirstName;
                TB_LastName.Text = Students.LastName;
                TB_MiddleName.Text = Students.MiddleName;
                CB_Year_of_admission.SelectedItem = Students.Year_of_admission - 2007;
                CB_Group.SelectedItem = Students.GroupID - 1;
                TB_Scholarship.Text = Students.Scholarship;
            }
        }
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Edit == false)
                {
                    int id = 0;
                    using (var DB = new StudentModel())
                    {
                        foreach (var ID in DB.Students.ToList()) { id = ID.StudentID; }
                        DB.Students.Add(new Student()
                        {
                            StudentID = id + 1,
                            FirstName = TB_FirstName.Text,
                            LastName = TB_LastName.Text,
                            MiddleName = TB_MiddleName.Text,
                            Scholarship = TB_Scholarship.Text,
                            GroupID = CB_Group.SelectedValue,
                            Year_of_admission = CB_Year_of_admission.SelectedItem
                            //Фото не забудь
                        });
                    }
                }

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message)
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Menu.IsEnabled = true;
            this.Close();
        }
    }
}
