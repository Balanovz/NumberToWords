using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToWords;
using System;

namespace TestNumberToWords.UnitTests
{
    [TestClass]
    public class TransferTests
    {
        [TestMethod]
        public void ToRubles_19_53_ReturnTrue()
        {
            string rublesInWords = Transfer.ToRubles(19.53);

            Assert.AreEqual(rublesInWords, "девятнадцать рублей, пятьдесят три копейки");
        }

        [TestMethod]
        public void ToRubles_0_ReturnTrue()
        {
            string rublesInWords = Transfer.ToRubles(0);

            Assert.AreEqual("ноль рублей, ноль копеек", rublesInWords);
        }

        [TestMethod]
        public void ToRubles_17_ReturnTrue()
        {
            string rublesInWords = Transfer.ToRubles(17);

            Assert.AreEqual("семнадцать рублей, ноль копеек", rublesInWords);
        }

        [TestMethod]
        public void ToRubles_9999999999_ReturnTrue()
        {
            string rublesInWords = Transfer.ToRubles(9999999999);

            Assert.AreEqual("девять миллиардов девятьсот девяносто девять миллионов девятьсот девяносто девять тысяч девятьсот девяносто девять рублей, ноль копеек", rublesInWords);
        }

        [TestMethod]
        public void ToDollars_9999999999_ReturnTrue()
        {
            string dollarsInWords = Transfer.ToDollars(9999999999);

            Assert.AreEqual("девять миллиардов девятьсот девяносто девять миллионов девятьсот девяносто девять тысяч девятьсот девяносто девять долларов, ноль центов", dollarsInWords);
        }

        [TestMethod]
        public void ToEuro_9999999999_ReturnTrue()
        {
            string euroInWords = Transfer.ToEuro(9999999999);

            Assert.AreEqual("девять миллиардов девятьсот девяносто девять миллионов девятьсот девяносто девять тысяч девятьсот девяносто девять евро, ноль евроцентов", euroInWords);
        }

        [TestMethod]
        public void ToYuan_9999999999_ReturnTrue()
        {
            string yuanInWords = Transfer.ToYuan(9999999999);

            Assert.AreEqual("девять миллиардов девятьсот девяносто девять миллионов девятьсот девяносто девять тысяч девятьсот девяносто девять юаней, ноль фэней", yuanInWords);
        }

        [TestMethod]
        public void ToRubles_82043054_51_ReturnTrue()
        {
            string rublesInWords = Transfer.ToRubles(82043054.51);

            Assert.AreEqual("восемьдесят два миллиона сорок три тысячи пятьдесят четыре рубля, пятьдесят одна копейка", rublesInWords);
        }

        [TestMethod]
        public void ToRubles_1_3_ReturnTrue()
        {
            string rublesInWords = Transfer.ToRubles(1.03);

            Assert.AreEqual("один рубль, три копейки", rublesInWords);
        }

        [TestMethod]
        public void ToRubles_5_3_ReturnTrue()
        {
            string rublesInWords = Transfer.ToRubles(5.3);

            Assert.AreEqual("пять рублей, тридцать копеек", rublesInWords);
        }

        [TestMethod]
        public void ToDollars_12_34_ReturnTrue()
        {
            string dollarsInWords = Transfer.ToDollars(12.34);

            Assert.AreEqual("двенадцать долларов, тридцать четыре цента", dollarsInWords);
        }

        [TestMethod]
        public void ToDollars_1101_71_ReturnTrue()
        {
            string dollarsInWords = Transfer.ToDollars(1101.71);

            Assert.AreEqual("одна тысяча сто один доллар, семьдесят один цент", dollarsInWords);
        }

        [TestMethod]
        public void ToDollars_5000033_92_ReturnTrue()
        {
            string dollarsInWords = Transfer.ToDollars(5000033.92);

            Assert.AreEqual("пять миллионов тридцать три доллара, девяносто два цента", dollarsInWords);
        }

        [TestMethod]
        public void ToEuro_77_77_ReturnTrue()
        {
            string euroInWords = Transfer.ToEuro(77.77);
            Assert.AreEqual("семьдесят семь евро, семьдесят семь евроцентов", euroInWords);
        }

        [TestMethod]
        public void ToEuro_835_91_ReturnTrue()
        {
            string euroInWords = Transfer.ToEuro(835.91);
            Assert.AreEqual("восемьсот тридцать пять евро, девяносто один евроцент", euroInWords);
        }

        [TestMethod]
        public void ToEuro_1000000_02_ReturnTrue()
        {
            string euroInWords = Transfer.ToEuro(1000000.02);
            Assert.AreEqual("один миллион евро, два евроцента", euroInWords);
        }

        [TestMethod]
        public void ToYuan_0_82_ReturnTrue()
        {
            string yuanInWords = Transfer.ToYuan(0.82);
            Assert.AreEqual("ноль юаней, восемьдесят два фэня", yuanInWords);
        }

        [TestMethod]
        public void ToYuan_900734_41_ReturnTrue()
        {
            string yuanInWords = Transfer.ToYuan(900734.41);
            Assert.AreEqual("девятьсот тысяч семьсот тридцать четыре юаня, сорок один фэнь", yuanInWords);
        }

        [TestMethod]
        public void ToYuan_15_99_ReturnTrue()
        {
            string yuanInWords = Transfer.ToYuan(15.99);
            Assert.AreEqual("пятнадцать юаней, девяносто девять фэней", yuanInWords);
        }
    }
}
