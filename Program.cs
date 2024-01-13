Random random = new();
int secretNumber = random.Next(0, 101);
List<int> userGuesses = new();
int difficulty = 0;
int cheater = int.MaxValue;

void GuessPrompt()
{
    Console.WriteLine("\n\t Guess the secret number!");

    Console.Write($"\n\t\tMy guess: ");
    int userGuess = Convert.ToInt32(Console.ReadLine());

    if (userGuess == secretNumber)
    {
        Console.WriteLine("\n\tCongratulations, you guessed correctly!");
    }
    else
    {
        if (difficulty == cheater)
        {
            Console.WriteLine($"\n\tSorry, your guess of {userGuess} was {HighOrLow(userGuess, secretNumber)}. You may try {GuessesRemaining(userGuesses.Count) - 1} more times.");
            GuessPrompt();
        }
        else
        {
            Console.WriteLine($"\n\tSorry, your guess of {userGuess} was {HighOrLow(userGuess, secretNumber)}. You may try {GuessesRemaining(userGuesses.Count) - 1} more times.");
            userGuesses.Add(userGuess);
            if (userGuesses.Count >= difficulty)
            {
                Console.WriteLine("\n\tSorry, you are out of guesses!");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("\n\tPlease try again.");
                GuessPrompt();
            }
        }

    }

    string HighOrLow(int guess, int number)
    {
        string result = "";

        if (guess > number)
        {
            result = "too high";
        }
        else if (guess < number)
        {
            result = "too low";
        }
        return result;
    }

    int GuessesRemaining(int guesses)
    {
        int guessesRemaining = 0;
        if (guesses < difficulty)
        {
            guessesRemaining = difficulty - guesses;
        }
        return guessesRemaining;
    }
}

void DifficultyPrompt()
{
    Console.WriteLine("\n\t\tPlease choose a difficulty!");
    Console.WriteLine("\n\t1. Easy - You have 8 guesses.");
    Console.WriteLine("\n\t2. Medium - You have 6 guesses.");
    Console.WriteLine("\n\t3. Hard - You have 4 guesses.");
    Console.WriteLine("\n\t4. Cheater - You have a ridiculous number of guesses");
    Console.Write("\n\n\t\tUser choice: ");
    int difficultyChoice = Convert.ToInt32(Console.ReadLine());

    switch (difficultyChoice)
    {
        case 1:
            difficulty = 8;
            break;

        case 2:
            difficulty = 6;
            break;

        case 3:
            difficulty = 4;
            break;

        case 4:
            difficulty = cheater;
            break;

        default:
            Console.WriteLine("That's not an option, please try again!");
            DifficultyPrompt();
            break;
    }
}

    DifficultyPrompt();
    GuessPrompt();