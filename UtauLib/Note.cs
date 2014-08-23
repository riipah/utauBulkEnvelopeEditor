using System.Text.RegularExpressions;

namespace UtauLib {

	public class Note {

		public string Envelope {
			get {
				return EnvelopeComponent.Value;
			}
			set {
				EnvelopeComponent = NoteComponent.Create(value, EnvelopeComponent.LineNumber);
			}
		}

		public NoteComponent<string> EnvelopeComponent { get; set; } 

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

		public string Lyric {
			get {
				return LyricComponent.Value;
			}
			set {
				LyricComponent = NoteComponent.Create(value, LyricComponent.LineNumber);
			}
		}

		public NoteComponent<string> LyricComponent { get; set; } 

		/// <summary>
		/// Line number where this note ends, starting from 0!
		/// </summary>
		public int NoteEndLine { get; set; }

		public int StartLine { get; set; }

		public override string ToString() {
			return string.Format("Note '{0}'", Lyric);
		}
	}

	public struct NoteComponent {
		public static NoteComponent<T> Create<T>(T value, int lineNumber) {
			return new NoteComponent<T>(value, lineNumber);
		} 		
	}

	public struct NoteComponent<T> {

		public NoteComponent(T value, int lineNumber)
			: this() {

			Value = value;
			LineNumber = lineNumber;

		} 

		public int LineNumber { get; set; }

		public T Value { get; set; }

	}

}
