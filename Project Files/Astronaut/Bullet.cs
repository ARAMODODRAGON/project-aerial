using Microsoft.Xna.Framework;

namespace Astro {
	public enum BulletDraw : byte {
		custom = 0,
		circle = 1,
	}

	public enum BulletState : byte {
		nonactive = 0,
		spawning,
		active,
		custom,
		destroying,
	}

	public struct Bullet {
		public float activeTime;
		// used to decide where the bullet becomes active 
		// for example when creating a circle of bullets
		public Vector2 startPos;
		public Vector2 position;
		public Radial direction;
		public float radius; // size of collider and sprite is drawn larger than collider
		public BulletState state;
		public BulletDraw draw;
		public Color color;

		public void Update() {
			switch (state) {
				case BulletState.spawning:
					activeTime += Time.DeltaB;
					// move towards start position by double speed
					position += (position - startPos).GetAsNormal() * (direction.Length * 2f) * Time.DeltaB;
					if (BMath.NearlyEqual(position, startPos, 0.1f)) state = BulletState.active;
					break;
				case BulletState.active:
					activeTime += Time.DeltaB;
					// move in set direction
					position += direction.ToVector2() * Time.DeltaB;
					break;
				case BulletState.destroying:
					activeTime += Time.DeltaB;
					break;
				default: Debug.ErrorLog("We shouldn't be here"); break;
			}
		}
	}
}
