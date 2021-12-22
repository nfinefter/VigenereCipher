using System;

namespace ViginereCipher
{
    class Program
    {
        static string Encrypt(string input, string key)
        {
            string encryptedMsg = "";

            string newString = input.ToLower();

            int columns = 26;
            int rows = 26;

            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            char[,] tabulaRecta = new char[columns, rows];

            int count = 0;

            int offset = 0;

            for (int i = 0; i < alphabet.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    char finalLetter = (char)(count + 97);

                    tabulaRecta[i, j] = finalLetter;

                    count++;

                    if (finalLetter >= 'z')
                    {
                        finalLetter = (char)(96);
                        count = 0;
                    }
                    finalLetter++;
                }
                offset++;
                count = offset;
            }

            int indexCount = 0;
            int keyCount = 0;



                for (int j = 0; j < input.Length; j++)
                {
                if (newString[indexCount] == ' ')
                {
                    //newString[indexCount]
                }
                    int index = (char)(newString[indexCount] - 97);
                    int keyIndex = (char)(key[keyCount] - 97);

                    char encryptedLetter = tabulaRecta[index, keyIndex];

                    encryptedMsg += encryptedLetter;
                    indexCount++;
                
                keyCount++;
                if (keyCount >= key.Length)
                {
                    keyCount = 0;
                }
            }

            return encryptedMsg;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Give a string!");
            string input = Console.ReadLine();
            input = "Common sense is not so common.";
            string key = "pizza";

            Console.WriteLine(Encrypt(input, key));

        }
    }
}
