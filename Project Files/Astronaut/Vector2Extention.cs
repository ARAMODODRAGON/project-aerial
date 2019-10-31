using Microsoft.Xna.Framework;

namespace Astro {
	static class Vector2Extention {
		public static Radial ToRadial(this Vector2 vector) {
			return new Radial(vector);
		}
	}
}
