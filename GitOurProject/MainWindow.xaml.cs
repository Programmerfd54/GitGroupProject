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
            // Добавляем обработчики событий изменения текста в текстовых полях
          
        }

         private double num1 = 0; // Первое число
         private double num2 = 0; // Второе число

        private void ravno_Click(object sender, RoutedEventArgs e)
        {
            // Вывод результата
            Itog.Text = result.ToString();
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation();
        }
        double result = 0;

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            currentOperation = button.Content.ToString(); // Обновляем текущую операцию
            PerformOperation(); // Выполнить операцию при нажатии на кнопку операции
        }
        private void PerformOperation()
        {
           if (string.IsNullOrWhiteSpace(currentOperation))
            {
                ShowError("Выберите операцию!");
                return;
            }
            
            if (string.IsNullOrWhiteSpace(log.Text) || string.IsNullOrWhiteSpace(log2.Text))
            {
                ShowError("Введите числа!");
                return;
            }
            
            // Парсинг чисел из текстовых полей
            if (!double.TryParse(log.Text, out num1) || !double.TryParse(log2.Text, out num2))
            {
                ShowError("Введите корректные числа!");
                return;
            }
            
            double result = 0;


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

        // Обработчик события изменения текста в текстовых полях
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PerformOperation(); // Выполняем операцию при изменении текста
        }
          private void ShowError(string message, TextBox textBox = null)
              {
                  MessageBox.Show(message);
                  textBox?.Focus();
              }

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    e.Handled = true; // Отклоняем ввод, если символ не цифра и не точка
                    break;
                }
            }
        }


    }
}
