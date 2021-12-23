using System;

namespace ViginereCipher
{
    class Program
    {
        static char[,] tabulaRecta;

        static void PrintTabulaRecta(char[,] tabulaRecta)
        {
            string print = "";

            for (int i = 0; i < tabulaRecta.GetLength(0); i++)
            {
                for (int j = 0; j < tabulaRecta.GetLength(1); j++)
                {
                    print += tabulaRecta[i, j];

                }
                Console.WriteLine(print);
                print = "";

            }
        }

        static string Encrypt(string input, string key)
        {
            string encryptedMsg = "";

            string newString = input.ToLower();

            int columns = 26;
            int rows = 26;

            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            tabulaRecta = new char[columns, rows];

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
                }
                offset++;
                count = offset;
            }
            Console.WriteLine(" ");

            PrintTabulaRecta(tabulaRecta);

            Console.WriteLine(" ");

            int keyCount = 0;



            for (int j = 0; j < input.Length; j++)
            {
                char c = newString[j];

                if (!char.IsLetter(c))
                {
                    encryptedMsg += c;
                }
                else
                {
                    int index = (char)(newString[j] - 97);
                    int keyIndex = (char)(key[keyCount] - 97);
                    keyCount++;

                    char encryptedLetter = tabulaRecta[index, keyIndex];

                    encryptedMsg += encryptedLetter;
                }

                if (keyCount >= key.Length)
                {
                    keyCount = 0;
                }
            }

            return encryptedMsg;
        }

        static string Decrypt(string encryptedMsg, string key, char[,] tabulaRecta)
        {
            string decryptedMsg = "";



            //Loop for encryptedMsg.Length

            int keyCount = 0;

            for (int i = 0; i < encryptedMsg.Length; i++)
            {
                char c = encryptedMsg[i];

                if (!char.IsLetter(c))
                {
                    decryptedMsg += c;
                }
                else
                {
                    int keyIndex = (char)(key[keyCount] - 97);
                    int column = FindColumnIndex(keyIndex, encryptedMsg[i], tabulaRecta);
                    decryptedMsg += (char)(column + 'a');
                    keyCount++;

                    if (keyCount >= key.Length)
                    {
                        keyCount = 0;
                    }
                }
              
                
            } 

            return decryptedMsg;
        }

        //We have the row, we have the table, we have the char we are looking for
        //Loop through the table (just the row) and continue looping until table[row, i] == character
        static int FindColumnIndex(int rowIndex, char letter, char[,] tabulaRecta)
        {
            for (int j = 0; j < tabulaRecta.GetLength(1); j++)
            {
                if (letter == tabulaRecta[rowIndex, j])
                {
                    return j;
                }

            }

            return -1;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Give String");
            string input = Console.ReadLine();
            //input = "common sense is not so common";

            string key = "pizza";

            string msg = Encrypt(input, key);

            Console.WriteLine(msg);

            Console.WriteLine(Decrypt(msg, key, tabulaRecta));

        }
    }
}
