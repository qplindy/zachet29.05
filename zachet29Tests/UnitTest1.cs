using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using zachet29._05; // замени на namespace основного проекта
using zachet29._05;

namespace zachet29Tests
{
    [TestClass]
    public class TipCalculatorLogicTests
    {
        // ─── CalculateTip ───────────────────────────────────────────────

        [TestMethod]
        public void CalculateTip_NoTip_ReturnsZero()
        {
            double result = TipCalculatorLogic.CalculateTip(1000, 0);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CalculateTip_5Percent_ReturnsCorrect()
        {
            double result = TipCalculatorLogic.CalculateTip(1000, 5);
            Assert.AreEqual(50, result, 0.01);
        }

        [TestMethod]
        public void CalculateTip_10Percent_ReturnsCorrect()
        {
            double result = TipCalculatorLogic.CalculateTip(200, 10);
            Assert.AreEqual(20, result, 0.01);
        }

        [TestMethod]
        public void CalculateTip_15Percent_ReturnsCorrect()
        {
            double result = TipCalculatorLogic.CalculateTip(200, 15);
            Assert.AreEqual(30, result, 0.01);
        }

        [TestMethod] // граничное значение: счёт = 0
        public void CalculateTip_ZeroBill_ReturnsZero()
        {
            double result = TipCalculatorLogic.CalculateTip(0, 15);
            Assert.AreEqual(0, result);
        }

        [TestMethod] // некорректные данные
        public void CalculateTip_NegativeBill_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                TipCalculatorLogic.CalculateTip(-100, 10));
        }

        [TestMethod]
        public void CalculateTip_NegativePercent_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                TipCalculatorLogic.CalculateTip(100, -5));
        }

        // ─── CalculateTotal ─────────────────────────────────────────────

        [TestMethod]
        public void CalculateTotal_NoTip_EqualsBill()
        {
            double result = TipCalculatorLogic.CalculateTotal(500, 0);
            Assert.AreEqual(500, result, 0.01);
        }

        [TestMethod]
        public void CalculateTotal_10Percent_ReturnsCorrect()
        {
            double result = TipCalculatorLogic.CalculateTotal(1000, 10);
            Assert.AreEqual(1100, result, 0.01);
        }

        [TestMethod]
        public void CalculateTotal_15Percent_ReturnsCorrect()
        {
            double result = TipCalculatorLogic.CalculateTotal(200, 15);
            Assert.AreEqual(230, result, 0.01);
        }

        [TestMethod]
        public void CalculateTotal_WithTip_IsGreaterThanBill()
        {
            double total = TipCalculatorLogic.CalculateTotal(100, 10);
            Assert.IsTrue(total > 100);
        }

        [TestMethod]
        public void CalculateTotal_WithoutTip_IsNotGreaterThanBill()
        {
            double total = TipCalculatorLogic.CalculateTotal(100, 0);
            Assert.IsFalse(total > 100);
        }

        [TestMethod]
        public void CalculateTotal_NegativeBill_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                TipCalculatorLogic.CalculateTotal(-50, 10));
        }

        // ─── CalculatePerPerson ─────────────────────────────────────────

        [TestMethod]
        public void CalculatePerPerson_OneGuest_ReturnsTotal()
        {
            double result = TipCalculatorLogic.CalculatePerPerson(1000, 1);
            Assert.AreEqual(1000, result, 0.01);
        }

        [TestMethod]
        public void CalculatePerPerson_TwoGuests_ReturnsHalf()
        {
            double result = TipCalculatorLogic.CalculatePerPerson(1000, 2);
            Assert.AreEqual(500, result, 0.01);
        }

        [TestMethod]
        public void CalculatePerPerson_FourGuests_ReturnsQuarter()
        {
            double result = TipCalculatorLogic.CalculatePerPerson(1000, 4);
            Assert.AreEqual(250, result, 0.01);
        }

        [TestMethod] // граничное значение: сумма = 0
        public void CalculatePerPerson_ZeroTotal_ReturnsZero()
        {
            double result = TipCalculatorLogic.CalculatePerPerson(0, 3);
            Assert.AreEqual(0, result, 0.01);
        }

        [TestMethod]
        public void CalculatePerPerson_DifferentGuestsDifferentResult()
        {
            double r1 = TipCalculatorLogic.CalculatePerPerson(1000, 2);
            double r2 = TipCalculatorLogic.CalculatePerPerson(1000, 3);
            Assert.AreNotEqual(r1, r2);
        }

        [TestMethod] // некорректные данные
        public void CalculatePerPerson_ZeroGuests_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                TipCalculatorLogic.CalculatePerPerson(1000, 0));
        }

        [TestMethod]
        public void CalculatePerPerson_NegativeGuests_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                TipCalculatorLogic.CalculatePerPerson(1000, -1));
        }

        [TestMethod]
        public void CalculatePerPerson_NegativeTotal_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                TipCalculatorLogic.CalculatePerPerson(-100, 2));
        }
    }
}