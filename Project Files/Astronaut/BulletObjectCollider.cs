

namespace Astro {
	public class BulletObjectCollider : Collider {
		/// Inherited:
		/// public LayerMask layerMask
		
		// fields
		public BulletObject bulletObject { get; private set; }

		public int BulletCount => bulletObject.bulletArr.Length;

		public BulletObjectCollider(BulletObject bo) : base() {
			bulletObject = bo;
		}

		public ref Bullet GetBullet(int index) {
			return ref bulletObject[index];
		}

	}
}
