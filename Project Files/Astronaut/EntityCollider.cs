using Microsoft.Xna.Framework;

namespace Astro {
	abstract class EntityCollider : Collider {
		/// Inherited:
		/// public Transform transform
		
		// common fields
		public Vector2 pivot;

		public EntityCollider(Transform t, Vector2 pivot) : base(t) {
			this.pivot = pivot;
		}

	}
}
