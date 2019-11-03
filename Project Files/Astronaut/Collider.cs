
namespace Astro {
	abstract class Collider {
		public Transform transform { get; private set; }

		public Collider(Transform t) {
			transform = t;
		}

	}
}
