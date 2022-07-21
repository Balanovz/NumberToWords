using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords
{
    public static class Transfer
    {

        static string ExceptionNumber(in ulong number)
        {
            switch (number)
            {
                case 10: return " десять";
                case 11: return " одиннадцать";
                case 12: return " двенадцать";
                case 13: return " тринадцать";
                case 14: return " четырнадцать";
                case 15: return " пятнадцать";
                case 16: return " шестнадцать";
                case 17: return " семнадцать";
                case 18: return " восемнадцать";
                case 19: return " девятнадцать";
                default: return "";
            }
        }

        static string UnitDigit(in ulong number, int dischargeNumber = 2)
        {
            switch (number)
            {
                case 1: if (dischargeNumber == 2) return " одна"; else return " один";
                case 2: if (dischargeNumber == 2) return " две"; else return " два";
                case 3: return " три";
                case 4: return " четыре";
                case 5: return " пять";
                case 6: return " шесть";
                case 7: return " семь";
                case 8: return " восемь";
                case 9: return " девять";
                default: return "";
            }
        }

        static string DozensDigit(in ulong number)
        {
            switch (number)
            {
                case 2: return " двадцать";
                case 3: return " тридцать";
                case 4: return " сорок";
                case 5: return " пятьдесят";
                case 6: return " шестьдесят";
                case 7: return " семьдесят";
                case 8: return " восемьдесят";
                case 9: return " девяносто";
                default: return "";
            }
        }

        static string HundredsDigit(uint digit)
        {
            switch (digit)
            {
                case 1: return " сто";
                case 2: return " двести";
                case 3: return " триста";
                case 4: return " четыреста";
                case 5: return " пятьсот";
                case 6: return " шестьсот";
                case 7: return " семьсот";
                case 8: return " восемьсот";
                case 9: return " девятьсот";
                default: return "";

            }
        }

        static void Split(ref ulong[] splittingNumber, in ulong number)
        {
            splittingNumber[0] = (number - (number % 1000000000)) / 1000000000;
            splittingNumber[1] = ((number % 1000000000) - (number % 1000000)) / 1000000;
            splittingNumber[2] = ((number % 1000000) - (number % 1000)) / 1000;
            splittingNumber[3] = number % 1000;
        }

        static public ulong FindThirdDigit(ulong dischargeNumber)
        {
            return ((dischargeNumber - (dischargeNumber % 100)) / 100);
        }
        static public ulong FindSecondDigit(ulong dischargeNumber)
        {
            return ((dischargeNumber % 100) - ((dischargeNumber % 100) % 10)) / 10;
        }

        static void MillionBillionCheck(ulong dischargeNumber, ref string transferNumbersToWords, int indexOfDischargePostfixWord)
        {
            string[,] millionBillionStrings = new string[4, 3] 
            {
                {" миллиард", " миллиарда", " миллиардов"}, 
                {" миллион", " миллиона", " миллионов"},
                {" тысяча", " тысячи", " тысяч"},
                {"", "", ""}
            };

            if (dischargeNumber % 100 >= 10 && dischargeNumber % 100 <= 19) 
                transferNumbersToWords += millionBillionStrings[indexOfDischargePostfixWord, 2];
            else switch (dischargeNumber % 10)
            {
                case 1: transferNumbersToWords += millionBillionStrings[indexOfDischargePostfixWord, 0]; break; 
                case 2:
                case 3:
                case 4: transferNumbersToWords += millionBillionStrings[indexOfDischargePostfixWord, 1]; break;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9: 
                case 0: transferNumbersToWords += millionBillionStrings[indexOfDischargePostfixWord, 2]; break;
                }
        }

        public static string ToWords(ulong number)
        {
            //разбивка числа из формата 123456789 => [0] = 123
            //                                       [1] = 456
            //                                       [2] = 789

            ulong[] splittingNumber = new ulong[4];
            Split(ref splittingNumber, number);
            

            string transferNumberToWords = "";
            uint digitOfNumber = default;

            if (number == 0) transferNumberToWords = "ноль";
            else
                for (int i = 0; i < 4; i++)
                {
                    if (splittingNumber[i] != 0)
                    {
                        digitOfNumber = (uint) FindThirdDigit(splittingNumber[i]);
                        if (digitOfNumber != 0)
                            transferNumberToWords += HundredsDigit(digitOfNumber);
                        
                        digitOfNumber = (uint) FindSecondDigit(splittingNumber[i]);
                        if(digitOfNumber != 1)
                        {
                            transferNumberToWords += DozensDigit(digitOfNumber);
                            digitOfNumber = (uint) splittingNumber[i] % 10;
                            transferNumberToWords += UnitDigit(digitOfNumber, i);
                        }
                        else
                        {
                            digitOfNumber = (uint) splittingNumber[i] % 100;
                            transferNumberToWords += ExceptionNumber(digitOfNumber);
                        }
                        MillionBillionCheck(splittingNumber[i], ref transferNumberToWords, i);
                    }
                }
            return transferNumberToWords.TrimStart();
        }

        public static string ToWords(double number)
        {
            double roundingUpFactor = 0.009;
            string transferNumber = ToWords((ulong)number);
            ulong lowMoney = (ulong)((number - (ulong)number + roundingUpFactor) * 100);

            transferNumber += ", " + ToWords(lowMoney);
            return transferNumber;
        }

        public static string ToDollars(double number)
        {
            string money = ToWords(number);
            string ending;
            
            ending = money.Substring(money.IndexOf(',') - 2, 2);
            if (ending == "ин") money = money.Insert(money.IndexOf(','), " доллар");
            else if (ending == "ва" || ending == "ри" || ending == "ре") money = money.Insert(money.IndexOf(','), " доллара");
            else money = money.Insert(money.IndexOf(','), " долларов");

            ending = money.Substring(money.Length - 3, 3);
            if (ending == "дин") 
                money += " цент";
            else if (ending == "два" || ending == "три" || ending == "ыре")
                money += " цента";
            else money += " центов";
            
            
            return money;
        }

        public static string ToRubles(double number)
        {
            string money = ToWords(number);
            string ending;

            ending = money.Substring(money.IndexOf(',') - 2, 2);
            if (ending == "ин") money = money.Insert(money.IndexOf(','), " рубль");
            else if (ending == "ва" || ending == "ри" || ending == "ре") money = money.Insert(money.IndexOf(','), " рубля");
            else money = money.Insert(money.IndexOf(','), " рублей");

            ending = money.Substring(money.Length - 3, 3);
            if (ending == "дин")
                money = money.Substring(0, money.LastIndexOf(' ')) + " одна копейка";
            else if (ending == "две" || ending == "три" || ending == "ыре") money += " копейки";
            else money += " копеек";
            
            return money;
        }

        public static string ToEuro(double number)
        {
            string money = ToWords(number);
            string ending;

            money = money.Insert(money.IndexOf(','), " евро");

            ending = money.Substring(money.Length - 3, 3);
            if (ending == "дин")
                money += " евроцент";
            else if (ending == "два" || ending == "три" || ending == "ыре")
                money += " евроцента";
            else money += " евроцентов";
            
            return money;
        }

        public static string ToYuan(double number)
        {
            string money = ToWords(number);
            string ending;
            
            ending = money.Substring(money.IndexOf(',') - 2, 2);
            if (ending == "ин") money = money.Insert(money.IndexOf(','), " юань");
            else if (ending == "ва" || ending == "ри" || ending == "ре") money = money.Insert(money.IndexOf(','), " юаня");
            else money = money.Insert(money.IndexOf(','), " юаней");

            ending = money.Substring(money.Length - 3, 3);
            if (ending == "дин")
                money += " фэнь";
            else if (ending == "два" || ending == "три" || ending == "ыре")
                money += " фэня";
            else money += " фэней";
            
            return money;
        }
    }
}
