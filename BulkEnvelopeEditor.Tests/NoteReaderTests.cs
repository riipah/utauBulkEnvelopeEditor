using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulkEnvelopeEditor.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtauLib;

namespace BulkEnvelopeEditor.Tests {

	[TestClass]
	public class NoteReaderTests {

		private void AssertNote(Note note, string lyric, int length, bool isBreath, int noteEndLine, string envelope = null, int? envelopeLinNum = null, bool testEnvelope = false) {
			
			Assert.AreEqual(lyric, note.Lyric, "Lyric");
			Assert.AreEqual(length, note.Length, "Length");
			Assert.AreEqual(isBreath, note.IsBreathOrRest, "IsBreathOrRest");
			Assert.AreEqual(noteEndLine, note.NoteEndLine, "NoteEndLine");

			if (testEnvelope) {
				Assert.AreEqual(envelope, note.Envelope, "Envelope");
				if (envelopeLinNum.HasValue)
					Assert.AreEqual(envelopeLinNum, note.EnvelopeComponent.LineNumber, "EnvelopeLineNumber");
			}

		}

		private string[] lines;
		private NoteReader reader;

		[TestInitialize]
		public void SetUp() {
			
			lines = ResourceHelper.TestUST();
			reader = new NoteReader();

		}

		[TestMethod]
		public void ReadNotes() {
		
			var notes = reader.ReadNotes(lines);

			Assert.AreEqual(12, notes.Length, "12 notes in the file");
			
			var firstEditableNote = notes[3];
			AssertNote(firstEditableNote, "e", 480, false, 34, "0,100,35,0,100,100,0", 30, true);

			var firstRest = notes[4];
			AssertNote(firstRest, "R", 240, true, 45);

			var secondEditableNote = notes[9];
			AssertNote(secondEditableNote, "te", 480, false, 113, null, null, true); // No envelope

		}

	}

}
