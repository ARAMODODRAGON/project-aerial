using Microsoft.Xna.Framework;

namespace Astro {
	class BulletObject {
		// the bullet array
		public Bullet[] bulletArr;
		public int Count => bulletArr.Length;
		private int activeCount = 0;
		public int ActiveBulletCount => activeCount;

		// collider and layermask
		public BulletObjectCollider collider { get; private set; }
		public ref LayerMask layerMask => ref collider.layerMask;

		// delegates
		public delegate void BulletsDelegate(Bullet[] bulletArr);
		public BulletsDelegate UpdateBullets = null;
		public BulletsDelegate DrawBullets = null;

		public BulletObject(int bulletCount) {
			// create array
			bulletArr = new Bullet[bulletCount];

			// create collider
			collider = new BulletObjectCollider(this);
			CollisionFactory.AddCollider(collider);
		}

		~BulletObject() {
			// destroy collider
			CollisionFactory.RemoveCollider(collider);
		}

		public ref Bullet this[int index] => ref bulletArr[index];

		#region Creating bullets

		// Creating a single bullet
		public void CreateSingle(Vector2 position, Radial direction, BulletLogic logic, Color color, BulletShape shape = BulletShape.circle) {
			// check if a bullet can be made
			if (activeCount == Count) {
				Debug.ErrorLog("Reached max number of bullets");
				return;
			}

			// find a location to add the bullet to
			int index;
			for (index = 0; index < Count; index++) {
				if (bulletArr[index].logic == 0)
					break;
				else if (index + 1 == Count) {
					Debug.ErrorLog("Reached max number of bullets but failed to recognise that sooner");
					return;
				}
			}

			// create and add bullet
			bulletArr[index].position = position;
			bulletArr[index].direction = direction;
			bulletArr[index].logic = logic;
			bulletArr[index].shape = shape;
			bulletArr[index].color = color;
		}
		
		#endregion

	}
}
