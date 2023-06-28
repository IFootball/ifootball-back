namespace IFootball.Core
{
    using System;
    using System.Security.Cryptography;

    public static class PasswordHasher
    {
        private const int SaltSize = 16; // Tamanho do salt em bytes
        private const int HashSize = 20; // Tamanho do hash em bytes
        private const int Iterations = 10000; // Número de iterações

        public static string HashPassword(string password)
        {
            // Gera um salt aleatório
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            // Aplica o algoritmo PBKDF2 para gerar o hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            // Combina o salt e o hash em um único array
            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            // Converte o array de bytes para uma string no formato Base64
            string hashedPassword = Convert.ToBase64String(hashBytes);

            return hashedPassword;
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Converte a string em base64 de volta para um array de bytes
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            // Obtém o salt do array de bytes
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // Gera um novo hash usando a senha fornecida e o salt extraído
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            // Compara os hashes gerados
            for (int i = 0; i < HashSize; i++)
                if (hashBytes[i + SaltSize] != hash[i]) return false; // Senha incorreta

            return true; // Senha correta
        }
    }
}