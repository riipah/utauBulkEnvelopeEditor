using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BulkEnvelopeEditor.Tests.TestData {

	public static class ResourceHelper {

		public static Stream GetFileStream(string fileName) {

			var asm = typeof(ResourceHelper).Assembly;
			var s = asm.GetManifestResourceNames();
			return asm.GetManifestResourceStream(asm.GetName().Name + ".TestData." + fileName);

		}

		public static string[] ReadTextFile(string fileName) {

			using (var stream = GetFileStream(fileName))
			using (var reader = new StreamReader(stream, Encoding.GetEncoding("shift_jis"))) {

				var lines = new List<string>();
				string line;
                while ((line = reader.ReadLine()) != null)
                    lines.Add(line);

				return lines.ToArray();

			}

		}

		public static string[] TestUST() {
			return ReadTextFile("tmp1414.tmp");
		}

	}

}
