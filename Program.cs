using System.Net.Http.Headers;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        abstract class Delivery
        {
            public string Address;

            public DateTime Date;

            public int DeliveryPrice;
        }

        class HomeDelivery : Delivery
        {
            public string PhoneNum;

            public string CourierName;
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
            public TDelivery Delivery;

            public string Description;

            public Product Product;

            public TId OrderId;

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