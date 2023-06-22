using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using encryption;
using decryption;
using falsedecryption;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace displayInputOutput
{
    class ConsoleEnter
    {
        static string fileDirectory = @"/Users/otar/Desktop/Person/cipher.txt";

        public static void EnterInConsole()
        {

            bool isValid = false;
            Console.WriteLine("Welcome. Choose Option:");
            do
            {
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Read");
                Console.WriteLine("3. Exit");

                if (int.TryParse(Console.ReadLine(), out int choose))
                {

                    if (choose > 0 && choose < 4)
                    {
                        switch (choose)
                        {
                            case 1:
                                Console.WriteLine("Write In Document\nEnter PassCode");
                                AllowedEncrypt();
                                break;
                            case 2:
                                Console.WriteLine("Read From Document\nEnter Passcode");
                                AllowedDecrypt();
                                break;
                            case 3:
                                Console.WriteLine("Goodbye 007");
                                isValid = true;
                                Environment.Exit(0);
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please Choose From 1 - 3.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                   
                }
            } while (!isValid);
        }
        public static void AllowedEncrypt()
        {
            string PassCode = Console.ReadLine();

            if (PassCode.ToLower() == "secret")
            {
                string SecretText = Console.ReadLine();
                Display.DisplayEncryptDoc(SecretText, fileDirectory);
            }
            else
            {
                Console.WriteLine("Passcode is Wrong. Try Again.");
            }

        }

        public static void AllowedDecrypt()
        {
            string PassCode = Console.ReadLine();

            if (PassCode.ToLower() == "secret")
            {
                Display.DisplayDecryptionDoc(fileDirectory);
            }
            else
            {
                Display.DisplayFalseDecryptionDoc(fileDirectory);
            }
        }
    }
    class Display
    {
        #region Display From Console
        public static void DisplayEncrypted(string plaintxt)
        {
            Console.WriteLine("| Encryption |\nPlain Text: ");
            foreach (var item in plaintxt)
            {
                Console.Write(item);
            }
            Console.WriteLine("\nCipher Text: ");

            string encryptedText = Encryption.Encrypt(plaintxt);
            Console.WriteLine(encryptedText);
            Console.WriteLine("\n| Encryption Is Done. |\n");
        }


        public static void DisplayDecrypted(string cipherText)
        {
            Console.WriteLine("| Decryption |\nPlain Text: ");
            foreach (var item in cipherText)
            {
                Console.Write(item);
            }
            Console.WriteLine("\nCipher Text: ");
            var decryptedText = Decryption.Decrypt(cipherText);
            Console.WriteLine(decryptedText);
            Console.WriteLine("\n| Decryption Is Done. |");
        }
        #endregion

       
        public static void DisplayEncryptDoc(string text, string directory)
        {
            string encryptedText = Encryption.Encrypt(text);
            using (StreamWriter sw = new StreamWriter(directory))
            {
                sw.WriteLine(encryptedText);
            }

            Console.WriteLine($"Input Text:\n{text}");
            Console.WriteLine();
            using (StreamReader sr = new StreamReader(directory))
            {
                Console.WriteLine($"Encrypted Text:\n{sr.ReadToEnd()}");
            }
            Console.WriteLine();
        }

        public static void DisplayDecryptionDoc(string directory)
        {
            StreamReader sr = new StreamReader(directory);
            string decryptRead = sr.ReadLine();
            string decryptedText = Decryption.Decrypt(decryptRead);
            Console.WriteLine();
            Console.WriteLine($"Decrypted Info:\n{decryptedText}");
        }

        public static void DisplayFalseDecryptionDoc(string directory)
        {
            StreamReader sr = new StreamReader(directory);
            string decryptRead = sr.ReadLine();
            string decryptedText = FalseDecryption.FalseDecrypt(decryptRead);
            Console.WriteLine();
            Console.WriteLine($"Decrypted Info:\n{decryptedText}");

        }
    }
}
