using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_1
{
    internal class Task1
    {
        
        public void print()
        {


            for (int i = 1; i < 101; i++)
            {
                string path = "note"+i+".txt";

                using (StreamWriter writer = new StreamWriter(path, false))
                {

                    for (int j = 0; j < 100000; j++)
                    {
                        StringBuilder sb = new StringBuilder();
                        DateTime s = Date(new DateTime(DateTime.Now.Year - 5, 12, 31), new DateTime(DateTime.Now.Year, 12, 31));

                        sb.Append(s.ToString("dd.MM.yyyy"));
                        sb.Append("||");
                        sb.Append(Generate10Latin());
                        sb.Append("||");
                        sb.Append(Generate10Cyrillic());
                        sb.Append("||");
                        sb.Append(GetRandomPositiveEvenInteger(100000000));
                        sb.Append("||");
                        sb.Append(GetRandomPositiveInteger());
                        sb.Append("||");
                        writer.WriteLine(sb);
                        Console.WriteLine(sb);
                    }

                }
            }
            
        }
        private static DateTime Date(DateTime startDate, DateTime endDate)
        {
            var rnd = new Random();
            var randomYear = rnd.Next(startDate.Year, endDate.Year);
            var randomMonth = rnd.Next(1, 12);
            var randomDay = rnd.Next(1, DateTime.DaysInMonth(randomYear, randomMonth));

            if (randomYear == startDate.Year)
            {
                randomMonth = rnd.Next(startDate.Month, 12);

                if (randomMonth == startDate.Month)
                    randomDay = rnd.Next(startDate.Day, DateTime.DaysInMonth(randomYear, randomMonth));
            }

            if (randomYear == endDate.Year)
            {
                randomMonth = rnd.Next(1, endDate.Month);

                if (randomMonth == endDate.Month)
                    randomDay = rnd.Next(1, endDate.Day);
            }

            var randomDate = new DateTime(randomYear, randomMonth, randomDay);


            return randomDate;


        }

        private static StringBuilder Generate10Latin()
        {
            StringBuilder sb = new StringBuilder();
            string symbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random r = new Random();
            for (int i=0; i<10;i++) {
                var index = r.Next(symbols.Length);
                sb.Append(symbols[index]);
            }
                
            
            return sb;
        }
        private static StringBuilder Generate10Cyrillic()
        {
            StringBuilder sb = new StringBuilder();
            string symbols = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                var index = r.Next(symbols.Length);
                sb.Append(symbols[index]);
            }


            return sb;
        }
        public static int GetRandomPositiveEvenInteger(int bound)
        {//метод для получения случайного положительного четного числа
            int rand = new Random().Next(bound);
            while (rand % 2 != 0)
            {//проверка на четность
                rand = new Random().Next(bound);
            }
            return rand;
        }
        public static String GetRandomPositiveInteger()
        {//случайное положительное число с 8 знаками после запятой в диапазоне от 1 до 20
            Random random = new Random();
            double a = random.NextDouble() * (20 - 1) + 1;
            
            String formattedDouble = string.Format("{0:f8}", a); //ограничение 8 знаков после запятой
            return formattedDouble;
        }
    }
}
