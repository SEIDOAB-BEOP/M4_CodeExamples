using System;

namespace DaysOfAge
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!UserInput.TryReadDateTime("Enter your birthdate.", out DateTime BDate))
                return;

            var DaysOfAge = DateTime.Today - BDate;
            Console.WriteLine($"Hello you are {DaysOfAge.Days:N0} old!");
        }
    }
}
