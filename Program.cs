using System;

namespace _30_array_of_objects_Ivanvasylcuk
{
    public class Slovo
    {
        public string? Text { get; set; }

        public Slovo(string? text)
        {
            // Do not write to console from constructors. Keep object creation silent.
            Text = text;
        }

        // Finalizers should be avoided for simple classes; remove the finalizer.

        public int CountDigits()
        {
            if (Text is null) return 0; // defensive: treat null as zero digits

            int count = 0;
            foreach (char c in Text)
            {
                if (char.IsDigit(c)) count++;
            }
            return count;
        }
    }

    // Головна програма
    public class Program
    {
        static void Main()
        {
            int n = ReadPositiveInt("Введіть кількість слів n: ");

            if (n <= 0)
            {
                Console.WriteLine("Кількість слів має бути натуральним числом більше нуля. Завершення програми.");
                return;
            }

            Slovo[] words = new Slovo[n];

            for (int i = 0; i < n; i++)
            {
                string input = ReadNonEmptyLine($"Введіть слово {i + 1}: ");
                words[i] = new Slovo(input);
            }

            int maxDigits = -1;
            var wordsWithMaxDigits = new System.Collections.Generic.List<string>();

            foreach (var w in words)
            {
                int digits = w.CountDigits();
                Console.WriteLine($"Слово \"{w.Text}\" має {digits} цифр.");
                if (digits > maxDigits)
                {
                    maxDigits = digits;
                    wordsWithMaxDigits.Clear();
                    wordsWithMaxDigits.Add(w.Text ?? string.Empty);
                }
                else if (digits == maxDigits)
                {
                    wordsWithMaxDigits.Add(w.Text ?? string.Empty);
                }
            }

            if (maxDigits < 0)
            {
                Console.WriteLine("Жодних слів для обробки.");
            }
            else
            {
                Console.WriteLine($"\nСлова з найбільшою кількістю цифр ({maxDigits}):");
                foreach (var s in wordsWithMaxDigits)
                {
                    Console.WriteLine($"\"{s}\"");
                }
            }

            Console.WriteLine($"\nПрограма завершила роботу.");
        }

        private static int ReadPositiveInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? line = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine("Введено порожній рядок. Спробуйте ще раз.");
                    continue;
                }

                line = line.Trim();

                if (int.TryParse(line, out int value))
                {
                    if (value > 0) return value;
                    Console.WriteLine("Число має бути натуральним (більше нуля). Спробуйте ще раз.");
                }
                else
                {
                    Console.WriteLine("Некоректне число. Спробуйте ще раз.");
                }
            }
        }

        private static string ReadNonEmptyLine(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? line = Console.ReadLine();

                if (line is null)
                {
                    Console.WriteLine("Отримано null. Спробуйте ще раз.");
                    continue;
                }

                line = line.Trim();
                if (line.Length == 0)
                {
                    Console.WriteLine("Порожній рядок. Введіть, будь ласка, слово ще раз.");
                    continue;
                }

                return line;
            }
        }
    }
}
