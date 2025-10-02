using System;

class Slovo
{
    public string Text { get; set; }

    public Slovo(string text)
    {
        Text = text;
        Console.WriteLine($"Створено об'єкт зі словом: {Text}");
    }

    ~Slovo()
    {
        Console.WriteLine($"Знищено об'єкт зі словом: {Text}");
    }

    public int CountDigits()
    {
        int count = 0;
        foreach (char c in Text)
        {
            if (char.IsDigit(c)) count++;
        }
        return count;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введіть кількість слів n: ");
        int n = int.Parse(Console.ReadLine());

        Slovo[] words = new Slovo[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введіть слово {i + 1}: ");
            string input = Console.ReadLine();
            words[i] = new Slovo(input);
        }

        int maxDigits = -1;
        string wordWithMaxDigits = "";

        foreach (var w in words)
        {
            int digits = w.CountDigits();
            Console.WriteLine($"Слово \"{w.Text}\" має {digits} цифр.");
            if (digits > maxDigits)
            {
                maxDigits = digits;
                wordWithMaxDigits = w.Text;
            }
        }

        Console.WriteLine($"\nСлово з найбільшою кількістю цифр: \"{wordWithMaxDigits}\" ({maxDigits} цифр).");
    }
}
