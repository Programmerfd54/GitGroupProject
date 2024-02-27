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

namespace GitOurProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentOperation = ""; // Текущая операция
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation();
        }
        double result = 0;
        private void PerformOperation()
        {
            // Проверяем наличие чисел и выбранной операции
            if (string.IsNullOrWhiteSpace(currentOperation))
            {
                MessageBox.Show("Выберите операцию!");
                return;
            }

            if (string.IsNullOrWhiteSpace(log.Text) || string.IsNullOrWhiteSpace(log2.Text))
            {
                MessageBox.Show("Введите числа!");
                return;
            }


            // Парсинг чисел из текстовых полей
            if (double.TryParse(log.Text, out double num1) && double.TryParse(log2.Text, out double num2))
            {


                // Выполнение операции в соответствии с текущей выбранной операцией
                switch (currentOperation)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 != 0)
                            result = num1 / num2;
                        else
                        {
                            MessageBox.Show("Деление на ноль невозможно!");
                            return;
                        }
                        break;
                    case "√":
                        if (num2 >= 0)
                            result = Math.Sqrt(num2);
                        else
                        {
                            MessageBox.Show("Извлечение корня из отрицательного числа невозможно!");
                            return;
                        }
                        break;
                    default:
                        MessageBox.Show("Выберите операцию!");
                        return;
                }
            }
            else
            {
                MessageBox.Show("Введите корректные числа!");
            }
        }
    }
}
