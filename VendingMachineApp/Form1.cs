using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VendingMachineApp
{
    public partial class Form1 : Form
    {
        List<Drink> drinksList = new List<Drink>();

        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void btnRefill_Click(object sender, EventArgs e)
        {
            this.drinksList.Clear();
            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3)
                {
                    case 0:
                        this.drinksList.Add(Juice.Generate());
                        break;
                    case 1:
                        this.drinksList.Add(Soda.Generate());
                        break;
                    case 2:
                        this.drinksList.Add(Alcohol.Generate());
                        break;
                }
            }
            ShowInfo();
        }

        private void ShowInfo()
        {
            int juiceCount = 0;
            int sodaCount = 0;
            int alcoholCount = 0;

            foreach (var drink in this.drinksList)
            {
                if (drink is Juice)
                    juiceCount++;
                else if (drink is Soda)
                    sodaCount++;
                else if (drink is Alcohol)
                    alcoholCount++;
            }

            txtInfo.Text = "Сок\tГазир.\tАлк.";
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t{1}\t{2}", juiceCount, sodaCount, alcoholCount);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (this.drinksList.Count == 0)
            {
                txtOut.Text = "Пусто Q_Q";
                return;
            }
            var drink = this.drinksList[0];
            this.drinksList.RemoveAt(0);
            txtOut.Text = drink.GetInfo();
            ShowInfo();
        }
    }
}