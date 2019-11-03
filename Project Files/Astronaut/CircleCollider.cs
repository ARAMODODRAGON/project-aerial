using Microsoft.Xna.Framework;

namespace Astro {
	class CircleCollider : EntityCollider {
		/// Inherited:
		/// public Transform transform
		/// public Vector2 pivot

		// fields
		public float radius;

		public CircleCollider(Transform t, Vector2 pivot, float radius) : base(t, pivot) {
			this.radius = radius;
		}

	}
}
