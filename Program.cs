using System.ComponentModel;

namespace Net
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            calculator.Sum();

            Console.ReadKey();
        }
    }

    public interface ICalculator
    {
        public void Sum();
    }

    public class Calculator : ICalculator
    {
        Logger logger;

        public Calculator()
        {
            logger = new Logger();
        }

        public void Sum()
        {
            try
            {
                Console.WriteLine("Пожалуйста введите 1ое число");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Пожалуйста введите 2ое число");
                double b = Convert.ToDouble(Console.ReadLine());

                logger.Event("Вычисление");

                Console.WriteLine($"Сумма равна: {a + b}");
            }

            catch 
            {
                logger.Error("Введено не правильное значение");
            }
        }
    }

    public interface ILogger
    {
        public void Event(string message);
        public void Error(string message);
    }

    public class Logger : ILogger
    {
        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
        }

        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
