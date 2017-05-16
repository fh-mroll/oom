using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task2
{


    class Program
    {
        static void Main(string[] args)
        {
           
            var DxRacer = new Furniture.Chair(true, true, "Leder", "DxRacer", 49.97);

            Console.WriteLine(DxRacer.ToString + "\n");

            Console.WriteLine("!! Satte Rabatte !!");

            DxRacer.Price = (DxRacer.Price * 0.8);

            Console.WriteLine("Nur heute: " + DxRacer.Price + " Euro");


            DxRacer.PrintPrize();
        }
    }
}

namespace Furniture
{

    public interface A
    {
        void PrintPrice();
    }

    public class Chair 
    {

        public Boolean Mobile { get; private set; }
        public Boolean Rest { get; private set; }
        public string Cover { get; private set; }
        public string Name { get; private set; }
        private double m_price;

        public double Price
        {
            get
            {
                return Math.Round(m_price,2);
            }

            set
            {
                if (value >= 0)
                    this.m_price = value;
                else
                    throw new ArgumentOutOfRangeException("Price must be positive");
            }


        }

        public void PrintPrize()
        {
            Console.WriteLine("Der neue " + this.Name + " kostet unglaubliche " + this.Price + " Euro");
        }

        public new string ToString => ($"Sessel ist mobil: {this.Mobile} \nBesitzt eine Lehne: {this.Rest} \nSessel Bezug: {this.Cover}\nKosten: {this.Price}");

        public Chair(Boolean newMobile, Boolean newRest, string newCover, string newName, double newPrice)
        {
            Name = newName;
            Mobile = newMobile;
            Rest = newRest;
            Cover = newCover;
            Price = newPrice;
        }
    }


}
