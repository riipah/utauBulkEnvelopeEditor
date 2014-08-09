using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BulkEnvelopeEditor {

	/// <summary>
	/// Parses a UST file and reads notes from the file.
	/// </summary>
	public class NoteReader {

		// Regex for detecting section title
		private static readonly Regex keyRegex = new Regex(@"(\w+=)");
		private static readonly Regex sectionTitleRegex = new Regex(@"\[#(\w+)\]");

		// Read key=value from a line
		private Tuple<string, string> ReadKeyValue(string line) {
			
			var match = keyRegex.Match(line);

			if (!match.Success)
				return null;

			var keyAndEquals = match.Groups[1].Value;
			var key = keyAndEquals.Substring(0, keyAndEquals.Length - 1).ToLowerInvariant();

			return Tuple.Create(key, line.Substring(key.Length + 1));

		} 

		public Note[] ReadNotes(string[] lines) {
			
			var notes = new List<Note>();
			var currentNote = new Note();

			for (int i = 0; i < lines.Length; ++i) {

				var line = lines[i];

				var titleMatch = sectionTitleRegex.Match(line);

				if (titleMatch.Success) {

					var noteTitle = titleMatch.Groups[1].Value;

					currentNote.NoteEndLine = i - 1;

					currentNote = new Note();
					notes.Add(currentNote);

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

				if (key == "envelope") {
	
					currentNote.Envelope = val;
					currentNote.EnvelopeLineNumber = i;
					
				}

			}

			return notes.ToArray();

		}

	}
}
