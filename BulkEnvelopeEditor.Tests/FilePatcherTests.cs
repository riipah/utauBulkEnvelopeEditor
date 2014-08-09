using BulkEnvelopeEditor.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BulkEnvelopeEditor.Tests {

	[TestClass]
	public class FilePatcherTests {

		private string[] lines;
		private FilePatcher patcher;

		[TestInitialize]
		public void SetUp() {
			
			lines = ResourceHelper.TestUST();
			patcher = new FilePatcher();

		}

		/// <summary>
		/// Edit envelope param when the note already contains Envelope.
		/// </summary>
		[TestMethod]
		public void EditEnvelope_NoteHasEnvelope() {
			
			var notesCount = 0;

			lines = patcher.GetLines(lines, 0, 666, 666, null, null, null, null, ref notesCount);

			Assert.AreEqual(2, notesCount, "2 notes edited");
			Assert.AreEqual("Envelope=0,100,666,0,100,666,0,%", lines[30], "Envelope was edited for the first note");

		}

		/// <summary>
		/// Edit envelope param when the note does NOT contain Envelope.
		/// </summary>
		[TestMethod]
		public void EditEnvelope_NoteDoesNotHaveEnvelope() {

			var notesCount = 0;
			var lineCount = lines.Length;

			lines = patcher.GetLines(lines, 0, 666, 666, null, null, null, null, ref notesCount);

			Assert.AreEqual("Envelope=0,0,666,0,100,666,0,%", lines[114], "Envelope was edited for the second note");
			Assert.AreEqual(lineCount + 1, lines.Length, "A new line was added");

		}

	}

}
