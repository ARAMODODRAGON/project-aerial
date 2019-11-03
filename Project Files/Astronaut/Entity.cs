using Microsoft.Xna.Framework;

namespace Astro {
	abstract class Entity {
		// the name, transform, and collider
		public string name { get; protected set; }
		public Transform transform { get; private set; }
		public EntityCollider collider { get; private set; }

		public Entity() {
			transform = new Transform(this);
		}

		~Entity() {
			// destroy collider
			if (collider != null) {
				CollisionFactory.RemoveCollider(collider);
			}

		}

		// creating colliders and bulletobjects
		protected T CreateCollider<T>() where T : EntityCollider {
			// destroy old collider
			if (collider != null) {
				CollisionFactory.RemoveCollider(collider);
			}

			// create a variable
			EntityCollider col = null;

			if (typeof(T) == typeof(CircleCollider)) {
				// create collider
				col = new CircleCollider(transform, Vector2.Zero, 1f);
				collider = col;

			} else {
				Debug.ErrorLog("EntityCollider of type " + typeof(T) + " is not supported");
			}

			// return as T
			return col as T;
		}


		// common events
		public abstract void Init();
		public abstract void Exit();
		public abstract void LoadContent();
		public abstract void Update();
		public abstract void Render();



	}
}
