using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace Notebook.Part1
{
    public class Note : IEquatable<Note>, IComparable<Note>, IComparable, IFormattable
    {
        /// <summary>Initializes a new instance of the <see cref="Note"/> class.</summary>
        /// <param name="noteText">The note text.</param>
        /// <param name="author">The Author of the note.</param>
        public Note(string noteText, string author)
        {
            this.Author = author;
            this.NoteText = noteText;
            this.NoteDateTime = DateTime.Now;
        }

        public DateTime NoteDateTime { get; private set; }

        public string NoteText { get; private set; }

        public string Author { get; private set; }

        /// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
        /// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return (obj != null) && (this.GetType() == obj.GetType()) && this.Equals(obj as Note);
        }

        /// <summary>Returns a hash code for this instance.</summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return this.NoteDateTime.GetHashCode();
        }

        /// <summary>Changes the note's text and resets its date.</summary>
        /// <param name="newText">The new text.</param>
        public void ChangeNote(string newText)
        {
            this.NoteText = newText;
            this.NoteDateTime = DateTime.Now;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(Note other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (this.NoteText == other.NoteText && this.Author == other.Author)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings:
        /// Value
        /// Meaning
        /// Less than zero
        /// This instance precedes <paramref name="other" /> in the sort order.
        /// Zero
        /// This instance occurs in the same position in the sort order as <paramref name="other" />.
        /// Greater than zero
        /// This instance follows <paramref name="other" /> in the sort order.
        /// </returns>
        public int CompareTo(Note other)
        {
            if (ReferenceEquals(other, null) || this.NoteDateTime > other.NoteDateTime)
            {
                return -1;
            }

            if (this.NoteDateTime == other.NoteDateTime)
            {
                return 0;
            }

            if (this.NoteDateTime < other.NoteDateTime)
            {
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings:
        /// Value
        /// Meaning
        /// Less than zero
        /// This instance precedes <paramref name="obj" /> in the sort order.
        /// Zero
        /// This instance occurs in the same position in the sort order as <paramref name="obj" />.
        /// Greater than zero
        /// This instance follows <paramref name="obj" /> in the sort order.
        /// </returns>
        public int CompareTo(object obj)
        {
            Note other = obj as Note;
            return this.CompareTo(other);
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="string"/> that represents this instance.</returns>
        public override string ToString()
        {
            return this.ToString("ADC", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            StringBuilder noteAsString = new StringBuilder();
            if (string.IsNullOrEmpty(format))
            {
                format = "ADC";
            }

            if (format.Length > 1)
            {
                for (int i = 0; i < format.Length; i++)
                {
                    for (int j = i + 1; j < format.Length; j++)
                    {
                        if (format[i] == format[j])
                        {
                            throw new ArgumentException($"{nameof(format)} contains repeated symbols.");
                        }
                    }
                }
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            string formatString = format.ToUpperInvariant();
            noteAsString.Append("Note record: ");
            for (int i = 0; i < formatString.Length; i++)
            {
                switch (formatString[i])
                {
                    case 'A': // A - Author
                        noteAsString.Append(this.Author);
                        break;
                    case 'D': // D - Date
                        noteAsString.Append(this.NoteDateTime.ToString("d", formatProvider));
                        break;
                    case 'C': // C - Content
                        noteAsString.Append(this.NoteText);
                        break;
                    case 'Y': // Y - Year
                        noteAsString.Append(this.NoteDateTime.Year);
                        break;
                    default:
                        throw new ArgumentException($"Unsupported format: {format}");
                }

                if (i == formatString.Length - 1)
                {
                    noteAsString.Append(".");
                    break;
                }

                noteAsString.Append(", ");
            }

            return noteAsString.ToString();
        }
    }
}
