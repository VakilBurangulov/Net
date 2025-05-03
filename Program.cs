namespace Net
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText("D:\\Downloads\\input.txt");
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

            var splitChars = new[] { " ", "\n", "\r" };

            var words = noPunctuationText.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
            
            var dict = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (dict.ContainsKey(word.ToUpper()))
                    dict[word.ToUpper()]++;
                
                else
                    dict.Add(word.ToUpper(), 1);
            }

            var top10Words = GetTop10Words(dict);
            var count = 1;

            foreach (var i in top10Words)
            {
                Console.WriteLine($"{count}ое место занимает слово '{i.ToLower()}' с {dict[i]} повторениями");
                count++;
            }
        }

        static string[] GetTop10Words(Dictionary<string, int> dict)
        {
            var top10Words = new string[10];

            var dictClone = new Dictionary<string, int>(dict);

            for (int i = 0; i < top10Words.Length; i++)
            {
                var max = dictClone.MaxBy(kvp => kvp.Value).Key;
                top10Words[i] = max;
                dictClone.Remove(max);
            }
            
            return top10Words;
        }
    }
}