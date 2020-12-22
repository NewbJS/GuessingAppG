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

namespace GuessingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static readonly Random rc = new Random();
        private static readonly int ranNum = rc.Next(11);
        private int gotWrong = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int guessAsNum = Convert.ToInt32(Guess.Text);

            if(guessAsNum > ranNum)
            {
                GuessInfo.Content = "Your guess was too high. Try again!";
                gotWrong++;
            }
            else if (guessAsNum < ranNum)
            {
                gotWrong++;
                GuessInfo.Content = "Your guess was too low. Try again!";
            }
            else
            {
                if(gotWrong > 3)
                {
                    GuessInfo.Content = $"You guessed correctly!\nYou got {gotWrong} wrong. You lose.";
                }
                else
                {
                    GuessInfo.Content = $"You guess correctly!\nYou got {gotWrong} wrong. You win!";
                }
                MakeGuess.IsEnabled = false;
            }
        }
    }
}
