using System;

namespace Astro {
	public static class Debug {


		/// <summary> Prints to the console </summary>
		public static void Log(object obj) {
#if DEBUG
			Console.WriteLine(obj);
#endif
		}
		/// <summary> Prints to the console with "[Error]:" prefacing it </summary>
		public static void ErrorLog(object obj) {
#if DEBUG
			Console.WriteLine("[ERROR]: " + obj.ToString());
#endif
		}
	}
}
