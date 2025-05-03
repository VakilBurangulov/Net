using System.Diagnostics;

namespace Net
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText("D:\\Downloads\\input.txt");
            var textForChars =  text.ToCharArray();
            
            var listAddToFirst =  new List<char>(textForChars);
            var linkedListAddToFirst = new LinkedList<char>(textForChars);
            
            var listAddToMiddle =  new List<char>(textForChars);
            var linkedListAddToMiddle = new LinkedList<char>(textForChars);
            
            var listAddToLast =  new List<char>(textForChars);
            var linkedListAddToLast = new LinkedList<char>(textForChars);
            
            
            
            
            // Add to first
            var timer = Stopwatch.StartNew();
            AddValuesToMiddleList(listAddToFirst, 'h', 0);
            var timeList = timer.Elapsed.TotalMilliseconds;
            
            timer = Stopwatch.StartNew();
            linkedListAddToFirst.AddFirst('h');
            var timeLinkedList = timer.Elapsed.TotalMilliseconds;
            
            Console.WriteLine($"Время добавдение элемента в начало листа\n" +
                              $"Цепь: {timeLinkedList} мс\n" +
                              $"Простой лист: {timeList} мс");
            Console.WriteLine();
            
            
            
            // Add to middle
            var middleIndex = Convert.ToInt32(textForChars.Length / 2);
            timer = Stopwatch.StartNew();
            AddValuesToMiddleList(listAddToMiddle, 'h', middleIndex);
            timeList = timer.Elapsed.TotalMilliseconds;
            
            timer = Stopwatch.StartNew();
            var middleValue = linkedListAddToMiddle.Find(textForChars[middleIndex]);
            if (middleValue != null)
                linkedListAddToMiddle.AddAfter(middleValue, 'h');
            timeLinkedList = timer.Elapsed.TotalMilliseconds;
            
            Console.WriteLine($"Время добавдение элемента в середину листа\n" +
                              $"Цепь: {timeLinkedList} мс\n" +
                              $"Простой лист: {timeList} мс");
            Console.WriteLine();
            
            
            
            // Add to last
            timer = Stopwatch.StartNew();
            listAddToLast.Add('h');
            timeList = timer.Elapsed.TotalMilliseconds;
            
            timer = Stopwatch.StartNew();
            linkedListAddToLast.AddLast('h');
            timeLinkedList = timer.Elapsed.TotalMilliseconds;
            
            Console.WriteLine($"Время добавдение элемента в конец листа\n" +
                              $"Цепь: {timeLinkedList} мс\n" +
                              $"Простой лист: {timeList} мс");
            Console.WriteLine();
        }

        public static void AddValuesToMiddleList(List<char> list, char addingValue, int index)
        {
            for (int i = list.Count; i > index; i--)
            {
                if (i == list.Count)
                    list.Add('a');
                list[i] = list[i-1];
            }
            
            list[index] = addingValue;
        }
    }
}