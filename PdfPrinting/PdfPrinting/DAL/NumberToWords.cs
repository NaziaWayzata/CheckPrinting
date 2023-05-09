using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheque_Printing
{
    internal class NumberToWords
    {
        private static String[] units = { "Zero", "One", "Two", "Three",
    "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
    "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
    "Seventeen", "Eighteen", "Nineteen" };
        private static String[] tens = { "", "", "Twenty", "Thirty", "Forty",
    "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        public  String ConvertAmount(double amount)
        {
            try
            {
                Int64 amount_int = (Int64)amount;
                Int64 amount_dec = (Int64)Math.Round((amount - (double)(amount_int)) * 100);

                if (amount == 1)
                {
                    return Convert(amount_int) + " Dollar Only.";
                }
                else
                if (amount_dec == 0)
                {
                    return Convert(amount_int) + " Dollars Only.";
                }
                else
                {
                    return Convert(amount_int) + " Dollars and " + Convert(amount_dec) + " Cents Only.";
                }
            }
            catch (Exception e)
            {
                // TODO: handle exception  
            }
            return "";
        }

        public static String Convert(Int64 i)
        {
            if (i == 1)
            {
                return units[i];
            }
            if (i < 20)
            {
                return units[i];
            }
            if (i < 100)
            {
                return tens[i / 10] + ((i % 10 > 0) ? " " + Convert(i % 10) : "");
            }
            if (i < 1000)
            {
                return units[i / 100] + " Hundred"
                        + ((i % 100 > 0) ? " And " + Convert(i % 100) : "");
            }
        


            if (i < 1000000)
            {
                return Convert(i / 1000) + " Thousand"
                        + ((i % 1000 > 0) ? " " + Convert(i % 1000) : "");
            }

            if (i < 1000000000)
            {
                return Convert(i / 1000000) + " Million"
                        + ((i % 1000000 > 0) ? " " + Convert(i % 1000000) : "");
            }


            return Convert(i / 1000000000) + " Billion"
                    + ((i % 1000000000 > 0) ? " " + Convert(i % 1000000000) : "");
        }


        public  string ConvertNumeralsToArabic(string input)

        {

            return input = input.Replace('0', '٠')

                        .Replace('1', '۱')

                        .Replace('2', '۲')

                        .Replace('3', '۳')

                        .Replace('4', '٤')

                        .Replace('5', '۵')

                        .Replace('6', '٦')

                        .Replace('7', '٧')

                        .Replace('8', '٨')

                        .Replace('9', '٩');

        }

    }
}
