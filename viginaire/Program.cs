using System;

namespace viginaire
{
    class Program
    {
        private static string EnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string FillString(int length, string key)
        {
            string filled_key = key;
            int len = key.Length;
            if (len >= length)
            {
                return key;
            }
            filled_key += key;

            for (; len < length; len += key.Length)
            {
                if (len +key.Length >= length)
                {
                    break;
                }
                for (int i = 0; i < ((len + key.Length) - length - 1); i++)
                {
                    filled_key += key[i];
                }
            }
            return filled_key;
        }
        
        public static string Encrypt(string input, string key)
        {
            input = input.ToUpper();
            string encrypted_data = "";
            string filled_key = FillString(input.Length, key);
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsLetter(input[i]))
                {
                    encrypted_data += input[i];
                    continue;
                }
                int c = (input[i] + filled_key[i]) % 26;
                encrypted_data += EnglishAlphabet[c];
            }
            return encrypted_data;
        }
        public static string Decrypt(string input, string key)
        {
            input = input.ToUpper();
            string decrypted_data = "";
            string filled_key = FillString(input.Length, key);
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsLetter(input[i]))
                {
                    decrypted_data += input[i];
                    continue;
                }
                int c = (input[i] - filled_key[i] + 26) % 26;
                decrypted_data += EnglishAlphabet[c];
            }
            return decrypted_data;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку: ");
            string input = Console.ReadLine();
            Console.Write("Ключ: ");
            string key = Console.ReadLine();
            Console.WriteLine();
            string encrypted_input = Encrypt(input, key);
            Console.WriteLine($"Вывод зашифрованного: {encrypted_input}");
            string decrypted_input = Decrypt(encrypted_input, key);
            Console.WriteLine($"Вывод расшифровки: {decrypted_input}");
            Console.WriteLine();
        }
    }
}
