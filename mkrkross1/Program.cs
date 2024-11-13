using System;
using System.IO;
using System.Linq;

namespace App
{
    public  class BinarySequenceService
    {
        // Початкове значення послідовності
        private const int StartNValue = 7;

        // Функція для підрахунку одиничних бітів у двійковому представленні числа
        public static int CountOnesInBinary(int number)
        {
            return Convert.ToString(number, 2).Count(c => c == '1');
        }
        
        // Функція для знаходження N-го числа з трьома одиничними бітами в двійковому представленні
        public static int FindNthNumberWithThreeOnes(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Вхідне значення повинно бути позитивним числом.");
            }

            int count = 0;  // Лічильник для елементів послідовності
            int number = StartNValue;  // Початкове значення для перевірки

            while (true)
            {
                if (CountOnesInBinary(number) == 3) // Перевірка на три одиничні біти
                {
                    count++;
                    if (count == n)
                    {
                        return number; // Повертаємо N-й елемент
                    }
                }
                number++; // Переходимо до наступного числа
            }
        }

        static void Main(string[] args)
        {
            try
            {
                // Зчитуємо значення N з файлу INPUT.TXT
                string inputFile = "INPUT.TXT";
                string outputFile = "OUTPUT.TXT";
                
                // Перевірка чи існує вхідний файл
                if (!File.Exists(inputFile))
                {
                    throw new FileNotFoundException("Файл INPUT.TXT не знайдений.");
                }

                int N = int.Parse(File.ReadAllText(inputFile).Trim());

                // Знаходимо N-й елемент послідовності
                int nthTerm = FindNthNumberWithThreeOnes(N);

                // Записуємо результат в файл OUTPUT.TXT
                File.WriteAllText(outputFile, nthTerm.ToString());
            }
            catch (Exception ex)
            {
                // Обробка помилок і запис помилки в OUTPUT.TXT
                File.WriteAllText("OUTPUT.TXT", $"Помилка: {ex.Message}");
            }
        }
    }
}
