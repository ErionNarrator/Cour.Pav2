﻿using Cour.Pav.ModelView;
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

namespace Cour.Pav.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginWindowViewModel(this);
            
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
           
        //    MainWindow mainWindow = new MainWindow();  // Создаем экземпляр MainWindow

           
        //    mainWindow.Show();  // Показываем MainWindow

            
        //    this.Close(); // Закрываем LoginWindow
        //}
    }
}