﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var Chair = new Furnishings.Chair(true, true, "Leder", "DxRacer", 49.97);

            Console.WriteLine(DxRacer.ToString + "\n");

            Console.WriteLine("!! Satte Rabatte !!");

            DxRacer.Price = (DxRacer.Price * 0.8);

            Console.WriteLine("Nur heute: " + DxRacer.Price + " Euro");


            DxRacer.PrintPrice();
        }
    }
}

namespace Furnishings
{
     interface A
    {
        void PrintPrice();
    }

    abstract public class Furniture
    {
        virtual public string Name { get;  set; }
        private double m_price;
        
        public double Price
        {
           get
            {
                return Math.Round(m_price, 2);
            }
            set
            {
                if (value >= 0)
                    this.m_price = value;
                else
                    throw new ArgumentOutOfRangeException("Price must be positive");
            }
        }

        
    }

    public class Chair : Furniture, A 
    {

        public Boolean Mobile { get; private set; }
        public Boolean Rest { get; private set; }
        public string Cover { get; private set; }
        
        
        public  void PrintPrice()
        {
            Console.WriteLine("Der neue Stuhl " + this.Name + " kostet nur unglaubliche " + this.Price + " Euro");
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

    public class Table : Furniture, A
    {

        // Simple Setter/Getter for double property => Setter/Getter for multiple properties?
        public double Height
        {
            get
            {
                return Math.Round(Height, 2);
            }
            set
            {
                if (value >= 1)
                    this.Depth = value;
                else
                    throw new ArgumentOutOfRangeException("Deph must be greater than");
            }
        }
        public double Width
        {
            get
            {
                return Math.Round(Width, 2);
            }
            set
            {
                if (value >= 1)
                    this.Depth = value;
                else
                    throw new ArgumentOutOfRangeException("Deph must be greater than");
            }
        }
        public double Depth
        {
            get
            {
                return Math.Round(Depth, 2);
            }
            set
            {
                if (value >= 1)
                    this.Depth = value;
                else
                    throw new ArgumentOutOfRangeException("Deph must be greater than");
            }
        }

        public void PrintPrice() => Console.WriteLine("Der Stuhl " + this.Name + " kostet " + this.Price + " Euro.");

        public new string ToString => (this.Name + "\nHöhe(cm): " + this.Height + "\nBreite(cm): " + this.Width + "\nTiefe(cm): " + this.Depth) ;


        public Table(double newDepth, double newWidth, double newHeight, string newName, double newPrice)
        {
            Depth = newDepth;
            Width = newWidth;
            Height = newHeight;
            Name = newName;
            Price = newPrice;

        }
    }
}
