using System;
using System.Collections.Generic;
using System.Globalization;
using Notebook.Part1;
using NUnit.Framework;
using Strings.Task2;

namespace NoteExtensionTests
{
    public class Tests
    {
        public static IEnumerable<TestCaseData> NotesAndStrings
        {
            get
            {
                yield return new TestCaseData(new Note("C# in Depth", "Jon Skeet"), 
                    $"Note record: Jon Skeet, {DateTime.Now.Day.ToString(CultureInfo.CurrentCulture)}/{DateTime.Now.Month.ToString(CultureInfo.CurrentCulture)}, C# in Depth.",
                    $"Note record: {DateTime.Now.Day.ToString(CultureInfo.CurrentCulture)}/{DateTime.Now.Month.ToString(CultureInfo.CurrentCulture)}, C# in Depth.", 
                    $"Note record: Jon Skeet, {DateTime.Now.Day.ToString(CultureInfo.CurrentCulture)}/{DateTime.Now.Month.ToString(CultureInfo.CurrentCulture)}.", 
                    $"Note record: {DateTime.Now.Day.ToString(CultureInfo.CurrentCulture)}/{DateTime.Now.Month.ToString(CultureInfo.CurrentCulture)}.");
                yield return new TestCaseData(new Note("C# 7.0 in a Nutshell", "Joseph Albahari"), 
                    $"Note record: Joseph Albahari, {DateTime.Now.Day.ToString(CultureInfo.CurrentCulture)}/{DateTime.Now.Month.ToString(CultureInfo.CurrentCulture)}, C# 7.0 in a Nutshell.",
                    $"Note record: {DateTime.Now.Day.ToString(CultureInfo.CurrentCulture)}/{DateTime.Now.Month.ToString(CultureInfo.CurrentCulture)}, C# 7.0 in a Nutshell.", 
                    $"Note record: Joseph Albahari, {DateTime.Now.Day.ToString(CultureInfo.CurrentCulture)}/{DateTime.Now.Month.ToString(CultureInfo.CurrentCulture)}.", 
                    $"Note record: {DateTime.Now.Day.ToString(CultureInfo.CurrentCulture)}/{DateTime.Now.Month.ToString(CultureInfo.CurrentCulture)}.");
                yield return new TestCaseData(new Note("Pro C# 7", "Andrew Troelsen"), 
                    $"Note record: Andrew Troelsen, {DateTime.Now.Day.ToString(CultureInfo.CurrentCulture)}/{DateTime.Now.Month.ToString(CultureInfo.CurrentCulture)}, Pro C# 7.",
                    $"Note record: {DateTime.Now.Day.ToString(CultureInfo.CurrentCulture)}/{DateTime.Now.Month.ToString(CultureInfo.CurrentCulture)}, Pro C# 7.", 
                    $"Note record: Andrew Troelsen, {DateTime.Now.Day.ToString(CultureInfo.CurrentCulture)}/{DateTime.Now.Month.ToString(CultureInfo.CurrentCulture)}.", 
                    $"Note record: {DateTime.Now.Day.ToString(CultureInfo.CurrentCulture)}/{DateTime.Now.Month.ToString(CultureInfo.CurrentCulture)}.");
            }
        }

        [Test, TestCaseSource(nameof(NotesAndStrings))]
        public void NoteExtensionTest_WithAllValidParameters(Note note, string noteAsStringADMC, string noteAsStringDMC, string noteAsStringADM, string noteAsStringDM)
        {
            Assert.AreEqual(note.Format("admc"), noteAsStringADMC);
            Assert.AreEqual(note.Format("dmc"), noteAsStringDMC);
            Assert.AreEqual(note.Format("adm"), noteAsStringADM);
            Assert.AreEqual(note.Format("dm"), noteAsStringDM);
        }

        [Test]
        public void NoteExtensionTest_WithInvalidParameter()
        {
            Note note = new Note("aaa", "bbb");
            Assert.Throws<ArgumentException>((() => note.Format("ABCDEF")));
        }

        [Test]
        public void NoteExtensionTest_WithNullNoteParameter()
        {
            Note note = null;
            Assert.Throws<ArgumentNullException>((() => note.Format("adm")));
        }
    }
}