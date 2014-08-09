using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BulkEnvelopeEditor {
	public partial class MainForm : Form {

		public MainForm() {
			InitializeComponent();
		}

		public void HandleNumericKeyPress(object sender, KeyPressEventArgs e) {
			
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
				e.Handled = true;
			}

		}

		private int? ReadVal(TextBox box) {
			return box.TextLength > 0 ? (int?)int.Parse(box.Text) : null;
		}

		public string USTFile { get; set; }

		private void doItBtn_Click(object sender, EventArgs e) {

			var minLength = int.Parse(minLengthBox.Text);
			var lines = File.ReadAllLines(USTFile, Encoding.GetEncoding("shift_jis"));
			var notesCount = 0;

			var p3 = ReadVal(p3Box);
			var v3 = ReadVal(v3Box);
			var p4 = ReadVal(p4Box);
			var v4 = ReadVal(v4Box);
			var p5 = ReadVal(p5Box);
			var v5 = ReadVal(v5Box);

			var patcher = new FilePatcher();
			lines = patcher.GetLines(lines, minLength, p3, v3, p4, v4, p5, v5, ref notesCount);

			File.WriteAllLines(USTFile, lines, Encoding.GetEncoding("shift_jis"));
			MessageBox.Show(string.Format("Modified envelope for {0} note(s).", notesCount));
			Close();

		}

	}
}
