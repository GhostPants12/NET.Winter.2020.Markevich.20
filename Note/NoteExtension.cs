using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Notebook.Part1;

namespace Strings.Task2
{
    public static class NoteExtension
    {
        public static string Format(this Note note, string format, IFormatProvider formatProvider)
        {
            if (note is null)
            {
                throw new ArgumentNullException($"{nameof(note)} is null.");
            }

            if (string.IsNullOrEmpty(format))
            {
                return note.ToString("ADC", formatProvider);
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            string formatString = format.ToUpperInvariant();
            switch (formatString)
            {
                case "ADMC": // Author, Day, Month, Content
                    return "Note record: " + note.Author + ", " + note.NoteDateTime.Day.ToString(formatProvider) + "/" +
                           note.NoteDateTime.Month.ToString(formatProvider) + ", " + note.NoteText + ".";
                case "DMC":
                    return "Note record: " + note.NoteDateTime.Day.ToString(formatProvider) + "/" +
                           note.NoteDateTime.Month.ToString(formatProvider) + ", " + note.NoteText + ".";
                case "ADM":
                    return "Note record: " + note.Author + ", " + note.NoteDateTime.Day.ToString(formatProvider) + "/" +
                           note.NoteDateTime.Month.ToString(formatProvider) + ".";
                case "DM":
                    return "Note record: " + note.NoteDateTime.Day.ToString(formatProvider) + "/" +
                           note.NoteDateTime.Month.ToString(formatProvider) + ".";
                default:
                    throw new ArgumentException($"Unsupported format: {format}");
            }
        }

        public static string Format(this Note note, string format)
        {
            return note.Format(format, CultureInfo.CurrentCulture);
        }
    }
}
