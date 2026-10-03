using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_1_sem_00_advanced;

public class Validator
{
    public static bool ValidateInputValue(string? input, out int value)
    {
        if (!int.TryParse(input, out value))
        {
            Console.WriteLine("Ошибка: введено не число.");
            return false;
        }

        if (value < 0)
        {
            Console.WriteLine("Ошибка: значение не может быть меньше нуля.");
            return false;
        }

        return true;
    }

    public static bool ValidateInputValue(string? input, int remainingPoints, out int value)
    {
        if (!Validator.ValidateInputValue(input, out value))
        {
            return false;
        }

        if (value > remainingPoints)
        {
            Console.WriteLine($"Ошибка: нельзя потратить больше очков, чем осталось. Осталось {remainingPoints} очков.");
            return false;
        }

        return true;
    }
}

class Stats
{
    public static Dictionary<string, int> AllocateStartStats(int totalPoints)
    {
        var stats = new Dictionary<string, int>
        {
            { "Сила", 0 },
            { "Ловкость", 0 },
            { "Интеллект", 0 },
            { "Скрытность", 0 }
        };

        foreach (var stat in stats.Keys.ToList())
        {
            while (true)
            {
                Console.Write($"Введите количество очков для {stat} (осталось {totalPoints}): ");
                string? input = Console.ReadLine();

                if (Validator.ValidateInputValue(input, totalPoints, out int value))
                {
                    stats[stat] = value;
                    totalPoints -= value;
                    break;
                }
            }
        }

        return stats;
    }
}

class HeroClass
{
    public static Dictionary<int, string> classes = new Dictionary<int, string>
    {
        { 1, "Воин" },
        { 2, "Лучник" },
        { 3, "Маг" },
        { 4, "Разбойник" },
        { 5, "Паладин" }
    };

    public static string ChooseHeroClass(Dictionary<int, string> classes)
    {
        while (true)
        {
            Console.WriteLine("\nВыберите класс персонажа: ");
            foreach (var kvp in classes)
            {
                Console.WriteLine($"{kvp.Key}. {kvp.Value}");
            }

            string? input = Console.ReadLine();
            if (Validator.ValidateInputValue(input, out int choice) && classes.ContainsKey(choice))
            {
                return classes[choice];
            }

            Console.WriteLine("Ошибка: выберите корректный номер класса.");
        }
    }
}

class HeroCreation
{
    public static (string, string, Dictionary<string, int>) CreateHero()
    {
        Console.Write("Введите ваш никнейм: ");
        string characterNickname = Console.ReadLine() ?? "Hero";
        string characterClass = HeroClass.ChooseHeroClass(HeroClass.classes);
        Dictionary<string, int> characterStats = Stats.AllocateStartStats(10);
        return (characterNickname, characterClass, characterStats);
    }
}

class StatsDisplay
{
    public static void DisplayStats(string characterNickname, string characterClass, Dictionary<string, int> characterStats)
    {
        Console.WriteLine("\n========== ПРОФИЛЬ ==========");
        Console.WriteLine($"Никнейм:            {characterNickname}");
        Console.WriteLine($"Класс персонажа:    {characterClass}");
        Console.WriteLine("====== Статы персонажа ======:");
        foreach (var stat in characterStats)
        {
            Console.WriteLine($"{stat.Key}: {stat.Value}");
        }
    }
}

class Solution
{
    static void Main(string[] args)
    {
        var (nickname, @class, stats) = HeroCreation.CreateHero();
        StatsDisplay.DisplayStats(nickname, @class, stats);
    }
}
