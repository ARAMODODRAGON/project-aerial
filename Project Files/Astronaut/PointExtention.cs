using Microsoft.Xna.Framework;

namespace Astro {
	public static class PointExtention {
		public static Vector3 ToVector3(this Point point) {
			return new Vector3(point.X, point.Y, 0f);
		}
	}
}
