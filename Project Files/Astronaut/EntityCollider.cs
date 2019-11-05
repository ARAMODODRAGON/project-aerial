using Microsoft.Xna.Framework;

namespace Astro {
	public abstract class EntityCollider : Collider {
		/// Inherited:
		/// public LayerMask layerMask
		
		// fields
		public Transform transform { get; private set; }
		public Vector2 pivot;

		public EntityCollider(Transform t, Vector2 pivot) : base() {
			transform = t;
			this.pivot = pivot;
		}

	}
}
