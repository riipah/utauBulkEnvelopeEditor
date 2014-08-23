using System.Text.RegularExpressions;

namespace UtauLib {

	public class Note {

		public string Envelope { get; set; }

		/// <summary>
		/// Original line number of the Envelope parameter, starting from 0!
		/// </summary>
		public int EnvelopeLineNumber { get; set; }

		/// <summary>
		/// Whether the lyric of this note represents a breath or rest sound.
		/// </summary>
		public bool IsBreathOrRest {
			get {
				
				if (string.IsNullOrEmpty(Lyric))
					return false;

				var regex = new Regex(@"[Rrx\.]|(breath\d*)|(br?e?\d*)|(inex\d*)|(in\d*)");
				var match = regex.Match(Lyric);
				return (match.Success && match.Value == Lyric);

			}
		}

		/// <summary>
		/// Whether the note was selected in UTAU for editing.
		/// 
		/// UTAU automatically includes previous and next notes from the selections.
		/// For those notes, this will be false.
		/// </summary>
		public bool IsSelectedInUtau { get; set; }

		public int Length { get; set; }

		public string Lyric { get; set; }

		/// <summary>
		/// Line number where this note ends, starting from 0!
		/// </summary>
		public int NoteEndLine { get; set; }

		public override string ToString() {
			return string.Format("Note '{0}'", Lyric);
		}
	}

}
