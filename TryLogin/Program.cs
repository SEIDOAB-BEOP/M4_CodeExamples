using System;
using System.Security.Cryptography;

namespace TryLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            //const string userPasswordFromDB = "Mupparnasjulsaga";
            //Console.WriteLine(PasswordHashInBase64(userPasswordFromDB));

            const string userNameFromDB = "Mupp";
            const string userPasswordFromDB = "JIDmxAjRu4YHtLqjitxoA8Fn3xGrN/PGpSZ0qZSN64Q=";

            bool loginSuccessful = TryLogin(userNameFromDB, userPasswordFromDB);

            if (loginSuccessful)
                Console.WriteLine("Welcome");
            else
                Console.WriteLine("Login failure");
        }

        #region Hashed password just to demonstrate. In OOP2 we will cover SHA256
        private static string PasswordHashInBase64(string userPasswordFromDB)
        {
            // Compute hash from Password:
            byte[] data = System.Text.Encoding.UTF8.GetBytes(userPasswordFromDB);
            byte[] hash2 = SHA256.Create().ComputeHash(data);
            string strBase64 = Convert.ToBase64String(hash2);
            return strBase64;
        }
        #endregion

        private static bool TryLogin(string userNameFromDB, string userPasswordFromDB)
        {
            bool loginSuccessful = false;
            bool continueAttempts = true;
            int attempts = 0;
            while (continueAttempts && !loginSuccessful && attempts < 3)
            {
                string Password = null;
                string Name = null;
                continueAttempts = UserInput.TryReadString("Enter username:", out Name) &&
                           UserInput.TryReadString("Enter password:", out Password);

                if (!continueAttempts)
                    continue;

                string hashedPassword = PasswordHashInBase64(Password);
                if ((Name == userNameFromDB) && (hashedPassword == userPasswordFromDB))
                {
                    loginSuccessful = true;
                }
                else
                {
                    Console.WriteLine("Wrong name or password. Try again!");
                    attempts++;
                }
            }

            return loginSuccessful;
        }


    }
}
//1.    Make a small Login program that asks a user for a user name and a password. The password
//      should be compared HashCode wise to stored password hash code. If Login 
//      successful write a welcome message
//2.    Extend the program to allow the user 3 login attempts
//3.    Refracture the Login code into a Method - bool TryLogin(string User, string password)
