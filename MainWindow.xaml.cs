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
        string[] easy = new string[10];
        string[] medium = new string[10];
        string[] hard = new string[10];
        string answer;
        char userInput;
        bool foundLetter = false;
        int fails;

        public MainWindow()
        {
            InitializeComponent();
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
        }

        
        
        

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            tblWordDisplay.Text = "";
            Random rnd = new Random();
            int x = rnd.Next(10);
            if ((bool)rbEasy.IsChecked)
            {
                //answer = easy[x];
                answer = "DOG";
            }
            if ((bool)rbMedium.IsChecked)
            {
                answer = medium[x];
            }
            if ((bool)rbHard.IsChecked)
            {
                answer = hard[x];
            }
            for (int i = 0; i < answer.Length; i++)
            {
                tblWordDisplay.Text += "_ ";
            }
        }

        private void btnCheckLetter_Click(object sender, RoutedEventArgs e)
        {
            userInput = txtPlayerInput.Text.ToUpper()[0];
            tblUsedLetters.Text += userInput + " ";
            for (int i = 0; i < answer.Length; i++)
            {
                char readAnswer = answer[i];
                if (readAnswer == userInput)
                {
                    tblWordDisplay.Text =tblWordDisplay.Text.Remove(i * 2, 1);
                    tblWordDisplay.Text = tblWordDisplay.Text.Insert(i * 2, userInput.ToString());
                    foundLetter = true;
                }
            }
            if (foundLetter == false)
            {
                fails++;
                switch (fails)
                {
                    case 1:

                }
            }
        }
    }
}
