using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales_tax_receipt
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Create a looped input
            PrintInstructions();
            string input = Console.ReadLine();
            List<Product> basket = new List<Product>();

            while (input != "quit")
            {
                //  Accept empty string or double return to print receipt.
                if (string.IsNullOrWhiteSpace(input))
                {
                    PrintReceipt(basket);
                    basket.Clear();
                }
                else
                {
                    Product product = new Product(input);
                    basket.Add(product);
                }

                input = Console.ReadLine();
            }
        }

        static void PrintInstructions()
        {
            Console.WriteLine("Input a product, followed by the enter/return key.");
            Console.WriteLine("Hit enter/return again to print the receipt.");
            Console.WriteLine("To quit at any time, type quit, followed by the enter/return key.");
            Console.WriteLine("Enter an item to begin:");
        }

        static void PrintReceipt(List<Product> basket)
        {
            double taxes = 0.00;
            double total = 0.00;
            //  Print each product in the basket.
            foreach(Product product in basket)
            {
                int quantity = product.GetQuantity();
                string name = product.GetName();
                double price = product.GetPrice();
                double tax = product.GetTax();
                double sum_price = price + tax;
                
                taxes += tax;
                total += sum_price;

                string output = string.Format("{0} {1}: £{2}", quantity, name, sum_price);
                Console.WriteLine(output);
            }

            Console.WriteLine(string.Format("Sales Taxes: £{0:F2}", taxes));
            Console.WriteLine(string.Format("Total: £{0}", total));
            Console.Write("\n\n");
            PrintInstructions();
        }
    }
}
