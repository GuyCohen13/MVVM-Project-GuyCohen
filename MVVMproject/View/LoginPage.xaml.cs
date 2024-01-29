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
using MVVMproject.Model;
using MVVMproject.ViewModel;
using MVVMproject.View;


namespace MVVMproject.View
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
            DataContext = UserViewModel.Instance;
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            UserViewModel viewModel = (UserViewModel)DataContext;
            string currentEmail = emailTxt.Text;
            string currentPassword = PasswordTxt.Text;

            if (viewModel.UserExists(currentEmail, currentPassword))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.");
            }
        }

        private void RegisterBTN_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage registerPage = new RegisterPage((UserViewModel)DataContext);
            registerPage.Show();
            Close();
        }
    }

}
