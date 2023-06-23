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
        static string PassCode;

        public static void EnterInConsole()
        {

            bool isValid = false;
            Console.WriteLine("Welcome. Choose Option:");
            do
            {
                Console.WriteLine();
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
                                Console.WriteLine("Write In Document");
                                AllowedEncrypt();
                                break;
                            case 2:
                                Console.WriteLine("Read From Document");
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
            Console.WriteLine("Enter Passcode:");
            PassCode = Console.ReadLine();
            Console.WriteLine("Enter Text:");
            string SecretText = Console.ReadLine();
            Console.WriteLine(Display.DisplayEncryptDoc(SecretText, fileDirectory));

        }

        public static void AllowedDecrypt()
        {
            Console.WriteLine("Enter PassCode For Decrypt:");
            string PassCodeDecrypt = Console.ReadLine();

            if (PassCodeDecrypt.ToLower() == PassCode.ToLower())
            {
                Console.WriteLine(Display.DisplayDecryptionDoc(fileDirectory));
            }
            else
            {
                Console.WriteLine(Display.DisplayFalseDecryptionDoc(fileDirectory));
            }
        }
    }
    class Display
    {
        public static string DisplayEncrypted(string plaintxt)
        {
            foreach (var item in plaintxt)
            {
                return item.ToString();
            }
            string encryptedText = Encryption.Encrypt(plaintxt);
            return encryptedText;
        }


        public static string DisplayDecrypted(string cipherText)
        {
            foreach (var item in cipherText)
            {
                return item.ToString();
            }
            var decryptedText = Decryption.Decrypt(cipherText);
            return decryptedText;
        }

       
        public static string DisplayEncryptDoc(string text, string directory)
        {
            string encryptedText = Encryption.Encrypt(text);
            using (StreamWriter sw = new StreamWriter(directory))
            {
                sw.WriteLine(encryptedText);
            }
            
            using (StreamReader sr = new StreamReader(directory))
            {
                return $"\nEncrypted Text:\n{sr.ReadToEnd()}";
            }
        }

        public static string DisplayDecryptionDoc(string directory)
        {
            StreamReader sr = new StreamReader(directory);
            string decryptRead = sr.ReadLine();
            string decryptedText = Decryption.Decrypt(decryptRead);
            return $"\nDecrypted Info:\n{decryptedText}";
        }

        public static string DisplayFalseDecryptionDoc(string directory)
        {
            StreamReader sr = new StreamReader(directory);
            string decryptRead = sr.ReadLine();
            string decryptedText = FalseDecryption.FalseDecrypt(decryptRead);
            return $"\nDecrypted Info:\n{decryptedText}";

        }
    }
}
