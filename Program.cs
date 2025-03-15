using System.Net.Http.Headers;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        abstract class Person
        {
            protected string name;
            public string Name { get { return name; } protected set { name = value; } }

            protected string last_name;
            public string LastName { get { return last_name; } protected set { last_name = value; } }

            protected int age;
            public int Age { get { return age; } protected set { age = value; } }

            public PhoneNum PhoneNum;
        }

        class Buyer: Person
        {
            protected int NumCreditCard { get; set; }
        }

        class Curier: Person
        {
            public int NumOfOrders;
            public double Rating { get { return Rating; } private set { if (value <= 10 && value >= 0) { Rating = value; } } }
        }

        class Address
        {
            private string country, city, street, home;
            public string Country { get { return country; } set { country = value; } }
            public string City { get { return city; } set { city = value; } }
            public string Street { get { return street; } set { street = value; } }
            public string Home { get { return home; } set { home = value; } }
        }

        class PhoneNum
        {
            protected string country;
            public string Country { get { return country; } set { country = value; } }
            protected string num;
            public string Num { get { return num; } set { num = value; } }
        }

        class CompanyPhoneNum
        {
            private PhoneNum[] BlackList;
        }

        abstract class Delivery
        {
            public Address Address;

            public DateTime Date;

            public int DeliveryPrice;
        }

        class HomeDelivery : Delivery
        {
            public Curier Curier;
        }

        class PickPointDelivery : Delivery
        {
            public string ManagerName;
        }

        class ShopDelivery : Delivery
        {
            public string ManagerName;
        }

        class Order<TDelivery, TId> where TDelivery : Delivery
        {
            private TDelivery Delivery;

            public string Description;

            public Product Product;

            private TId OrderId;

            private Buyer Buyer;

            public CompanyPhoneNum CompanyPhoneNum;

            public void DisplayAddress()
            {
                Console.WriteLine(Delivery.Address);
            }

            public void DisplayProduct()
            {
                Console.WriteLine(Product.Title);
            }

            public void DisplayPrice()
            {
                Console.WriteLine("Product price: {0}", Product.ProductPrice);
                Console.WriteLine("Delivery price: {0}", Delivery.DeliveryPrice);
                Console.WriteLine("Total: {0}", Delivery.DeliveryPrice + Product.ProductPrice);
            }
        }

        class Product
        {
            public string Title;

            private DateTime CreationDate;

            public int ProductPrice;

            private bool IsRefund;
        }
    }
}