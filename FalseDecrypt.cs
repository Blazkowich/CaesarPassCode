namespace falsedecryption
{
	public class FalseDecryption
	{
        public static string FalseDecrypt(string cipherText)
        {
            Random rnd = new();
            int randomCipher = rnd.Next(1, 5);
            while (randomCipher == 3)
            {
                randomCipher = rnd.Next(1, 8);
            }

            char[] cipherArray = cipherText.ToLower().ToCharArray();

            for (int i = 0; i < cipherArray.Length; i++)
            {
                char letter = cipherArray[i];
                if (letter != ' ')
                {
                    letter = (char)(letter - randomCipher);
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
