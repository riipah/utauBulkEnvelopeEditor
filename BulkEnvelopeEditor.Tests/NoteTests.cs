using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BulkEnvelopeEditor.Tests {

	[TestClass]
	public class NoteTests {

		public string[] processSounds = { "b", "br", "br6", "br666", "in", "inex", ".", "x" };
		public string[] skipSounds = { "", "ba", "mi", "ま", "brederp", "brea", "i", "xyz", "xx" };

		private bool IsBreath(string lyric) {
			
			var note = new Note { Lyric = lyric };
			return note.IsBreathOrRest;

		}

		[TestMethod]
		public void TestValidSounds() {

			foreach (var validSound in processSounds) {
				Assert.IsTrue(IsBreath(validSound), validSound);
			}

		}

		[TestMethod]
		public void TestSkipSounds() {

			foreach (var skipSound in skipSounds) {
				Assert.IsFalse(IsBreath(skipSound), skipSound);
			}

		}

	}
}
