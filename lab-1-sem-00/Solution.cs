using System;
namespace lab_1_sem_00;

class Program
{ 
    static void Main()
    {
        Console.Write("Введите ваш никнейм: ");
        string name = Console.ReadLine();
        Console.Write("Введите ваш уровень: ");
        int.TryParse(Console.ReadLine(), out int level);
        Console.Write("Введите класс персонажа: ");
        string heroClass = Console.ReadLine();

        Console.WriteLine("\n========== ПРОФИЛЬ ==========");
        Console.WriteLine($"Никнейм:            {name}");
        Console.WriteLine($"Уровень:            {level}");
        Console.WriteLine($"Класс персонажа:    {heroClass}");
    }
}
