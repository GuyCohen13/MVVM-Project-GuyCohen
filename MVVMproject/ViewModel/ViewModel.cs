using MVVMproject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MVVMproject.Model;

namespace MVVMproject.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private static UserViewModel _instance;
        public List<User> _users;

        public event PropertyChangedEventHandler? PropertyChanged;

        public static UserViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserViewModel();
                }
                return _instance;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsPasswordValid(string password)
        {
            return password.Length >= 6
                && password.Length <= 10
                && password.Any(char.IsUpper)
                && password.Any(char.IsDigit);
        }

        public void AddUser(string mail, string password, string name, string lastName, int age)
        {
            if (IsPasswordValid(password))
            {
                int newUserId = _users.Count + 1;

                User newUser = new User
                {
                    UserId = newUserId,
                    eMail = mail,
                    password = password,
                    firstName = name,
                    LastName = lastName,
                };

                _users.Add(newUser);

                OnPropertyChanged(nameof(Users));
            }
            else
            {
                MessageBox.Show("Password needs to be between 6-10 characters, have at least one upper case letter, and at least one number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool UserExists(string email, string password)
        {
            return _users.Any(user => user.eMail == email && user.password == password);
        }

        public UserViewModel()
        {
            _users = new List<User>
            {
                new User { UserId = 1, eMail = "eldenfan2009@gmail.com", password ="malikethballs", firstName = "wolfguy", LastName = "epic",},
                new User { UserId = 2, eMail = "example@gmail.com", password = "gig", firstName = "elden", LastName = "god",},
                new User { UserId = 3, eMail = "example2@gmail.com", password = "gig2", firstName = "lord", LastName = "havemercy",},
                new User { UserId = 4, eMail = "example3@gmail.com", password = "gig3", firstName = "blaidd", LastName = "furry",},
                new User { UserId = 5, eMail = "example4@gmail.com", password = "gig4", firstName = "melina", LastName = "gothie",}
            };
        }

        public void AddUser(string email, string password, string firstName, string lastName)
        {
            if (IsPasswordValid(password))
            {
                int newUserId = _users.Count + 1;

                User newUser = new User
                {
                    UserId = newUserId,
                    eMail = email,
                    password = password,
                    firstName = firstName,
                    LastName = lastName,
                };

                _users.Add(newUser);

                OnPropertyChanged(nameof(Users));
            }
            else
            {
                MessageBox.Show("Password needs to be between 6-10 characters, have at least one upper case letter, and at least one number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public List<User> Users
        {
            get { return _users; }
            set
            {
                if (_users != value)
                {
                    _users = value;
                    OnPropertyChanged(nameof(Users));
                }
            }
        }
    }
}
