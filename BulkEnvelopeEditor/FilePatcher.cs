using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BulkEnvelopeEditor {

	public class FilePatcher {

		// Regex for detecting section title
		private static readonly Regex sectionTitleRegex = new Regex(@"\[#(\w+)\]");
		private static readonly Regex keyRegex = new Regex(@"(\w+=)");

		// Read key=value from a line
		private Tuple<string, string> ReadKeyValue(string line) {
			
			var match = keyRegex.Match(line);

			if (!match.Success)
				return null;

			var keyAndEquals = match.Groups[1].Value;
			var key = keyAndEquals.Substring(0, keyAndEquals.Length - 1).ToLowerInvariant();

			return Tuple.Create(key, line.Substring(key.Length + 1));

		} 

		public string[] GetLines(string[] lines, int minLength, int? p3, int? v3, int? p4, int? v4, int? p5, int? v5, ref int notesCount) {
			
			var previousNote = new Note();
			var currentNote = new Note();

			for (int i = 0; i < lines.Length; ++i) {

				var line = lines[i];

				var titleMatch = sectionTitleRegex.Match(line);

				if (titleMatch.Success) {

					var noteTitle = titleMatch.Groups[1].Value;

					previousNote = currentNote;
					previousNote.NoteEndLine = i - 1;

					currentNote = new Note();

					currentNote.IsSelectedInUtau = 
						!noteTitle.Equals("version", StringComparison.InvariantCultureIgnoreCase) && 
						!noteTitle.Equals("setting", StringComparison.InvariantCultureIgnoreCase) && 
						!noteTitle.Equals("prev", StringComparison.InvariantCultureIgnoreCase) && 
						!noteTitle.Equals("next", StringComparison.InvariantCultureIgnoreCase);

				}
					
				var keyValuePair = ReadKeyValue(line);

				if (keyValuePair == null)
					continue;

				var key = keyValuePair.Item1;
				var val = keyValuePair.Item2;

				if (key == "lyric") {

					currentNote.Lyric = val;

				}

				if (key == "length") {

					currentNote.Length = int.Parse(val);

				}

				/*if (line.ToLowerInvariant().StartsWith("lyric=")) {
				
					MessageBox.Show(line);

				}*/

				if (key == "envelope") {
	
					currentNote.Envelope = val;
					currentNote.EnvelopeLineNumber = i;
					
				}
				
				if (previousNote.Length >= minLength && previousNote.IsSelectedInUtau && currentNote.IsBreathOrRest) {

					// If the previous note didn't contain Envelope line, create default
					if (string.IsNullOrEmpty(previousNote.Envelope)) {
						previousNote.Envelope = "0,0,0,0,100,100,0"; // No envelope specified, assume default
						previousNote.EnvelopeLineNumber = previousNote.NoteEndLine;
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

					if (lines[previousNote.EnvelopeLineNumber] != "Envelope=" + newEnv) {
						lines[previousNote.EnvelopeLineNumber] = "Envelope=" + newEnv;
						notesCount++;						
					}

				}

			}
			
			return lines;

		}

	}

}
