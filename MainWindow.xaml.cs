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

namespace _312840DigitalNumbers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool segment1;
        bool segment2;
        bool segment3;
        bool segment4;
        bool segment5;
        bool segment6;
        bool segment7;

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            lblOutput1.Content = "";
            lblOutput2.Content = "";
            lblOutput3.Content = "";
            switch (txtInput.Text)
            {
                case "1":
                    segment1 = false;
                    segment2 = false;
                    segment3 = true;
                    segment4 = false;
                    segment5 = false;
                    segment6 = true;
                    segment7 = false;
                    break;
                case "2":
                    segment1 = true;
                    segment2 = false;
                    segment3 = true;
                    segment4 = true;
                    segment5 = true;
                    segment6 = false;
                    segment7 = true;
                    break;
                case "3":
                    segment1 = true;
                    segment2 = false;
                    segment3 = true;
                    segment4 = true;
                    segment5 = false;
                    segment6 = true;
                    segment7 = true;
                    break;
                case "4":
                    segment1 = false;
                    segment2 = true;
                    segment3 = true;
                    segment4 = true;
                    segment5 = false;
                    segment6 = true;
                    segment7 = false;
                    break;
                case "5":
                    segment1 = true;
                    segment2 = true;
                    segment3 = false;
                    segment4 = true;
                    segment5 = false;
                    segment6 = true;
                    segment7 = true;
                    break;
                case "6":
                    segment1 = true;
                    segment2 = true;
                    segment3 = false;
                    segment4 = true;
                    segment5 = true;
                    segment6 = true;
                    segment7 = true;
                    break;
                case "7":
                    segment1 = true;
                    segment2 = false;
                    segment3 = true;
                    segment4 = false;
                    segment5 = false;
                    segment6 = true;
                    segment7 = false;
                    break;
                case "8":
                    segment1 = true;
                    segment2 = true;
                    segment3 = true;
                    segment4 = true;
                    segment5 = true;
                    segment6 = true;
                    segment7 = true;
                    break;
                case "9":
                    segment1 = true;
                    segment2 = true;
                    segment3 = true;
                    segment4 = true;
                    segment5 = false;
                    segment6 = true;
                    segment7 = true;
                    break;
                case "0":
                    segment1 = true;
                    segment2 = true;
                    segment3 = true;
                    segment4 = false;
                    segment5 = true;
                    segment6 = true;
                    segment7 = true;
                    break;
            }
            if (segment1 == true)
            {
                lblOutput2.Content += " * * * " + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine;
            }
            else
            {
                lblOutput2.Content += Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine;
            }
            if (segment2 == true)
            {
                lblOutput1.Content += Environment.NewLine + "*" + Environment.NewLine + "*" 
                    + Environment.NewLine + "*" + Environment.NewLine;
            }
            else
            {
                lblOutput1.Content += Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine;
            }
            if (segment3 == true)
            {
                lblOutput3.Content += Environment.NewLine + "*" + Environment.NewLine + "*"
                    + Environment.NewLine + "*" + Environment.NewLine;
            }
            else
            {
                lblOutput3.Content += Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine;
            }
            if (segment4 == true)
            {
                lblOutput2.Content += " * * * " + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine;
            }
            else
            {
                lblOutput2.Content += Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine;
            }
            if (segment5 == true)
            {
                lblOutput1.Content += Environment.NewLine + "*" + Environment.NewLine + "*"
                    + Environment.NewLine + "*" + Environment.NewLine;
            }
            else
            {
                lblOutput1.Content += Environment.NewLine + Environment.NewLine;
            }
            if (segment6 == true)
            {
                lblOutput3.Content += Environment.NewLine + "*" + Environment.NewLine + "*"
                    + Environment.NewLine + "*" + Environment.NewLine;
            }
            else
            {
                lblOutput3.Content += Environment.NewLine + Environment.NewLine;
            }
            if (segment7 == true)
            {
                lblOutput2.Content += " * * * ";
            }
        }

    }
}
