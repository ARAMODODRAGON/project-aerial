using System.Collections.Generic;
using System.Collections;

namespace Astro {
	public class CollisionFactory {
		// Singleton
		public static CollisionFactory Singleton { get; private set; }

		// The lists of colliders
		private List<CircleCollider> eCircleList;
		private List<BulletObjectCollider> bObjectList;

		public CollisionFactory() {
			// set singleton
			if (Singleton == null) Singleton = this;
			else Debug.ErrorLog("CollisionFactory Singleton was not null");

			// setup various lists
			eCircleList = new List<CircleCollider>();
			bObjectList = new List<BulletObjectCollider>();
		}

		~CollisionFactory() {
			// remove singleton
			if (Singleton == this) Singleton = null;
		}

		public void PhysicsUpdate() {
			// TODO: add functionality
		}

		// static functions used to manage colliders in the lists

		public static void AddCollider(Collider col) {
			if (col is CircleCollider c0) {
				// add collider to list
				if (!Singleton.eCircleList.Contains(c0))
					Singleton.eCircleList.Add(c0);
				else
					Debug.ErrorLog("The CircleCollider list already contains that collider");
			} else if (col is BulletObjectCollider c1) {
				// add collider to list
				if (!Singleton.bObjectList.Contains(c1))
					Singleton.bObjectList.Add(c1);
				else
					Debug.ErrorLog("The BulletObjectCollider list already contains that collider");
			} else {
				Debug.ErrorLog("Collider of type " + col.GetType() + " is not supported");
			}
		}

		public static void RemoveCollider(Collider col) {
			if (col is CircleCollider c0) {
				// find and remove the collider in the list
				if (!Singleton.eCircleList.Remove(c0))
					Debug.ErrorLog("CircleCollider was not in list"); // if it fails
			} else if (col is BulletObjectCollider c1) {
				// find and remove the collider in the list
				if (!Singleton.bObjectList.Remove(c1))
					Debug.ErrorLog("BulletObjectCollider was not in list"); // if it fails
			} else {
				Debug.ErrorLog("Collider of type " + col.GetType() + " is not supported");
			}
		}


	}
}
