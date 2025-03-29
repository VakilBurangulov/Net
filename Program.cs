using static Net.Program;

namespace Net
{
    public class Program
    {
        delegate string[] SortArrayDelegate (string[] s);

        static void Main(string[] args)
        {
            Exception myException = new Exception("Введены не валидные данные");
            ArgumentException myArgumentException = new ArgumentException();
            NullReferenceException myNullReferenceException = new NullReferenceException();
            ArgumentNullException myArgumentNullException = new ArgumentNullException();
            FileNotFoundException fileNotFoundException = new FileNotFoundException();

            Exception[] exceptions = { myException, myArgumentException, myNullReferenceException, myArgumentNullException };

            foreach (Exception ex in exceptions)
            {
                try
                {
                    throw ex;
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            string[] last_names = { "Сидоров", "Иванов", "Архипов", "Старостина", "Бурангулов" };

            SortArrayDelegate sortArrayDelegate = SortArray;

            sortArrayDelegate(last_names);

            foreach (string s in last_names)
            {
                Console.WriteLine(s);
            }
        }

        static string[] SortArray(string[] s)
        {
            Exception myException = new Exception("Введены не валидные данные");
            try
            {
                Console.WriteLine("Пожалуйста введите 1 если хотите сортировку А-Я или 2 если хотите сортировку Я-А");
                string us = Console.ReadLine();
                if (us != "1" && us != "2")
                    throw myException;
                switch (us)
                {
                    case "1": Array.Sort(s); break;
                    case "2": Array.Sort(s); Array.Reverse(s); break;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return s;
            
        }
    }
}
