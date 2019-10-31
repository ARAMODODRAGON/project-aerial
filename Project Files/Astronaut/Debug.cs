using System;

namespace Astro {
	static class Debug {


		/// <summary> Prints to the console </summary>
		public static void Log(object obj) {
			Console.WriteLine(obj);
		}
		/// <summary> Prints to the console with "[Error]:" prefacing it </summary>
		public static void ErrorLog(object obj) {
			Console.WriteLine("[ERROR]: " + obj.ToString());
		}
	}
}
