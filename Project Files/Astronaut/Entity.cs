using Microsoft.Xna.Framework;

namespace Astro {
	abstract class Entity {



		public virtual void Init() {

		}

		public virtual void Exit() {

		}

		public virtual void LoadContent() { }
		public virtual void Update() { }
		public virtual void Render() { }



	}
}
