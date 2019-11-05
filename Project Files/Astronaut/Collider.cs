

namespace Astro {
	public abstract class Collider {
		// fields
		public LayerMask layerMask;

		public Collider() {
			layerMask = new LayerMask(false);
			
		}

	}
}
