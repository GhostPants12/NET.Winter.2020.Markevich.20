using System;
using System.Linq;
using System.Text;

namespace StringExtension
{
    /// <summary>
    /// StringConverter.
    /// </summary>
    public static class StringConverter
    {
        /// <summary>Converts the specified source by placing its odd elements to the beginning of the string and even elements to the end.</summary>
        /// <param name="source">The source.</param>
        /// <param name="count">The count.</param>
        /// <returns>Converted string.</returns>
        /// <exception cref="ArgumentNullException">source is null.</exception>
        /// <exception cref="ArgumentException">source - source is empty or source is made up of control symbols and spaces.<br />count - count is less or equal to zero.</exception>
        public static string Convert(string source, int count)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} is null.");
            }

            if (source.Length == 0 || source.All(c => char.IsControl(c) || char.IsSeparator(c)))
            {
                throw new ArgumentException($"{nameof(source)} is incorrect.");
            }

            if (count <= 0)
            {
                throw new ArgumentException($"{nameof(count)} is incorrect.");
            }

            StringBuilder sb = new StringBuilder(source);
            StringBuilder localStringBuilder = new StringBuilder(source);
            StringBuilder oddElements = new StringBuilder(source.Length % 2 == 0 ? source.Length / 2 : (source.Length / 2) + 1);
            StringBuilder evenElements = new StringBuilder(source.Length / 2);
            int repeatIteration = 0;
            for (int i = 0; i < count; i++)
            {
                Iterate(localStringBuilder);
                repeatIteration++;
                if (localStringBuilder.Equals(sb))
                {
                    for (int k = 0; k < count % repeatIteration; k++)
                    {
                        Iterate(sb);
                    }

                    return sb.ToString();
                }
            }

            return localStringBuilder.ToString();

            void Iterate(StringBuilder stringBuilder)
            {
                for (int j = 0; j < stringBuilder.Length; j++)
                {
                    if ((j + 1) % 2 == 1)
                    {
                        oddElements.Append(stringBuilder[j]);
                    }
                    else
                    {
                        evenElements.Append(stringBuilder[j]);
                    }
                }

                stringBuilder.Clear();
                stringBuilder.Append(oddElements);
                stringBuilder.Append(evenElements);
                oddElements.Clear();
                evenElements.Clear();
            }
        }
    }
}