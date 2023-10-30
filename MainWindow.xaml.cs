using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace TriangleChecker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckTriangle(object sender, RoutedEventArgs e)
        {
            double side1, side2, side3;
            if (Double.TryParse(side1TextBox.Text, out side1) &&
                Double.TryParse(side2TextBox.Text, out side2) &&
                Double.TryParse(side3TextBox.Text, out side3) &&
                side1 > 0 && side2 > 0 && side3 > 0)
            {
                Triangle triangle = new Triangle(side1, side2, side3);
                SolidColorBrush brush;
                string resultText;

                if (triangle.IsTriangle())
                {
                    brush = Brushes.Green;
                    resultText = $"邊長{side1}, {side2}, {side3}是三角形";
                }
                else
                {
                    brush = Brushes.Red;
                    resultText = $"邊長{side1}, {side2}, {side3}不是三角形";
                }

                resultLabel.Background = brush;
                resultLabel.Content = resultText;
                outputTextBlock.Text += resultText + Environment.NewLine;
            }
            else
            {
                MessageBox.Show("請輸入有效的正數值.");
            }
        }
    }
    public class Triangle
    {
        public double Side1 { get; }
        public double Side2 { get; }
        public double Side3 { get; }
        public Triangle(double side1, double side2, double side3)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }
        public bool IsTriangle()
        {
            return (Side1 + Side2 > Side3) && (Side1 + Side3 > Side2) && (Side2 + Side3 > Side1);
        }
    }
}