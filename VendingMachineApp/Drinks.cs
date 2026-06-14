using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Drink
    {
        public static Random rnd = new Random();
        public int Volume = 0;
        public virtual string GetInfo()
        {
            return $"Объём: {Volume} мл";
        }
    }
    public enum JuiceFruit // фиксированный набор констат
    {
        Orange,
        Apple,
        Multifruit
    }
    public class Juice : Drink
    {
        public JuiceFruit FruitUsed;     // Используемый фрукт
        public bool HasPulp;            // Наличие мякоти

        public override string GetInfo()
        {
            var str = "Я сок";
            str += "\n" + base.GetInfo();  // добавляем информацию базового класса
            str += $"\nФрукт: {FruitUsed}";
            str += $"\nМякоть: {(HasPulp ? "есть" : "нет")}";
            return str;
        }

        public static Juice Generate()
        {
            return new Juice
            {
                Volume = 200 + rnd.Next(300),                   // объём от 200 до 500 мл
                FruitUsed = (JuiceFruit)rnd.Next(3),            // случайный фрукт
                HasPulp = rnd.Next(2) == 0                      // мякоть true/false
            };
        }
    }

    public enum SodaType
    {
        Cola,
        Lemonade,
        Tonic
    }

    public class Soda : Drink
    {
        public SodaType Type;          // Вид (тип) газировки
        public int BubbleCount;        // Количество пузырьков

        public override string GetInfo()
        {
            var str = "Я газировка";
            str += "\n" + base.GetInfo();
            str += $"\nТип: {Type}";
            str += $"\nПузырьков: {BubbleCount}";
            return str;
        }

        public static Soda Generate()
        {
            return new Soda
            {
                Volume = 250 + rnd.Next(250),                  // объём от 250 до 500 мл
                Type = (SodaType)rnd.Next(3),                  // случайный вид
                BubbleCount = 500 + rnd.Next(1500)             // пузырьки от 500 до 2000
            };
        }
    }

    // Перечисление типов алкоголя
    public enum AlcoholType
    {
        Beer,
        Wine,
        Vodka
    }

    public class Alcohol : Drink
    {
        public double Strength;        // Крепость в %
        public AlcoholType Type;       // Тип алкоголя

        public override string GetInfo()
        {
            var str = "Я алкоголь";
            str += "\n" + base.GetInfo();
            str += $"\nКрепость: {Strength:F1}%";
            str += $"\nТип: {Type}";
            return str;
        }

        public static Alcohol Generate()
        {
            return new Alcohol
            {
                Volume = 40 + rnd.Next(460),                   // объём от 40 до 500 мл
                Strength = Math.Round(3.0 + rnd.NextDouble() * 37.0, 1), // крепость от 3.0% до 40.0%
                Type = (AlcoholType)rnd.Next(3)                // случайный тип
            };
        }
    }
}