using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private double firstValue = 0;
        private double secondValue = 0;
        private string currentOperation = "";
        private bool firstTime = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string? buttonContent = button.Content.ToString();

            if (currentOperation == "")
            {
                
                if (textBox.Text == "0" && buttonContent != ".")
                {
                    textBox.Text = buttonContent;
                }
                else
                {
                    textBox.Text += buttonContent;
                }
                
                firstValue = Convert.ToDouble(textBox.Text);
         
            }
            else
            {
                if (firstTime)
                {
                    textBox.Text = "0";
                    firstTime = false;
                }
                if (textBox.Text == "0" && buttonContent != ".")
                {
                    textBox.Text = buttonContent;
                }
                else
                {
                    textBox.Text += buttonContent;
                }

                secondValue = Convert.ToDouble(textBox.Text);
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string? currentValue = button.Content.ToString();
            if (currentValue != "=")
            {
                currentOperation = currentValue;
            }
            else
            {
                if ((firstValue == 0 || secondValue == 0) && currentOperation == "/")
                {
                    MessageBox.Show("Wrong input!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    double result = CalculateResult(firstValue, secondValue, currentOperation);

                    textBox.Text = "0";
                    resultLabel.Content = result;
                }
                currentOperation = "";
                firstValue = 0;
                secondValue = 0;
                firstTime = true;
            }
        }
            private double AngleFromTextBox()
        {
            double angle;
            if (angleTypeComboBox.SelectedIndex == 0)
            {
                angle = Convert.ToDouble(textBox.Text) * Math.PI / 180;
            }
            else // Radians
            {
                angle = Convert.ToDouble(textBox.Text);
            }
            return angle;
        }

        private double CalculateResult(double firstOperand, double secondOperand, string operation)
        {
            switch (operation)
            {
                case "+":
                    return firstOperand + secondOperand;
                case "-":
                    return firstOperand - secondOperand;
                case "*":
                    return firstOperand * secondOperand;
                case "/":
                    return firstOperand / secondOperand;
                default:
                    MessageBox.Show("Operation not recognized!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return double.NaN; // Not a Number when operation is invalid
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "0";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D0:
                case Key.NumPad0:
                    NumberButton_Click(button0, null);
                    break;
                case Key.D1:
                case Key.NumPad1:
                    NumberButton_Click(button1, null);
                    break;
                case Key.D2:
                case Key.NumPad2:
                    NumberButton_Click(button2, null);
                    break;
                case Key.D3:
                case Key.NumPad3:
                    NumberButton_Click(button3, null);
                    break;
                case Key.D4:
                case Key.NumPad4:
                    NumberButton_Click(button4, null);
                    break;
                case Key.D5:
                case Key.NumPad5:
                    NumberButton_Click(button5, null);
                    break;
                case Key.D6:
                case Key.NumPad6:
                    NumberButton_Click(button6, null);
                    break;
                case Key.D7:
                case Key.NumPad7:
                    NumberButton_Click(button7, null);
                    break;
                case Key.D8:
                case Key.NumPad8:
                    NumberButton_Click(button8, null);
                    break;
                case Key.D9:
                case Key.NumPad9:
                    NumberButton_Click(button9, null);
                    break;
                case Key.OemPeriod:
                case Key.Decimal:
                    NumberButton_Click(buttonDot, null);
                    break;
                case Key.Add:
                    OperationButton_Click(buttonAdd, null);
                    break;
                case Key.Subtract:
                    OperationButton_Click(buttonSubtract, null);
                    break;
                case Key.Multiply:
                    OperationButton_Click(buttonMultiply, null);
                    break;
                case Key.Divide:
                    OperationButton_Click(buttonDivide, null);
                    break;
                case Key.Enter:
                    OperationButton_Click(buttonEquals, null);
                    break;
                default:
                    break;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }
    }
}
