namespace LogestGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ask for username
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            string filename = $"{username}.txt";
            int score = 0;

            // Load previous score if exists
            if (File.Exists(filename))
            {
                string saved = File.ReadAllText(filename);

                if (int.TryParse(saved, out int previousScore))
                {
                    score = previousScore;
                    Console.WriteLine($"Welcome back, {username}! Previous score: {score}");
                }
                else
                {
                    Console.WriteLine("Saved file was corrupted. Starting at 0.");
                }
            }
            else
            {
                Console.WriteLine($"Welcome, {username}! Starting new game.");
            }

            Console.WriteLine("Press keys to score points. Press ENTER to finish.");

            // Game loop
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("\nGame Over!");
                    Console.WriteLine($"Score: {score}");
                    break;
                }

                score++;
            }

            // Save score
            File.WriteAllText(filename, score.ToString());

            Console.WriteLine($"Score saved to {filename}.");
        }
    }
}
