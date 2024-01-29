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
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using MVVMproject.Model;

namespace MVVMproject.View
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Window
    {
        private Logic mathLogic;
        private int count = 0;


        public GamePage(string userName, string userAge)
        {
            InitializeComponent();
            this.Background = new SolidColorBrush(Colors.SteelBlue);
            mathLogic = new Logic();
            showQuestions(); 
            name.Text = ("Good Luck " + userName + "!");

            GameMusic.Play();
        }

        private void showQuestions()
        {
            mathLogic.generateQuestion();

            num1block.Text = mathLogic.num1.ToString();
            num2block.Text = mathLogic.num2.ToString();
            function.Text = mathLogic.currentType;
        }

        private void txtAnswer_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == "Answer")
            {
                textBox.Text = string.Empty;
            }
        }

        private void checkAnswer_Click(object sender, RoutedEventArgs e)
        {
            while (count < 1)
            {
                count++;
                counterBlock.Text = "0/10";
            }
            counterBlock.Text = count + "/10";

            if (int.TryParse(answerBox.Text, out int userAnswer))
            {
                mathLogic.checkAnswer(userAnswer);

                if (mathLogic.correctAnswer == userAnswer)
                {
                    MessageBox.Show("Correct!");
                    count++;
                }
                else
                {
                    MessageBox.Show("Incorrect!");
                    count++;
                }

                if (mathLogic.IsGameComplete())
                {
                    MessageBox.Show("Congratulations! Your Score: " + mathLogic.GetScore() + "/100");

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }

                answerBox.Text = string.Empty;
                showQuestions();
                Score.Text = "Score: " + mathLogic.GetScore().ToString();
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid number.");
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}

