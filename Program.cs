namespace Net
{
    public class Program
    {
        static void Main(string[] args)
        {
            Exception myException = new Exception("Моё исключение");
            NullReferenceException nullReferenceException = new NullReferenceException();
            ArgumentException argumentException = new ArgumentException();
            DivideByZeroException divideByZeroException = new DivideByZeroException();
            FileNotFoundException fileNotFoundException = new FileNotFoundException();

            Exception[] exceptions = { myException, nullReferenceException, argumentException, divideByZeroException, fileNotFoundException};
            foreach (Exception exception in exceptions)
            {
                try
                {
                    throw exception;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            string[] last_names = { "Сидоров", "Ельцин", "Бурангулов", "Архипов", "Иванов"};
            SortArray sortArray = new SortArray();
            sortArray.SortEvent += ShowArray;

            try
            {
                sortArray.SortedArray(last_names);
            }

            catch (FormatException)
            {
                Console.WriteLine("Неверный формат");
            }
        }

        static void ShowArray(string[] array)
        {
            foreach (string item in array)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class  SortArray
    {
        public delegate void SortDelegate(string[] array);
        public event SortDelegate SortEvent;

        public void SortedArray(string[] array)
        {
            Console.WriteLine();
            Console.WriteLine("Введите 1 для сортировки А-Я или 2 для сортировки Я-А");

            int number = Convert.ToInt32(Console.ReadLine());

            if (number != 1 && number != 2) throw new FormatException();

            Array.Sort(array);

            if (number == 2) Array.Reverse(array);

            SortEvent?.Invoke(array);
        }
    }
}
