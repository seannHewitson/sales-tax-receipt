using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales_tax_receipt
{
    class Product
    {
        int quantity;
        string name;
        double price;
        double tax;

        public Product(string product)
        {
            string[] seperated = product.Split(' ');
            //  Set Price
            string split_price = seperated[seperated.Length - 1];
            split_price = split_price.Replace("£", "");
            double.TryParse(split_price, out price);

            //  Set Quantity
            int.TryParse(seperated[0], out quantity);

            //  Set Name
            name = "";
            int max = seperated.Length - 2;
            for (int i = 1; i <= max; i++)
            {
                name += seperated[i];
                if(i != max)
                {
                    name += " ";
                }
            }

            CalculateTax();
        }

        private void CalculateTax()
        {
            //  Get the percentage
            double percentage = 0.00;
            List<string> exemptions = new List<string>();
            exemptions.Add("book");
            exemptions.Add("chocolate");
            exemptions.Add("pills");

            //  Check if the product is imported
            if (name.Contains("imported"))
            {
                percentage += 0.05;
            }

            //  Check if the product is not exempt
            bool exempt = false;
            foreach(string exemption in exemptions)
            {
                if (name.Contains(exemption))
                {
                    exempt = true;
                }
            }

            if (!exempt)
            {
                percentage += 0.1;
            }

            //  Calculate the monetary value
            double value = price * percentage;
            tax = Math.Round(value * 20) / 20;
        }

        //  Getters
        public int GetQuantity()
        {
            return quantity;
        }

        public string GetName()
        {
            return name;
        }

        public double GetPrice()
        {
            return price;
        }

        public double GetTax()
        {
            return tax;
        }
    }
}
