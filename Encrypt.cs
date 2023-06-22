namespace encryption
{
    class Encryption
    {
        public static string Encrypt(string plainText)
        {
            char[] plainArray = plainText.ToLower().ToCharArray();

            for (int i = 0; i < plainArray.Length; i++)
            {
                char letter = plainArray[i];

                if (letter != ' ')
                {
                    letter = (char)(letter + 3);
                    if (letter > 'z')
                    {
                        letter = (char)(letter - 26);
                    }
                    else if (letter < 'a')
                    {
                        letter = (char)(letter + 26);
                    }
                    plainArray[i] = letter;
                }
            }
            return new string(plainArray);
        }
    }
}
