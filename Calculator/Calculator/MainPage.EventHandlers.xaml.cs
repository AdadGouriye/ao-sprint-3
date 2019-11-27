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

        private void buttonCE_Click(object sender, RoutedEventArgs e)
        {
            TextBoxDisplay.Text = "0";
            comma = false;
        }

        private void buttonC_Click(object sender, RoutedEventArgs e)
        {
            firstNumber = 0;
            TextBoxDisplay.Text = "0";
            TextBoxHistory.Text = String.Empty;
            comma = false;
        }

        private void buttonBackspace_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxDisplay.Text.EndsWith(","))
            {
                comma = false;
            }
            TextBoxDisplay.Text = TextBoxDisplay.Text.Remove(TextBoxDisplay.Text.Length - 1);
            if (TextBoxDisplay.Text.Length == 0)
            {
                TextBoxDisplay.Text = "0";
            }
        }
    }
}