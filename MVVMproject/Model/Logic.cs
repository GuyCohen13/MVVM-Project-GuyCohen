using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMproject.Model
{
    internal class Logic
    {
        public int num1 { get; private set; }
        public int num2 { get; private set; }
        public int correctAnswer { get; private set; }
        public int type { get; set; }
        public string currentType { get; set; }
        private int correctCount;
        private int wrongCount;
        private int score;

        public Logic()
        {
            generateQuestion();
        }

        public void generateQuestion()
        {
            Random random = new Random();
            type = random.Next(1, 5);

            do
            {
                num1 = random.Next(1, 11);
                num2 = random.Next(1, 11);
            } while ((type == 3 && num1 % num2 != 0) || (type == 2 && num1 <= num2));

            if (type == 1)
            {
                currentType = "+";
                correctAnswer = num1 + num2;
            }
            else if (type == 2)
            {
                currentType = "-";
                correctAnswer = num1 - num2;
            }
            else if (type == 3)
            {
                currentType = "/";
                correctAnswer = num1 / num2;
            }
            else if (type == 4)
            {
                currentType = "*";
                correctAnswer = num1 * num2;
            }
        }

        public void checkAnswer(int userAnswer)
        {
            if (userAnswer == correctAnswer)
            {
                correctCount++;
                score += 10;
            }
            else
            {
                wrongCount++;
            }
        }
        public int GetScore()
        {
            return score;
        }
        public bool IsGameComplete()
        {
            return (correctCount + wrongCount) == 10;
        }

    }
}
