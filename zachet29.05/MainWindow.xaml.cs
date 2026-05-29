using System;
using System.Windows;
using zachet29._05;

namespace zachet29._05
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml (Code-Behind).
    /// Валидация ввода и вызов методов класса TipCalculatorLogic.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия кнопки «Рассчитать».
        /// Считывает данные из полей, валидирует их и выводит результат.
        /// </summary>
        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            // Валидация суммы счёта
            if (!double.TryParse(textBoxBill.Text, out double bill))
            {
                MessageBox.Show("Введите корректную сумму счёта (например: 1500 или 1500,50).",
                                "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Валидация количества гостей
            if (!int.TryParse(textBoxGuests.Text, out int guests))
            {
                MessageBox.Show("Введите корректное количество гостей (целое число, например: 3).",
                                "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Определяем выбранный процент чаевых по RadioButton
            double tipPercent = 0;
            if (radio5.IsChecked == true) tipPercent = 5;
            else if (radio10.IsChecked == true) tipPercent = 10;
            else if (radio15.IsChecked == true) tipPercent = 15;

            try
            {
                double tip = TipCalculatorLogic.CalculateTip(bill, tipPercent);
                double total = TipCalculatorLogic.CalculateTotal(bill, tipPercent);

                string result = $"Сумма счёта:      {bill:F2} руб.\n" +
                                $"Чаевые ({tipPercent,2}%):   {tip:F2} руб.\n" +
                                $"Итого:            {total:F2} руб.";

                // Если гостей больше одного — показываем сумму на каждого
                if (guests > 1)
                {
                    double perPerson = TipCalculatorLogic.CalculatePerPerson(total, guests);
                    result += $"\nС каждого ({guests} чел.): {perPerson:F2} руб.";
                }

                textBlockResult.Text = result;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка расчёта",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}