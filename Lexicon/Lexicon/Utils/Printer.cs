﻿namespace Lexicon.Utils
{
    using Lexicon.Models.Contracts;
    using System;

    public static class Printer
    {
        public static void PrintText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(5, 10);
            Console.WriteLine(text);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;

        }

        public static void CleanPrintText(string text, ConsoleColor color)
        {
            Console.Clear();
            PrintText(text, color);

        }

        public static void PrintMenuOption(string textLine,int xCoordinate, int yCoordinate, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(xCoordinate, yCoordinate);
            Console.WriteLine(textLine);
        }

        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }

        public static void PrintPersonalInfo(IPerson person)
        {
            Console.WriteLine($"\n\nFirst name: {person.FirstName}");
            Console.WriteLine($"Last name: {person.LastName}");
            Console.WriteLine($"Age: {person.Age}");
            Console.WriteLine($"Gender: {person.Gender}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var kvp in person.Quiz.Questionnaire)
            {
                Console.WriteLine($"{kvp.Key}\n     {kvp.Value}");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
    }
}
