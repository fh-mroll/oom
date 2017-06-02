using System;
using System.IO; //File operations
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            const string PATH_json = @"D:\Programmieren\oom\tasks\Task3\Task2\Objects.json";
            int i = 0;
            var content = new string[200];
            
            //Create Some Objects
            Furnishings.Chair[] chairs = new Furnishings.Chair[2];
            
            var table = new Furnishings.Table(12.50123, 25.32, 50.30, "SimpleTable", 26.923);

            chairs[0] = new Furnishings.Chair(true, true, "Leder", "DxRacer", 149.97);
            chairs[1] = new Furnishings.Chair(true, true, "steel", "DxRacerSpace", 1049.34);


            //test everything
            Console.WriteLine(chairs[0].ToString);

            Console.WriteLine(chairs[1].ToString + "\n");

            Console.WriteLine("!! Satte Rabatte !!");

            chairs[1].Price = (chairs[1].Price * 0.8);

            Console.WriteLine("Nur heute: " + chairs[1].Price + " Euro");

            chairs[1].PrintPrice();

            Console.WriteLine("\n\n");

            Console.WriteLine(chairs[1].ToString);
            table.PrintPrice();

            //array for serialization

            var furnishing = new Furnishings.A[] { table, chairs[0], chairs[1], new Furnishings.Table(20.00, 36.00, 50.00, "Table0815", 9.99) } ;

            //Write Json File
            if (!File.Exists(PATH_json))
            {
                MemberSerialization memberSerialization;
                memberSerialization = (MemberSerialization)2;
                var stream = File.AppendText(PATH_json);

                foreach (var instance in furnishing)
                {
                    stream.WriteLine(JsonConvert.SerializeObject(instance));
                }
                stream.Flush();
                stream.Close();
            }
            
            //Output Json File
            content = File.ReadAllLines(PATH_json);
            Console.WriteLine("\n\njson-file content:\n");

            foreach (var line in content)
            {
                Console.WriteLine(line);               
            }

            // deserialize test
            var definition = new { Name = "" };

            string json1 = content[0];
            var furniture1 = JsonConvert.DeserializeAnonymousType(json1, definition);
            
             Console.WriteLine(furniture1.Name);

        }
    }
}

namespace Furnishings
{
    interface A
    {
        void PrintPrice();
    }

    abstract public class Furniture: A
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
        public void PrintPrice() =>  Console.WriteLine(this.Name + " kostet nur unglaubliche " + this.Price + " Euro");
        
    }

    public class Chair : Furniture
    {

        public Boolean Mobile { get; private set; }
        public Boolean Rest { get; private set; }
        public string Cover { get; private set; }
        
        


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

    public class Table : Furniture
    {

        // Simple Setter/Getter for double property => Setter/Getter for multiple properties?
        public double Height{get;private set;}
        public double Width{ get; private set;}
        public double Depth { get; private set; }

        public new void PrintPrice() => Console.WriteLine("Der Tisch " + this.Name + " kostet " + this.Price + " Euro.");

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

