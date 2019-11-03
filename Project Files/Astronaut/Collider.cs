
namespace Astro {
	abstract class Collider {
		public Transform transform { get; private set; }
		public LayerMask layerMask { get; private set; }

		public Collider(Transform t) {
			transform = t;
			layerMask = new LayerMask(false);
		}

	}
}
