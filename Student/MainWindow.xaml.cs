﻿using System;
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

namespace Student
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (var db = new StudentModel()) 
            {
                ComboLog.ItemsSource = db.Curators.ToList();
            }
        }

        private void BtnAutorization_Click(object sender, RoutedEventArgs e)
        {
            bool key = false;
            using (var db = new StudentModel()) 
            {
                foreach (var autorization in db.Curators.ToList()) 
                {
                    if (ComboLog.SelectedValue.ToString() == autorization.LastName && PasswordB.Password == autorization.Password) 
                    {
                       (new MenuWindow()).Show();                      
                        key = true;
                        this.Close();
                    }
                }
            }
            if (key == false) 
            {
                MessageBox.Show("Неверный пароль");
            }
        }
    }
}
