using ITrnstn3;
using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    static void Main(string[] args)
    {
        if (args.Length <= 1 || args.Length % 2 == 0 || args.Length != args.Distinct().Count())
        {
            Console.WriteLine("Please input correct moves");
            return;
        }

        Play(args);
    }

    public static void Play(string[] args)
    {
        SecretKey secretKey = new SecretKey();

        List<string> moveOptions = PrintMenu(args);

        int compMove = ComputerChooseMove(moveOptions);

        Hmac hmac = new Hmac(secretKey);
        Console.WriteLine($"HMAC: {hmac.GetHmac(args[compMove - 1])}");

        int userMove = UserChooseMove(args);

        if (userMove == 0)
        {
            Console.WriteLine("\nGoodbye!");
        }
        else
        {
            Console.WriteLine($"({args[Convert.ToInt32(userMove) - 1]})");

            FightClub fightClub = new FightClub(userMove, compMove, args);
            fightClub.Fight(secretKey);
        }
    }

    private static void PrintHelpTable(string[] args)
    {
        HelpTable helpTable = new HelpTable(args);
        helpTable.Print();
    }

    private static List<string> PrintMenu(string[] args)
    {
        List<string> moveOptions = new List<string>();

        Console.WriteLine($"Menu:\n0 - exit");
        moveOptions.Add("0");

        for (int i = 0; i < args.Length; i++)
        {
            Console.WriteLine($"{i + 1} - {args[i]}");
            moveOptions.Add((i + 1).ToString());
        }

        Console.WriteLine($"? - help\n");
        moveOptions.Add("?");

        return moveOptions;
    }

    private static bool IsInputValid(string input, string[] args)
    {
        if (string.IsNullOrWhiteSpace(input) || !Char.IsDigit(Convert.ToChar(input[0])) || Convert.ToInt32(input) > args.Length || Convert.ToInt32(input) < 0)
        {
            if (input == "?")
            {
                PrintHelpTable(args);
            }

            return false;
        }

        return true;
    }

    private static int UserChooseMove(string[] args)
    {
        Console.Write("Your move: ");

        var userInput = Console.ReadLine();

        while (!IsInputValid(userInput, args))
        {
            Console.Write("Please choose your move from menu options\n\nYour move: ");
            userInput = Console.ReadLine();
        }

        return Convert.ToInt32(userInput);
    }

    private static int ComputerChooseMove(List<string> moveOptions)
    {
        Random rnd = new Random();
        int compMove = rnd.Next(Convert.ToInt32(moveOptions[1]), moveOptions.Count - 1);

        return Convert.ToInt32(compMove);
    }
}