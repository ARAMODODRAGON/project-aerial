using Microsoft.Xna.Framework;

namespace Astro {
	public class Transform {
		// reference to entity
		public Entity entity { get; private set; }

		// world space data
		public Vector2 position;
		public Vector2 velocity;
		public Vector2 scale;
		public float RotInDeg;
		public float RotInRad {
			get => RotInDeg * BMath.DEGTORAD;
			set => RotInDeg = value * BMath.RADTODEG;
		}

		public Transform(Entity e) {
			// set entity
			entity = e;

			// set world space data
			position = Vector2.Zero;
			velocity = Vector2.Zero;
			scale = Vector2.Zero;
			RotInDeg = 0f;
		}
	}
}
