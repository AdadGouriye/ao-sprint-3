using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private void buttonN0_Click(object sender, RoutedEventArgs e)
        {
            if (clearNext) /* This if-statment empties the TextBoxDisplay and TextBoxHistory  */
            {
                TextBoxDisplay.Text = String.Empty;
                TextBoxHistory.Text = String.Empty;
                clearNext = false;
            }

            /*This adds number 0 to the calculator, if there is already 0 nothing happens*/
            if (TextBoxDisplay.Text == "0" && TextBoxDisplay.Text != null)
            {
                TextBoxDisplay.Text = "0";
            }
            else
            {
                TextBoxDisplay.Text = TextBoxDisplay.Text + "0";
            }
        }

        private void buttonN1_Click(object sender, RoutedEventArgs e)
        {
            if (clearNext) /* This if-statment empties the TextBoxDisplay  */
            {
                TextBoxDisplay.Text = String.Empty;
                TextBoxHistory.Text = String.Empty;
                clearNext = false;
            }

            /*This adds number 1 to the calculator, if it is only 0 it will be replaced*/
            if (TextBoxDisplay.Text == "0" && TextBoxDisplay.Text != null)
            {
                TextBoxDisplay.Text = "1";
            }
            else
            {
                TextBoxDisplay.Text = TextBoxDisplay.Text + "1";
            }
        }

        private void buttonN2_Click(object sender, RoutedEventArgs e)
        {
            if (clearNext) /* This if-statment empties the TextBoxDisplay  */
            {
                TextBoxDisplay.Text = String.Empty;
                TextBoxHistory.Text = String.Empty;
                clearNext = false;
            }

            /*This adds number 2 to the calculator, if it is only 0 it will be replaced*/
            if (TextBoxDisplay.Text == "0" && TextBoxDisplay.Text != null)
            {
                TextBoxDisplay.Text = "2";
            }
            else
            {
                TextBoxDisplay.Text = TextBoxDisplay.Text + "2";
            }
        }

        private void buttonN3_Click(object sender, RoutedEventArgs e)
        {
            if (clearNext) /* This if-statment empties the TextBoxDisplay  */
            {
                TextBoxDisplay.Text = String.Empty;
                TextBoxHistory.Text = String.Empty;
                clearNext = false;
            }

            /*This adds number 3 to the calculator, if it is only 0 it will be replaced*/
            if (TextBoxDisplay.Text == "0" && TextBoxDisplay.Text != null)
            {
                TextBoxDisplay.Text = "3";
            }
            else
            {
                TextBoxDisplay.Text = TextBoxDisplay.Text + "3";
            }
        }

        private void buttonN4_Click(object sender, RoutedEventArgs e)
        {
            if (clearNext) /* This if-statment empties the TextBoxDisplay  */
            {
                TextBoxDisplay.Text = String.Empty;
                TextBoxHistory.Text = String.Empty;
                clearNext = false;
            }

            /*This adds number 4 to the calculator, if it is only 0 it will be replaced*/
            if (TextBoxDisplay.Text == "0" && TextBoxDisplay.Text != null)
            {
                TextBoxDisplay.Text = "4";
            }
            else
            {
                TextBoxDisplay.Text = TextBoxDisplay.Text + "4";
            }
        }

        private void buttonN5_Click(object sender, RoutedEventArgs e)
        {
            if (clearNext) /* This if-statment empties the TextBoxDisplay  */
            {
                TextBoxDisplay.Text = String.Empty;
                TextBoxHistory.Text = String.Empty;
                clearNext = false;
            }

            /*This adds number 5 to the calculator, if it is only 0 it will be replaced*/
            if (TextBoxDisplay.Text == "0" && TextBoxDisplay.Text != null)
            {
                TextBoxDisplay.Text = "5";
            }
            else
            {
                TextBoxDisplay.Text = TextBoxDisplay.Text + "5";
            }
        }

        private void buttonN6_Click(object sender, RoutedEventArgs e)
        {
            if (clearNext) /* This if-statment empties the TextBoxDisplay  */
            {
                TextBoxDisplay.Text = String.Empty;
                TextBoxHistory.Text = String.Empty;
                clearNext = false;
            }

            /*This adds number 6 to the calculator, if it is only 0 it will be replaced*/
            if (TextBoxDisplay.Text == "0" && TextBoxDisplay.Text != null)
            {
                TextBoxDisplay.Text = "6";
            }
            else
            {
                TextBoxDisplay.Text = TextBoxDisplay.Text + "6";
            }
        }

        private void buttonN7_Click(object sender, RoutedEventArgs e)
        {
            if (clearNext) /* This if-statment empties the TextBoxDisplay  */
            {
                TextBoxDisplay.Text = String.Empty;
                TextBoxHistory.Text = String.Empty;
                clearNext = false;
            }

            /*This adds number 7 to the calculator, if it is only 0 it will be replaced*/
            if (TextBoxDisplay.Text == "0" && TextBoxDisplay.Text != null)
            {
                TextBoxDisplay.Text = "7";
            }
            else
            {
                TextBoxDisplay.Text = TextBoxDisplay.Text + "7";
            }
        }

        private void buttonN8_Click(object sender, RoutedEventArgs e)
        {
            if (clearNext) /* This if-statment empties the TextBoxDisplay  */
            {
                TextBoxDisplay.Text = String.Empty;
                TextBoxHistory.Text = String.Empty;
                clearNext = false;
            }

            /*This adds number 8 to the calculator, if it is only 0 it will be replaced*/
            if (TextBoxDisplay.Text == "0" && TextBoxDisplay.Text != null)
            {
                TextBoxDisplay.Text = "8";
            }
            else
            {
                TextBoxDisplay.Text = TextBoxDisplay.Text + "8";
            }
        }

        private void buttonN9_Click(object sender, RoutedEventArgs e)
        {
            if (clearNext) /* This if-statment empties the TextBoxDisplay  */
            {
                TextBoxDisplay.Text = String.Empty;
                TextBoxHistory.Text = String.Empty;
                clearNext = false;
            }

            /*This adds number 9 to the calculator, if it is only 0 it will be replaced*/
            if (TextBoxDisplay.Text == "0" && TextBoxDisplay.Text != null)
            {
                TextBoxDisplay.Text = "9";
            }
            else
            {
                TextBoxDisplay.Text = TextBoxDisplay.Text + "9";
            }
        }

        private void buttonDecimal_Click(object sender, RoutedEventArgs e)
        {
            if (comma == false)
            {
                if (clearNext)
                {
                    TextBoxDisplay.Text = "0";
                    TextBoxHistory.Text = String.Empty;
                    clearNext = false;
                }
                TextBoxDisplay.Text = TextBoxDisplay.Text + ".";
                comma = true;
            }
        }
    }
}