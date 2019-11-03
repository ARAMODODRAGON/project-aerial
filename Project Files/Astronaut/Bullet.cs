using Microsoft.Xna.Framework;

namespace Astro {
	enum BulletLogic : byte {
		none = 0,
		custom = 1,
		linear = 2,
	}

	enum BulletShape : byte {
		custom = 0,
		circle = 1,
	}

	struct Bullet {
		public Vector2 position;
		public Radial direction;
		public float size; // this is used for various things such as the radius of a circle or extents of a box
		public BulletLogic logic;
		public BulletShape shape;
		public Color color;
	}
}
