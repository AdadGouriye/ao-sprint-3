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

        /* ----------------------------------------------------------- /
        / ---------- Start of adding functional operations ----------- /
        / ---------- Add, subtract, dividing, multiply and Modulo ---- /
        / ----------------------------------------------------------- */
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!clearNext)
            {
                numbers.Add(Convert.ToDouble(TextBoxDisplay.Text));
                operations.Add("+");
                TextBoxHistory.Text += TextBoxDisplay.Text + " + ";
                TextBoxDisplay.Text = "0";
                comma = false;
            }
        }

        private void buttonSubstract_Click(object sender, RoutedEventArgs e)
        {
            if (!clearNext)
            {
                numbers.Add(Convert.ToDouble(TextBoxDisplay.Text));
                operations.Add("-");
                TextBoxHistory.Text += TextBoxDisplay.Text + " - ";
                TextBoxDisplay.Text = "0";
                comma = false;
            }
        }

        private void buttonMultiply_Click(object sender, RoutedEventArgs e)
        {
            if (!clearNext)
            {
                numbers.Add(Convert.ToDouble(TextBoxDisplay.Text));
                operations.Add("*");
                TextBoxHistory.Text += TextBoxDisplay.Text + " * ";
                TextBoxDisplay.Text = "0";
                comma = false;
            }
        }

        private void buttonDivide_Click(object sender, RoutedEventArgs e)
        {
            if (!clearNext)
            {
                numbers.Add(Convert.ToDouble(TextBoxDisplay.Text));
                operations.Add("/");
                TextBoxHistory.Text += TextBoxDisplay.Text + " / ";
                TextBoxDisplay.Text = "0";
                comma = false;
            }
        }

        private void buttonMod_Click(object sender, RoutedEventArgs e)
        {
            if (!clearNext)
            {
                numbers.Add(Convert.ToDouble(TextBoxDisplay.Text));
                operations.Add("%");
                TextBoxHistory.Text += TextBoxDisplay.Text + " % ";
                TextBoxDisplay.Text = "0";
                comma = false;
            }
        }

        /* ----------------------------------------------------------- /
        / ---------------------- Button result "=" ------------------- /
        / ----------------------------------------------------------- */
        private void buttonResult_Click(object sender, RoutedEventArgs e)
        {
            if (!clearNext)
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
                            Divide();
                        else
                            Multiply();
                    }
                    if (operations.Contains("*"))
                    {
                        Multiply();
                    }
                    if (operations.Contains("/"))
                    {
                        Divide();
                    }
                }
                while (operations.Contains("+") || operations.Contains("-"))
                {
                    if (operations.Contains("+") && operations.Contains("-"))
                    {
                        var indexplus = operations.IndexOf("+");
                        var indexmin = operations.IndexOf("-");
                        if (indexmin < indexplus)
                            Substract();
                        else
                            Sum();
                    }
                    if (operations.Contains("+"))
                    {
                        Sum();
                    }
                    if (operations.Contains("-"))
                    {
                        Substract();
                    }
                }


                TextBoxDisplay.Text = Convert.ToString(numbers[0]);
                numbers.RemoveAt(index);
            }

        }
        /* These are the functions we use to Multiplt, Divide, Sum, Substract and Modulo */
        /* The numbers that are stored in the List       */
        private void Multiply()
        {
            var index = operations.IndexOf("*");
            numbers[index] = numbers[index] * numbers[index + 1];
            operations.RemoveAt(index);
            numbers.RemoveAt(index + 1);
        }
        private void Divide()
        {
            var index = operations.IndexOf("/");
            numbers[index] = numbers[index] / numbers[index + 1];
            operations.RemoveAt(index);
            numbers.RemoveAt(index + 1);
        }
        private void Sum()
        {
            var index = operations.IndexOf("+");
            numbers[index] = numbers[index] + numbers[index + 1];
            operations.RemoveAt(index);
            numbers.RemoveAt(index + 1);
        }
        private void Substract()
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
    }
}