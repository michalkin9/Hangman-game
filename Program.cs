using System;
using System.Linq;

class MainClass
{
    public static void Main(string[] args)
    {

        Console.WriteLine("Let's play Hangman!");

        String secretWord = selectAWord();
        secretWord = secretWord.ToUpper();


        int lives = 5;
        int counter = -1;
        int wordLength = secretWord.Length;
        char[] secretArray = secretWord.ToCharArray();
        char[] printArray = new char[wordLength];
        char[] guessedLetters = new char[26];
        int numberStore = 0;
        bool victory = false;

        //A print that represents the amount of letters in a word
        foreach (char letter in printArray)
        {
            counter++;
            printArray[counter] = '-';
        }

        //As long as the amount of guesswork remains greater than 1, keep guessing
        while (lives > 1)
        {
            counter = -1;
            string printProgress = String.Concat(printArray);
            bool letterFound = false;
            int multiples = 0;

            //if you guessed the word thaen we won. => victory equals true.
            if (printProgress == secretWord)
            {
                victory = true;
                break;
            }

            //if life more then one, keep guessing and pring hoe many lives left.
            if (lives > 1)
            {
                Console.WriteLine("You have {0} lives!", lives);
            }
            else
            {
                Console.WriteLine("You only have {0} life left!!", lives);
            }


            Console.WriteLine("current progress: " + printProgress);
            Console.Write("\n\n\n");
            Console.Write("Guess a letter: ");
            string playerGuess = Console.ReadLine();

            //test to make sure a single letter
            bool guessTest = playerGuess.All(Char.IsLetter);

            //if the guess in wrong format. then guess again.
            while (guessTest == false || playerGuess.Length != 1)
            {
                Console.WriteLine("Please enter only a single letter!");
                Console.Write("Guess a letter: ");
                playerGuess = Console.ReadLine();
                guessTest = playerGuess.All(Char.IsLetter);
            }

            playerGuess = playerGuess.ToUpper();
            char playerChar = Convert.ToChar(playerGuess);

            if (guessedLetters.Contains(playerChar) == false)
            {

                guessedLetters[numberStore] = playerChar;
                numberStore++;


                //adding the guessed char to the array we print for the player.
                foreach (char letter in secretArray)
                {
                    counter++;
                    if (letter == playerChar)
                    {
                        printArray[counter] = playerChar;
                        letterFound = true;
                        multiples++;
                    }

                }

                if (letterFound)
                {
                    Console.WriteLine("Found {0} letter {1}!", multiples, playerChar);
                }
                else
                {
                    Console.WriteLine("No letter {0}!", playerChar);
                    lives--;
                }
                Console.WriteLine(hangman(lives));
            }
            else
            {
                Console.WriteLine("You already guessed {0}!!", playerChar);
            }


        }

        
        //if you won print your winning status
        if (victory)
        {

            Console.WriteLine("\n\nThe word was: {0}", secretWord);
            Console.WriteLine("\n\nYOU WIN!!!!!!!!!!!");
            Console.WriteLine("\n\nwrite EXIT to quit");

        }
        else
        //print that you lost in this game
        {
            Console.WriteLine("\n\nThe word was: {0}", secretWord);
            Console.WriteLine("\n\nGAME OVER");
            Console.WriteLine("\n\nwrite EXIT to quit");

        }

        while(Console.ReadLine() != "exit")
        {
            Console.WriteLine("write exit to quit");

        }



    }

    //choosing the secret word randomly from a list of words
    private static string selectAWord()
    {
        string[] words = { "admit", "adult" , "affect","after" ,"again",
                            "against","baby", "back", "bad", "bag", "bank", "bar" ,
                            "company","computer", "continue", "create", "degree", "drug", "enter",
                            "evening","event", "father", "find", "former", "full", "growth",
                             "hold","husband", "inside", "involve", "keep", "kind", "lead","list"};

        Random random = new Random();
        int randomIndex = random.Next(0, words.Length);
        string secretWord = words[randomIndex];

        return secretWord;
    }

    private static string hangman(int livesLeft)
    {
        //simple function to print out the hangman drawing

        string drawHangman = "";

        if (livesLeft < 5)
        {
            drawHangman += "--------\n";
        }

        if (livesLeft < 4)
        {
            drawHangman += "       |\n";
        }

        if (livesLeft < 3)
        {
            drawHangman += "       O\n";
        }

        if (livesLeft < 2)
        {
            drawHangman += "      /|\\ \n";
        }

        if (livesLeft == 1)
        {
            drawHangman += "      / \\ \n";
        }

        return drawHangman;

    }




}