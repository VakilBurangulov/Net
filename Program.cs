class Program
{
    static void Main(string[] args)
    {
        var users = new User[] {
            new User { Login = "Login1", Name = "Name1", IsPremium = true }, 
            new User { Login = "Login2", Name = "Name2", IsPremium = false }, 
            new User { Login = "Login3", Name = "Name3", IsPremium = false } 
        };

        foreach (var user in users)
        {
            if (user.IsPremium)
            {
                Console.WriteLine("Привет, " + user.Name);
            }

            else
            {
                ShowAds();
                Console.WriteLine("Привет, " + user.Name);
            }
        }
    }

    static void ShowAds()
    {
        Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
        // Остановка на 1 с
        Thread.Sleep(1000);

        Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
        // Остановка на 2 с
        Thread.Sleep(2000);

        Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
        // Остановка на 3 с
        Thread.Sleep(3000);
    }

    class User
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public bool IsPremium { get; set; }
    }
}