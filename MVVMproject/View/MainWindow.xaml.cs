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

namespace MVVMproject.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            this.Background = new SolidColorBrush(Colors.SteelBlue);

            MainMusic.Play();
        }

        private void TextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBox textBox && name.Text == "Gamertag")
            {
                name.Text = string.Empty;
            }
        }

        private void TextBox2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBox textBox && age.Text == "Age")
            {
                age.Text = string.Empty;
            }
        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            string userName = name.Text;
            string userAge = age.Text;

            if (name.Text.Length > 0 && age.Text.Length > 0 && name.Text != "Name" && age.Text != "Age")
            {
                GamePage gameWindow = new GamePage(userName, userName);
                gameWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You must write your gamertag and age before starting!");
            }

        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}

