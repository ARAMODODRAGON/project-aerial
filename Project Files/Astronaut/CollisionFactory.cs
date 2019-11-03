using System.Collections.Generic;
using System.Collections;

namespace Astro {
	class CollisionFactory {
		// Singleton
		public static CollisionFactory Singleton { get; private set; }

		// The lists of colliders
		private List<CircleCollider> eCircleList;


		public CollisionFactory() {
			// set singleton
			if (Singleton == null) Singleton = this;
			else Debug.ErrorLog("CollisionFactory Singleton was not null");

			// setup various lists
			eCircleList = new List<CircleCollider>();
		}

		~CollisionFactory() {
			// remove singleton
			if (Singleton == this) Singleton = null;
		}

		public void PhysicsUpdate() {

		}

		// static functions used to manage colliders in the lists

		public static void AddCollider(Collider col) {
			if (col is CircleCollider c) {
				// add collider to list
				if (!Singleton.eCircleList.Contains(c))
					Singleton.eCircleList.Add(c);
				else
					Debug.ErrorLog("The collider list already contains that collider");

			} else {
				Debug.ErrorLog("Collider of type " + col.GetType() + " is not supported");
			}
		}

		public static void RemoveCollider(Collider col) {
			if (col is CircleCollider c) {
				// find and remove the collider in the list
				if (!Singleton.eCircleList.Remove(c))
					Debug.ErrorLog("Collider was not in list"); // if it fails
			} else {
				Debug.ErrorLog("Collider of type " + col.GetType() + " is not supported");
			}
		}


	}
}
