int userGuess = 0;
Random random = new();
int secretNumber = random.Next(0, 101);
List<int> userGuesses = new();

void GuessPrompt()
{
    Console.WriteLine("\n\t Guess the secret number!");
    Console.Write($"\n\t\tMy guess(attempt {GuessesRemaining(userGuesses.Count)}): ");
    userGuess = Convert.ToInt32(Console.ReadLine());

    if (userGuess == secretNumber)
    {
        Console.WriteLine("\n\tCongratulations, you guessed correctly!");
    }
    else
    {
        if (userGuess < secretNumber)
        {
        Console.WriteLine($"\n\tSorry, your guess was too low. You may try {GuessesRemaining(userGuesses.Count) - 1} more times.");
        userGuesses.Add(userGuess);
        }
        else if (userGuess > secretNumber)
        {
            Console.WriteLine($"\n\tSorry, your guess was too high. You may try {GuessesRemaining(userGuesses.Count) - 1} more times.");
            userGuesses.Add(userGuess);
        }


        if (userGuesses.Count >= 4)
        {
            Console.WriteLine("\n\t\tSorry, you have no tries left!");
            Environment.Exit(0);
        }
        else
        {
            Console.Write("\n\n\tPlease try again...");
            GuessPrompt();
        }

    }

    int GuessesRemaining(int guesses)
    {
        int guessesRemaining = 0;
        if (guesses < 4)
        {
            guessesRemaining = 4 - guesses;
        }
        return guessesRemaining;
    }
}

    GuessPrompt();
