using System;

namespace VendingMachineApp
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

    public enum JuiceFruit { Orange, Apple, Multifruit }

    public class Juice : Drink
    {
        public JuiceFruit FruitUsed;
        public bool HasPulp;

        public override string GetInfo()
        {
            var str = "Я сок";
            str += "\n" + base.GetInfo();
            str += $"\nФрукт: {FruitUsed}";
            str += $"\nМякоть: {(HasPulp ? "есть" : "нет")}";
            return str;
        }

        public static Juice Generate()
        {
            return new Juice
            {
                Volume = 200 + rnd.Next(300),
                FruitUsed = (JuiceFruit)rnd.Next(3),
                HasPulp = rnd.Next(2) == 0
            };
        }
    }

    public enum SodaType { Cola, Lemonade, Tonic }

    public class Soda : Drink
    {
        public SodaType Type;
        public int BubbleCount;

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
                Volume = 250 + rnd.Next(250),
                Type = (SodaType)rnd.Next(3),
                BubbleCount = 500 + rnd.Next(1500)
            };
        }
    }

    public enum AlcoholType { Beer, Wine, Vodka }

    public class Alcohol : Drink
    {
        public double Strength;
        public AlcoholType Type;

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
                Volume = 40 + rnd.Next(460),
                Strength = Math.Round(3.0 + rnd.NextDouble() * 37.0, 1),
                Type = (AlcoholType)rnd.Next(3)
            };
        }
    }
}