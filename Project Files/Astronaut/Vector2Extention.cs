using Microsoft.Xna.Framework;

namespace Astro {
	public static class Vector2Extention {
		public static Radial ToRadial(this Vector2 vector) {
			return new Radial(vector);
		}

		public static Vector2 GetAsNormal(this Vector2 vec) {
			float mag = vec.Length();
			return new Vector2(vec.X / mag, vec.Y / mag);
		}
	}
}
