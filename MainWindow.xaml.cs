/* Nathan Peereboom
 * April 25, 2019
 * Unit 3 summative: hangman game
 */


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

namespace _312840Hangman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //global variables
        string[] easy = new string[10];
        string[] medium = new string[10];
        string[] hard = new string[10];
        string[] extreme = new string[10];
        string answer;
        char userInput;
        int fails;

        public MainWindow()
        {
            InitializeComponent();

            //stream readers
            System.IO.StreamReader easyReader = new System.IO.StreamReader("easy.txt");
            for (int i = 0; i < 10; i++)
            {
                easy[i] = easyReader.ReadLine();
            }
            easyReader.Close();

            System.IO.StreamReader mediumReader = new System.IO.StreamReader("medium.txt");
            for (int i = 0; i < 10; i++)
            {
                medium[i] = mediumReader.ReadLine();
            }
            mediumReader.Close();

            System.IO.StreamReader hardReader = new System.IO.StreamReader("hard.txt");
            for (int i = 0; i < 10; i++)
            {
                hard[i] = hardReader.ReadLine();
            }
            hardReader.Close();

            System.IO.StreamReader extremeReader = new System.IO.StreamReader("extreme.txt");
            for (int i = 0; i < 10; i++)
            {
                extreme[i] = extremeReader.ReadLine();
            }
            extremeReader.Close();

            answer = "";
        }

        //Start Game button
        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            //choose word
            Random rnd = new Random();
            int x = rnd.Next(10);
            bool difficultySet = false;
            if ((bool)rbEasy.IsChecked)
            {
                answer = easy[x];
                difficultySet = true;
            }
            if ((bool)rbMedium.IsChecked)
            {
                answer = medium[x];
                difficultySet = true;
            }
            if ((bool)rbHard.IsChecked)
            {
                answer = hard[x];
                difficultySet = true;
            }
            if ((bool)rbExtreme.IsChecked)
            {
                answer = extreme[x];
                difficultySet = true;
            }

            //start game
            if (difficultySet == true)
            {
                //set/reset environment
                lblInstruct0.Content = "";
                lblInstruct1.Content = "Enter a letter below.";
                lblInstruct2.Content = "Used letters:";
                btnStartGame.Content = "New Game";
                tblWordDisplay.Text = "";
                tblUsedLetters.Text = "";
                txtPlayerInput.Text = "";
                lblResult.Content = "";
                fails = 0;
                imgDisplay.Source = new BitmapImage(new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/8/8b/Hangman-0.png/60px-Hangman-0.png"));
                //Write underscores
                for (int i = 0; i < answer.Length; i++)
                {
                    tblWordDisplay.Text += "_ ";
                }
            }
            //difficulty not selected
            else
            {
                lblInstruct0.Content = "Please select a difficulty";
            }
        }

        //Submit Letter button
        private void btnCheckLetter_Click(object sender, RoutedEventArgs e)
        {
            //Check if user typed a character
            if (txtPlayerInput.Text.Length > 0)
            {
                userInput = txtPlayerInput.Text.ToUpper()[0];
            }
            //If user didn't type character
            else
            {
                userInput = ' ';
            }

            //Check if user started game
            if (answer.Length > 0)
            {
                lblInstruct1.Content = "Enter a letter below";
                //Check if user typed a proper letter
                if (userInput >= 65 && userInput <= 90)
                {
                    //Check if letter was already used by reading tblUsedLetters
                    bool repeatLetter = false;
                    for (int i = 0; i < tblUsedLetters.Text.Length; i++)
                    {
                        char readUsedLetters = tblUsedLetters.Text[i];
                        if (readUsedLetters.ToString().ToUpper() == userInput.ToString())
                        {
                            lblInstruct1.Content = "You've already used that one, silly.";
                            repeatLetter = true;
                        }
                    }

                    //If letter was not used already
                    if (repeatLetter == false)
                    {
                        //compare user's input to each letter in answer
                        tblUsedLetters.Text += userInput.ToString().ToLower() + " ";
                        bool foundLetter = false;
                        for (int i = 0; i < answer.Length; i++)
                        {
                            char readAnswer = answer[i];
                            //If a match is found
                            if (readAnswer == userInput)
                            {
                                tblWordDisplay.Text = tblWordDisplay.Text.Remove(i * 2, 1);
                                tblWordDisplay.Text = tblWordDisplay.Text.Insert(i * 2, userInput.ToString());
                                foundLetter = true;
                            }
                        }

                        //If no match was found
                        if (foundLetter == false)
                        {
                            //Add 1 to fails and update image
                            fails++;
                            switch (fails)
                            {
                                case 1:
                                    imgDisplay.Source = new BitmapImage(new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/3/30/Hangman-1.png/60px-Hangman-1.png"));
                                    break;
                                case 2:
                                    imgDisplay.Source = new BitmapImage(new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/7/70/Hangman-2.png/60px-Hangman-2.png"));
                                    break;
                                case 3:
                                    imgDisplay.Source = new BitmapImage(new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/3/30/Hangman-3.png/60px-Hangman-3.png"));
                                    break;
                                case 4:
                                    imgDisplay.Source = new BitmapImage(new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/3/30/Hangman-4.png/60px-Hangman-4.png"));
                                    break;
                                case 5:
                                    imgDisplay.Source = new BitmapImage(new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/6/6b/Hangman-5.png/60px-Hangman-5.png"));
                                    break;
                                case 6:
                                    //Game over
                                    imgDisplay.Source = new BitmapImage(new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/d/d6/Hangman-6.png/60px-Hangman-6.png"));
                                    lblResult.Content = "Failure. The correct answer was " + answer.ToLower() + ".";
                                    lblInstruct1.Content = "";
                                    answer = "";
                                    lblInstruct0.Content = "Choose a difficulty option";
                                    break;
                            }
                        }

                    }
                }
                //If user entered a character other than a proper letter.
                else
                {
                    lblInstruct1.Content = "That is not a valid letter.";
                }

                //Check if there are any underscores left
                bool foundUnderscore = false;
                for (int i = 0; i < tblWordDisplay.Text.Length; i++)
                {
                    char detectUnderscore = tblWordDisplay.Text[i];
                    if (detectUnderscore == '_')
                    {
                        foundUnderscore = true;
                    }
                }
                //If there aren't any underscores: victory
                if (foundUnderscore == false)
                {
                    lblResult.Content = "Congratulations! You won!";
                    lblInstruct1.Content = "";
                    answer = "";
                    lblInstruct0.Content = "";
                }
            }
            //clear txtPlayerInput
            txtPlayerInput.Text = "Choose a difficulty option.";
        }
    }
}