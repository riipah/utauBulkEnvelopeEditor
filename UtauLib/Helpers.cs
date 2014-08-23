using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtauLib
{
	public static class Helpers
	{

		public static Encoding Shift_JIS {
			get {
				return Encoding.GetEncoding("shift_jis");
			}
		}

	}
}
