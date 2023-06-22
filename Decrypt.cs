namespace decryption
{
    class Decryption
    {
        public static string Decrypt(string cipherText)
        {
            char[] cipherArray = cipherText.ToLower().ToCharArray();

            for (int i = 0; i < cipherArray.Length; i++)
            {
                char letter = cipherArray[i];
                if (letter != ' ')
                {
                    letter = (char)(letter - 3);
                    if (letter > 'z')
                    {
                        letter = (char)(letter - 26);
                    }
                    else if (letter < 'a')
                    {
                        letter = (char)(letter + 26);
                    }
                    cipherArray[i] = letter;
                }
            }
            return new string(cipherArray);
        }
    }
}
