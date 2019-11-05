using System.Collections.Generic;

namespace Astro {
	public class BulletManager {
		// Singletons
		public static BulletManager Singleton { get; private set; }

		// bulletobject list
		private List<BulletObject> bulletObjList;

		public BulletManager() {
			if (Singleton == null) Singleton = this;
			else Debug.ErrorLog("BulletManager Singleton was not null");
		}
		~BulletManager() {
			if (Singleton == this) Singleton = null;
		}

		public void Init() {
			bulletObjList = new List<BulletObject>();
		}
		public void Exit() {
			bulletObjList.Clear();
		}

		public void LoadContent() {

		}

		// adding and removing bulletobjects
		public static void AddBulletObject(BulletObject bobj) {
			if (!Singleton.bulletObjList.Contains(bobj))
				Singleton.bulletObjList.Add(bobj);
			else
				Debug.ErrorLog("That bulletobject is already in the list adn cannot be added");
		}
		public static void RemoveBulletObject(BulletObject bobj) {
			if (Singleton.bulletObjList.Contains(bobj))
				Singleton.bulletObjList.Remove(bobj);
			else
				Debug.ErrorLog("That bulletobject is not in the list and cannot be removed");
		}

		public void Update() {

		}

	}
}
