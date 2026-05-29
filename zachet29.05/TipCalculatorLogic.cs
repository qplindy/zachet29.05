using System;

namespace zachet29._05
{
    /// <summary>
    /// Статический класс с логикой расчёта чаевых.
    /// Все методы принимают простые типы и бросают ArgumentException при некорректных данных.
    /// </summary>
    public static class TipCalculatorLogic
    {
        /// <summary>
        /// Вычисляет сумму чаевых.
        /// </summary>
        /// <param name="billAmount">Сумма счёта (не может быть отрицательной).</param>
        /// <param name="tipPercent">Процент чаевых (0, 5, 10 или 15).</param>
        /// <returns>Сумма чаевых в рублях.</returns>
        /// <exception cref="ArgumentException">Если billAmount или tipPercent < 0.</exception>
        public static double CalculateTip(double billAmount, double tipPercent)
        {
            if (billAmount < 0)
                throw new ArgumentException("Сумма счёта не может быть отрицательной.");
            if (tipPercent < 0)
                throw new ArgumentException("Процент чаевых не может быть отрицательным.");

            return billAmount * tipPercent / 100.0;
        }

        /// <summary>
        /// Вычисляет итоговую сумму (счёт + чаевые).
        /// </summary>
        /// <param name="billAmount">Сумма счёта (не может быть отрицательной).</param>
        /// <param name="tipPercent">Процент чаевых.</param>
        /// <returns>Итоговая сумма.</returns>
        /// <exception cref="ArgumentException">Если billAmount или tipPercent < 0.</exception>
        public static double CalculateTotal(double billAmount, double tipPercent)
        {
            if (billAmount < 0)
                throw new ArgumentException("Сумма счёта не может быть отрицательной.");
            if (tipPercent < 0)
                throw new ArgumentException("Процент чаевых не может быть отрицательным.");

            return billAmount + CalculateTip(billAmount, tipPercent);
        }

        /// <summary>
        /// Вычисляет сумму к оплате на одного гостя.
        /// </summary>
        /// <param name="totalAmount">Итоговая сумма (не может быть отрицательной).</param>
        /// <param name="guests">Количество гостей (должно быть больше нуля).</param>
        /// <returns>Сумма на одного человека.</returns>
        /// <exception cref="ArgumentException">Если guests ≤ 0 или totalAmount < 0.</exception>
        public static double CalculatePerPerson(double totalAmount, int guests)
        {
            if (totalAmount < 0)
                throw new ArgumentException("Итоговая сумма не может быть отрицательной.");
            if (guests <= 0)
                throw new ArgumentException("Количество гостей должно быть больше нуля.");

            return totalAmount / guests;
        }
    }
}