using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;


namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};

            IEnumerable<string> LFruits = fruits.FindAll(fruit => fruit.StartsWith("L"));
            // foreach(string fruit in LFruits)
            // {
            //     Console.Write(fruit);
            // }


            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            IEnumerable<int> fourSixMultiples = numbers.Where(n => n % 6 == 0 | n % 4 == 0);
            // foreach(int number in fourSixMultiples)
            // {
            //     Console.WriteLine(number);
            // }

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre"
            };

            IEnumerable<string> descend = names.OrderByDescending(n => n);
            // foreach(string name in descend)
            // {
            //     Console.WriteLine(name);
            // }

            // Build a collection of these numbers sorted in ascending order
            List<int> numbers2 = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            IEnumerable<int> sorted = numbers2.OrderBy(n => n);

            // foreach(int number in sorted)
            // {
            //     Console.WriteLine(number);
            // }

            // Output how many numbers are in this list
            List<int> numbers3 = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            int count = numbers3.Count();
            // Console.WriteLine(count);

            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };

            double total = purchases.Sum();
            // Console.WriteLine(total);

            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };

            double max = prices.Max();
            // Console.WriteLine(max);

            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };
            /*
                Store each number in the following List until a perfect square
                is detected.

                Expected output is { 66, 12, 8, 27, 82, 34, 7, 50, 19, 46 } 
            */

            IEnumerable<int> takeUntilSquare = wheresSquaredo.TakeWhile(n => Math.Sqrt(Convert.ToDouble(n)) - Math.Floor(Math.Sqrt(Convert.ToDouble(n))) != 0);
            // foreach(int number in takeUntilSquare)
            // {
            //     Console.WriteLine(number);
            // }

            // Create some banks and store in a List
            List<Bank> banks = new List<Bank>() {
                new Bank(){ Name="First Tennessee", Symbol="FTB"},
                new Bank(){ Name="Wells Fargo", Symbol="WF"},
                new Bank(){ Name="Bank of America", Symbol="BOA"},
                new Bank(){ Name="Citibank", Symbol="CITI"},
            };

            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            IEnumerable<Customer> Millionaires = customers.Where(customer => customer.Balance >= 1000000);

            // foreach(Customer customer in Millionaires)
            // {
            //     Console.WriteLine(customer.Name);
            // }
            
            Dictionary<string, int> list = new Dictionary<string, int>();

            foreach(Customer millionaire in Millionaires)
            {
                if(list.ContainsKey(millionaire.Bank))
                {
                    list[millionaire.Bank] += 1;
                }
                else
                {
                    list[millionaire.Bank] = 1;
                }
            }

            // foreach(KeyValuePair<string, int> key in list)
            // {
            //     Console.WriteLine(key);
            // }





            var report = from bank in banks
            join m in Millionaires
            on bank.Symbol equals m.Bank
            into mg
            from m_g in mg
            select new {
                CustomerName = m_g.Name,
                BankName = bank.Name
            };

            var reportAlpha = report.OrderBy(customer => customer.CustomerName.Split(" ")[1]);


            foreach(var person in reportAlpha)
            {
                Console.WriteLine($"{person.CustomerName} with {person.BankName}");
            }



        }
    }
    public class Bank
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
    }
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }
    public class ReportItem
    {
        public string CustomerName { get; set; }
        public string BankName { get; set; }
    }
}
