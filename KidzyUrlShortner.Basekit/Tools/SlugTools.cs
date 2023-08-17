using System.Security.Cryptography;

namespace KidzyUrlShortner.Basekit.Tools
{
    public static class SlugTools
    {
        private const string _characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string GenerateRandomSlug()
        {
            int SlugLength = new Random().Next(4,10);
            RandomNumberGenerator RandomGenerator = RandomNumberGenerator.Create();

            char[] result = new char[SlugLength];
            byte[] randomBytes = new byte[SlugLength];

            RandomGenerator.GetBytes(randomBytes);

            for (int i = 0; i < SlugLength; i++)
            {
                int index = randomBytes[i] % _characters.Length;
                result[i] = _characters[index];
            }

            return new string(result);
        }
    }
}