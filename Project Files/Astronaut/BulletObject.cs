using Microsoft.Xna.Framework;

namespace Astro {
	public class BulletObject {
		// the bullet array
		public Bullet[] bulletArr;
		public int Count => bulletArr.Length;
		private int activeCount = 0;
		public int ActiveBulletCount => activeCount;

		// collider and layermask
		public BulletObjectCollider collider { get; private set; }
		public ref LayerMask layerMask => ref collider.layerMask;

		// delegates
		public delegate void BulletsDelegate(ref Bullet bu);
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

		public void Update() {
			if (UpdateBullets != null) {
				for (int i = 0; i < Count; i++)
					UpdateBullets.Invoke(ref bulletArr[i]);
			} else {
				for (int i = 0; i < Count; i++)
					bulletArr[i].Update();
			}
		}

		public bool TryRender() {
			if (DrawBullets != null) {
				// call delegate for all bullets
				for (int i = 0; i < Count; i++)
					DrawBullets.Invoke(ref bulletArr[i]);
				return true;
			} else
				return false;
		}

		#region Creating bullets

		// Creating a single bullet
		public void CreateSingle(Vector2 position, Radial direction, Color color, BulletDraw shape = BulletDraw.circle) {
			// check if a bullet can be made
			if (activeCount == Count) {
				Debug.ErrorLog("Reached max number of bullets");
				return;
			}

			// find a location to add the bullet to
			int index;
			for (index = 0; index < Count; index++) {
				if (bulletArr[index].state == 0)
					break;
				else if (index + 1 == Count) {
					Debug.ErrorLog("Reached max number of bullets but failed to recognise that sooner");
					return;
				}
			}

			// create and add bullet
			bulletArr[index].position = position;
			bulletArr[index].direction = direction;
			bulletArr[index].state = BulletState.spawning;
			bulletArr[index].draw = shape;
			bulletArr[index].color = color;
		}

		// Creating a single bullet
		public void CreateSingle(Vector2 position, Radial direction, BulletDraw shape = BulletDraw.circle) {
			// check if a bullet can be made
			if (activeCount == Count) {
				Debug.ErrorLog("Reached max number of bullets");
				return;
			}

			// find a location to add the bullet to
			int index;
			for (index = 0; index < Count; index++) {
				if (bulletArr[index].state == 0)
					break;
				else if (index + 1 == Count) {
					Debug.ErrorLog("Reached max number of bullets but failed to recognise that sooner");
					return;
				}
			}

			// create and add bullet
			bulletArr[index].activeTime = 0f;
			bulletArr[index].position = position;
			bulletArr[index].direction = direction;
			bulletArr[index].state = BulletState.spawning;
			bulletArr[index].draw = shape;
			bulletArr[index].color = Color.White;
		}

		#endregion



	}
}
