using System.Collections.Generic;
using System.Linq;

namespace BulkEnvelopeEditor {

	public class FilePatcher {

		public string[] GetLines(string[] linesArr, Note[] notes, int minLength, int? p3, int? v3, int? p4, int? v4, int? p5, int? v5, ref int notesCount) {

			Note previousNote = null;
			var lineOffset = 0;
			var lines = linesArr.ToList();

			foreach (var note in notes) {
				
				// Patch notes preceeding breaths or rests that are longer than the specified length.
				if (previousNote != null && previousNote.Length >= minLength && previousNote.IsSelectedInUtau && !previousNote.IsBreathOrRest && note.IsBreathOrRest) {

					// If the previous note didn't contain Envelope line, create default
					if (string.IsNullOrEmpty(previousNote.Envelope)) {
						previousNote.Envelope = "0,0,0,0,100,100,0"; // No envelope specified, assume default
						previousNote.EnvelopeLineNumber = previousNote.NoteEndLine;
						lines.Insert(previousNote.NoteEndLine + lineOffset, previousNote.Envelope);
						lineOffset++;
					}

					var envelope = previousNote.Envelope;

					// Envelope order seems to be p1,p2,p3,v1,v2,v3,v4,%,p4,p5,v5.
					// Yes, v4 comes before p4 and there's a % sign between v4 and p4.
					// Values after v4 might not exist for all notes.
					var vals = envelope.Split(',');

					var oldP1 = int.Parse(vals[0]);
					var oldP2 = int.Parse(vals[1]);
					var oldP3 = int.Parse(vals[2]);
					var oldV1 = int.Parse(vals[3]);
					var oldV2 = int.Parse(vals[4]);
					var oldV3 = int.Parse(vals[5]);
					var oldV4 = int.Parse(vals[6]);
					int? oldP4 = null;
					int? oldP5 = null;
					int? oldV5 = null;

					if (vals.Length > 8) {
						oldP4 = int.Parse(vals[8]);
					}

					if (vals.Length > 9) {
						oldP5 = int.Parse(vals[9]);						
					}

					if (vals.Length > 10) {
						oldV5 = int.Parse(vals[10]);						
					}

					var envVals = new List<object>(new object[] { oldP1, oldP2, p3 ?? oldP3, oldV1, oldV2, v3 ?? oldV3, v4 ?? oldV4, "%", p4 ?? oldP4, p5 ?? oldP5, v5 ?? oldV5 }).Where(v => v != null).ToArray();

					var newEnv = string.Join(",", envVals);

					var actualLineNumber = previousNote.EnvelopeLineNumber + lineOffset;

					if (lines[actualLineNumber] != "Envelope=" + newEnv) {
						lines[actualLineNumber] = "Envelope=" + newEnv;
						notesCount++;						
					}

				}

				previousNote = note;

			}
			
			return lines.ToArray();

		}

		public string[] GetLines(string[] linesArr, int minLength, int? p3, int? v3, int? p4, int? v4, int? p5, int? v5, ref int notesCount) {
			
			var notes = new NoteReader().ReadNotes(linesArr);
			return GetLines(linesArr, notes, minLength, p3, v3, p4, v4, p5, v5, ref notesCount);

		}

	}

}
