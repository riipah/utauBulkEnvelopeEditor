using System.Text.RegularExpressions;

namespace BulkEnvelopeEditor {

	public class Note {

		public string Envelope { get; set; }

		public int EnvelopeLineNumber { get; set; }

		public bool IsBreathOrRest {
			get {
				
				var regex = new Regex(@"[Rrx\.]|(breath\d*)|(br?e?\d*)|(inex\d*)|(in\d*)");
				var match = regex.Match(Lyric);
				return (match.Success && match.Value == Lyric);

			}
		}

		public bool IsSelectedInUtau { get; set; }

		public int Length { get; set; }

		public string Lyric { get; set; }

		public int NoteEndLine { get; set; }

	}

}
