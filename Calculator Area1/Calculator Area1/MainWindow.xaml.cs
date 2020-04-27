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


namespace Calculator_Area1
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

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            double a, b, c, d;          
            
                if (figure.SelectedIndex == 0)
                {
                    if (!Radius.Text.Equals(""))
                     { 
                        d = double.Parse(Radius.Text);
                        ResultNumber.Text = arearadius(d).ToString();                    
                     }
                    else
                    {
                        MessageBox.Show("Вы не ввели все необходимые данные!!", "Внимание");
                    }                   
                }
                else if (figure.SelectedIndex == 1)
                {
                     if ((!Side1.Text.Equals("")) || (!Side2.Text.Equals("")) || (!Side3.Text.Equals("")))
                     {
                        a = double.Parse(Side1.Text);
                        b = double.Parse(Side2.Text);
                        c = double.Parse(Side3.Text);
                        ResultNumber.Text = areatriangl(a, b, c).ToString();
                        RecTriangle.IsChecked = recTriangle(a, b, c);
                     }
                     else
                     {
                        MessageBox.Show("Вы не ввели все необходимые данные!!", "Внимание");
                     }
                }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            if (figure.SelectedIndex == 0)
            {
                Radius.Text = null;
            }
            else if (figure.SelectedIndex == 1)
            {
                Side1.Text = null;
                Side2.Text = null;
                Side3.Text = null;
                RecTriangle.IsChecked = false;
            }
            ResultNumber.Text = null;
        }

        private double areatriangl(double a, double b, double c)
        {
            double result;
            double half_per = (a + b + c) / 2;
            result = Math.Sqrt(half_per * (half_per - a) * (half_per - b) * (half_per - c));
            if (double.IsNaN(result))
            {
                result = 0;
            }
            return (result);
        }
        private bool recTriangle(double a, double b, double c)
        {
                return (c == Math.Sqrt(Math.Pow(b, 2) + Math.Pow(a, 2)) ||
                b == Math.Sqrt(Math.Pow(c, 2) + Math.Pow(a, 2)) ||
                a == Math.Sqrt(Math.Pow(b, 2) + Math.Pow(c, 2)));
        }

        private double arearadius(double d)
        {
            return (d * Math.PI);
        }

        private void figure_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (figure.SelectedIndex==0)
            {
                CanRadius.Visibility = Visibility.Visible;
                CanTriangle.Visibility = Visibility.Collapsed;
            }
            else if (figure.SelectedIndex==1)
            {
                CanRadius.Visibility = Visibility.Collapsed;
                CanTriangle.Visibility = Visibility.Visible;
            }            
        }
        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {           
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
