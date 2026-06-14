using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



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
}