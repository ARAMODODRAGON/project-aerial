using Microsoft.Xna.Framework.Content;

namespace Astro {
	class ContentLoader {
		// Singleton 
		private static ContentLoader Singleton { get; set; }

		private readonly ContentManager contManager;

		public ContentLoader(ContentManager contentM) {
			// set singleton
			if (Singleton == null) Singleton = this;
			else Debug.ErrorLog("ContentLoader.Singleton was not null");

			// set the content manager reference
			contManager = contentM;
		}
		~ContentLoader() {
			// remove singleton
			if (Singleton == this) Singleton = null;
		}

		public static T Load<T>(string filename) {
			return Singleton.contManager.Load<T>(filename);
		}

		public static void Unload() {
			Singleton.contManager.Unload();
		}
	}
}
