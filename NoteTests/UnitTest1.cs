using System;
using System.Collections.Generic;
using System.Globalization;
using Notebook.Part1;
using NUnit.Framework;

namespace NoteTests
{
    [TestFixture]
    public class Tests
    {
        public static IEnumerable<TestCaseData> NotesAndStrings
        {
            get
            {
                yield return  new TestCaseData(new Note("C# in Depth", "Jon Skeet"), $"Note record: Jon Skeet, {DateTime.Now.ToString("d", CultureInfo.CurrentCulture)}, C# in Depth.", 
                    $"Note record: Jon Skeet, C# in Depth, {DateTime.Now.Year.ToString(CultureInfo.CurrentCulture)}.", $"Note record: Jon Skeet, {DateTime.Now.Year.ToString(CultureInfo.CurrentCulture)}.", $"Note record: C# in Depth.");
                yield return new TestCaseData(new Note("C# 7.0 in a Nutshell", "Joseph Albahari"), $"Note record: Joseph Albahari, {DateTime.Now.ToString("d", CultureInfo.CurrentCulture)}, C# 7.0 in a Nutshell.",
                    $"Note record: Joseph Albahari, C# 7.0 in a Nutshell, {DateTime.Now.Year.ToString(CultureInfo.CurrentCulture)}.", $"Note record: Joseph Albahari, {DateTime.Now.Year.ToString(CultureInfo.CurrentCulture)}.", $"Note record: C# 7.0 in a Nutshell.");
                yield return new TestCaseData(new Note("Pro C# 7", "Andrew Troelsen"), $"Note record: Andrew Troelsen, {DateTime.Now.ToString("d", CultureInfo.CurrentCulture)}, Pro C# 7.",
                    $"Note record: Andrew Troelsen, Pro C# 7, {DateTime.Now.Year.ToString(CultureInfo.CurrentCulture)}.", $"Note record: Andrew Troelsen, {DateTime.Now.Year.ToString(CultureInfo.CurrentCulture)}.", $"Note record: Pro C# 7.");
            }
        }

        [Test, TestCaseSource(nameof(NotesAndStrings))]
        public void NoteToStringTest_WithAllValidParameters(Note note, string noteAsStringADC, string noteAsStringACY, string noteAsStringAY, string noteAsStringC)
        {
            Assert.AreEqual(note.ToString(null), noteAsStringADC);
            Assert.AreEqual(note.ToString("ADC"), noteAsStringADC);
            Assert.AreEqual(note.ToString("ACY"), noteAsStringACY);
            Assert.AreEqual(note.ToString("AY"), noteAsStringAY);
            Assert.AreEqual(note.ToString("C"), noteAsStringC);
        }

        [Test]
        public void NoteToStringTest_WithRepeatedSymbolsParameter()
        {
            Note note = new Note("aaa", "bbb");
            Assert.Throws<ArgumentException>(() => note.ToString("aa"));
        }

        [Test]
        public void NoteToStringTest_WithInvalidParameter()
        {
            Note note = new Note("aaa", "bbb");
            Assert.Throws<ArgumentException>(() => note.ToString("abcde"));
        }
    }
}