using MVVMproject.ViewModel;
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
using MVVMproject.Model;
using MVVMproject.ViewModel;

namespace MVVMproject.View
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        private UserViewModel viewModel;

        public RegisterPage(UserViewModel sharedViewModel)
        {
            InitializeComponent();
            viewModel = sharedViewModel;
        }

        private void Fname_GotFocus(object sender, RoutedEventArgs e)
        {
            FnameTXT.Text = string.Empty;
        }
        private void Lname_GotFocus(object sender, RoutedEventArgs e)
        {
            LnameTXT.Text = string.Empty;
        }
        private void Email_GotFocus(object sender, RoutedEventArgs e)
        {
            EmailTXT.Text = string.Empty;
        }
        private void Pass_GotFocus(object sender, RoutedEventArgs e)
        {
           PassTXT.Text = string.Empty;
        }

        private void RegisterBTN_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTXT.Text;
            string password = PassTXT.Text;
            string firstName = FnameTXT.Text;
            string lastName = LnameTXT.Text;

            if (viewModel.IsPasswordValid(password))
            {
                viewModel.AddUser(email, password, firstName, lastName);
                MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                LoginPage loginpage = new LoginPage();
                loginpage.Show();
                Close();
            }
        }
    }

}
