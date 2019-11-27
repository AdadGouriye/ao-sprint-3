﻿using System;
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
        double firstNumber; /*    */
        string operation;
        bool clearNext = false; /* This is a check to see if the Bin/Hex functions has been used */
        bool comma = false; /* This is to check if a comma has been used or not */
        List<double> numbers = new List<double>();
        List<string> operations = new List<string>();
        

        public MainPage()
        {
            this.InitializeComponent();
        }

       

        /* ----------------------------------------------------------- /
        / ---------------------- Button result "=" ------------------- /
        / ----------------------------------------------------------- */
        private void buttonResult_Click(object sender, RoutedEventArgs e)
        {

            TextBoxHistory.Text += TextBoxDisplay.Text + " =";
            numbers.Add(Convert.ToDouble(TextBoxDisplay.Text));
            int index = 0;

            while (operations.Contains("%"))
            {
                Modulo();
            }
            while (operations.Contains("*") || operations.Contains("/"))
            {
                if (operations.Contains("*") && operations.Contains("/"))
                {
                    var indexmaal = operations.IndexOf("*");
                    var indexdeel = operations.IndexOf("/");
                    if (indexdeel < indexmaal)
                        Deel();
                    else
                        Maal();
                }
                if (operations.Contains("*")) {
                    Maal();
                }
                if (operations.Contains("/")) {
                    Deel();
                }
            }
            while (operations.Contains("+") || operations.Contains("-"))
            {
                if (operations.Contains("+") && operations.Contains("-"))
                {
                    var indexplus = operations.IndexOf("+");
                    var indexmin = operations.IndexOf("-");
                    if (indexmin < indexplus)
                        Min();
                    else
                        Plus();
                }
                if (operations.Contains("+"))
                {
                    Plus();
                }
                if (operations.Contains("-"))
                {
                    Min();
                }
            }
            

            TextBoxDisplay.Text = Convert.ToString(numbers[0]);
            numbers.RemoveAt(index);
            


            /*double secondNumber;
            double result;

            secondNumber = Convert.ToDouble(TextBoxDisplay.Text);

            if (operation == "+")
            {
                result = (firstNumber + secondNumber);
                TextBoxDisplay.Text = Convert.ToString(result);
                firstNumber = result;
            }
            else if (operation == "-")
            {
                result = (firstNumber - secondNumber);
                TextBoxDisplay.Text = Convert.ToString(result);
                firstNumber = result;
            }
            else if (operation == "*")
            {
                result = (firstNumber * secondNumber);
                TextBoxDisplay.Text = Convert.ToString(result);
                firstNumber = result;
            }
            else if (operation == "/")
            {
                if (secondNumber == 0)
                {
                    TextBoxDisplay.Text = "Syntax Error";
                    clearNext = true;
                }
                else
                {
                    result = (firstNumber / secondNumber);
                    TextBoxDisplay.Text = Convert.ToString(result);
                    firstNumber = result;
                }
            }
            else if (operation == "%") //Modulo function
            {
                if (secondNumber == 0)
                {
                    TextBoxDisplay.Text = "Syntax Error";
                    clearNext = true;
                }
                else
                {
                    result = (firstNumber % secondNumber);
                    TextBoxDisplay.Text = Convert.ToString(result);
                    firstNumber = result;
                }
            }
            TextBoxHistory.Text = TextBoxHistory.Text + " " + secondNumber + " " + "=";
            operation = null;*/
        }
        private void Maal()
        {
            var index = operations.IndexOf("*");
            numbers[index] = numbers[index] * numbers[index + 1];
            operations.RemoveAt(index);
            numbers.RemoveAt(index + 1);
        }
        private void Deel()
        {
            var index = operations.IndexOf("/");
            numbers[index] = numbers[index] / numbers[index + 1];
            operations.RemoveAt(index);
            numbers.RemoveAt(index + 1);
        }
        private void Plus()
        {
            var index = operations.IndexOf("+");
            numbers[index] = numbers[index] + numbers[index + 1];
            operations.RemoveAt(index);
            numbers.RemoveAt(index + 1);
        }
        private void Min()
        {
            var index = operations.IndexOf("-");
            numbers[index] = numbers[index] - numbers[index + 1];
            operations.RemoveAt(index);
            numbers.RemoveAt(index + 1);
        }
        private void Modulo() 
        {
            var index = operations.IndexOf("%");
            numbers[index] = numbers[index] % numbers[index + 1];
            operations.RemoveAt(index);
            numbers.RemoveAt(index + 1);
        }
        /* ------------------------------------------------------------------ /
        / ---------------- Dollars to Euro's function "$ → €" --------------- /
        / ------------------------------------------------------------------ */
        private void buttonDoll2Euro_Click(object sender, RoutedEventArgs e)
        {
            firstNumber = Convert.ToDouble(TextBoxDisplay.Text);
            firstNumber /= 1.1016;
            TextBoxDisplay.Text = Convert.ToString(firstNumber);
        }

        /* ------------------------------------------------------------------ /
        / ---------------- Euro's to Dollars function "€ → $" --------------- /
        / ------------------------------------------------------------------ */
        private void buttonEuro2Doll_Click(object sender, RoutedEventArgs e)
        {
            firstNumber = Convert.ToDouble(TextBoxDisplay.Text);
            firstNumber *= 1.1016;
            TextBoxDisplay.Text = Convert.ToString(firstNumber);
        }

        /* ---------------------------------------------------------- /
        / ------------------- BIN function "BIN" -------------------- /
        / ---------------------------------------------------------- */
        private void buttonBin_Click(object sender, RoutedEventArgs e)
        {
            if (!clearNext)
            {
                /* Here are all the variables that we are going to need to use */
                int i, n;
                int[] a = new int[10];
                string finalResult = "";
                clearNext = true;

                if (TextBoxDisplay.Text.Contains(","))
                {
                    TextBoxDisplay.Text = ("Syntax Error");
                }
                else
                {
                    n = Convert.ToInt32(TextBoxDisplay.Text);
                    TextBoxHistory.Text = n + " =";

                    if (n < 0)
                    {
                        n *= -1;
                    }

                    /* This for-loop divides the number in the TextBoxDisplay to check how long the binary number is and to check where there has to be a '1' or a '0'*/
                    for (i = 0; n > 0; i++)
                    {
                        a[i] = n % 2;
                        n /= 2;
                    }

                    /* This for-loop grabs the data from the array and stores it in the String 'finalResult' */
                    for (i -= 1; i >= 0; i--)
                    {
                        finalResult += "" + a[i];

                    }

                    TextBoxDisplay.Text = finalResult;

                }
            }
        }

        /* ------------------------------------------------------------ /
        / ---------------- Hexadecimal function "HEX" ----------------- /
        / ------------------------------------------------------------ */
        private void buttonHex_Click(object sender, RoutedEventArgs e)
        {
            if(!clearNext)
            {
                clearNext = true;
                if (TextBoxDisplay.Text.Contains(","))
                {
                    TextBoxDisplay.Text = ("Syntax Error");
                }
                else
                {
                    int index = Convert.ToInt32(TextBoxDisplay.Text);

                    if (index < 0)
                    {
                        index *= -1;
                    }

                    int result = index / 16;
                    int rest = index % 16;
                    String finalResult = "" + result;


                    /* These if statements check if we have to add a letter to the hexadecimal number or not. */
                    if (rest == 15)
                    {
                        finalResult += "F";
                    }
                    else if (rest == 14)
                    {
                        finalResult += "E";
                    }
                    else if (rest == 13)
                    {
                        finalResult += "D";
                    }
                    else if (rest == 12)
                    {
                        finalResult += "C";
                    }
                    else if (rest == 11)
                    {
                        finalResult += "B";
                    }
                    else if (rest == 10)
                    {
                        finalResult += "A";
                    }
                    else
                    {
                        finalResult += "" + rest;
                    }

                    TextBoxDisplay.Text = finalResult;
                    TextBoxHistory.Text = index + " =";
                }
            }
        }

        /* ------------------------------------------------------------------ /
        / ---------------- Negate function "+ → -" -------------------------- /
        / ------------------------------------------------------------------ */
        private void buttonNegate_Click(object sender, RoutedEventArgs e)
        {
            double index = Convert.ToDouble(TextBoxDisplay.Text);
            index *= -1;
            TextBoxDisplay.Text = Convert.ToString(index);
        }
    }
}