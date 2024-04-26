using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private int subtractionCount = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string buttonContent = button.Content.ToString();

            if (textBox.Text == "0" && buttonContent != ".")
            {
                textBox.Text = buttonContent;
            }
            else
            {
                textBox.Text += buttonContent;
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string operation = button.Content.ToString();

            double currentValue;
            if (double.TryParse(textBox.Text, out currentValue))
            {
                switch (operation)
                {
                    case "+":
                        // Addition
                        textBox.Text = (Convert.ToDouble(textBox.Text) + Convert.ToDouble(resultLabel.Content)).ToString();
                        break;
                    case "-":
                        // Subtraction
                        textBox.Text = (Convert.ToDouble(resultLabel.Content) - Convert.ToDouble(textBox.Text)).ToString();
                        subtractionCount++;
                        break;
                    case "*":
                        // Multiplication
                        textBox.Text = (Convert.ToDouble(textBox.Text) * Convert.ToDouble(resultLabel.Content)).ToString();
                        break;
                    case "/":
                        // Division
                        if (Convert.ToDouble(textBox.Text) != 0)
                        {
                            textBox.Text = (Convert.ToDouble(resultLabel.Content) / Convert.ToDouble(textBox.Text)).ToString();
                        }
                        else
                        {
                            MessageBox.Show("Cannot divide by zero!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;
                    case "1/x":
                        // Inverse
                        textBox.Text = (1 / Convert.ToDouble(textBox.Text)).ToString();
                        break;
                    case "sqrt":
                        // Square root
                        textBox.Text = Math.Sqrt(Convert.ToDouble(textBox.Text)).ToString();
                        break;
                    case "x^n":
                        // Power
                        textBox.Text = Math.Pow(Convert.ToDouble(resultLabel.Content), Convert.ToDouble(textBox.Text)).ToString();
                        break;
                    case "sin":
                        // Sine
                        double angle = AngleFromTextBox();
                        textBox.Text = Math.Sin(angle).ToString();
                        break;
                    case "cos":
                        // Cosine
                        angle = AngleFromTextBox();
                        textBox.Text = Math.Cos(angle).ToString();
                        break;
                    case "tan":
                        // Tangent
                        angle = AngleFromTextBox();
                        textBox.Text = Math.Tan(angle).ToString();
                        break;
                    default:
                        break;
                }
                resultLabel.Content = textBox.Text;
                textBox.Text = "0";
            }
            else
            {
                MessageBox.Show("Invalid input!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private double AngleFromTextBox()
        {
            double angle;
            if (angleTypeComboBox.SelectedIndex == 0) // Degrees
            {
                angle = Convert.ToDouble(textBox.Text) * Math.PI / 180;
            }
            else // Radians
            {
                angle = Convert.ToDouble(textBox.Text);
            }
            return angle;
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show($"Number of subtractions in session: {subtractionCount}", "Session Statistics", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
