using System.Text;

namespace SellCar.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string Join(this List<string> words)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < words.Count; i++)
            {
                sb.Append($"{i + 1}: {words[i]} ");
            }

            return sb.ToString();
        }
    }
}
