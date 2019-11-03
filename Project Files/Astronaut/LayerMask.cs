

namespace Astro {
	struct LayerMask {
		private bool L0;
		private bool L1;
		private bool L2;
		private bool L3;
		private bool L4;
		private bool L5;
		private bool L6;
		private bool L7;

		public LayerMask(bool setall = false) {
			L0 = setall; L1 = setall; L2 = setall; L3 = setall;
			L4 = setall; L5 = setall; L6 = setall; L7 = setall;
		}

		// getting and setting the layers
		public bool this[int index] {
			get {
				switch (index) {
					case 0: return L0;
					case 1: return L1;
					case 2: return L2;
					case 3: return L3;
					case 4: return L4;
					case 5: return L5;
					case 6: return L6;
					case 7: return L7;
					default: throw new System.IndexOutOfRangeException(); ;
				}
			}
			set {
				switch (index) {
					case 0: L0 = value; return;
					case 1: L1 = value; return;
					case 2: L2 = value; return;
					case 3: L3 = value; return;
					case 4: L4 = value; return;
					case 5: L5 = value; return;
					case 6: L6 = value; return;
					case 7: L7 = value; return;
					default: throw new System.IndexOutOfRangeException();
				}
			}
		}

		// check if any active layer matches
		public static bool CompareAny(LayerMask maskA, LayerMask maskB) {
			if		(maskA.L0 && maskB.L0) return true;
			else if (maskA.L1 && maskB.L1) return true;
			else if (maskA.L2 && maskB.L2) return true;
			else if (maskA.L3 && maskB.L3) return true;
			else if (maskA.L4 && maskB.L4) return true;
			else if (maskA.L5 && maskB.L5) return true;
			else if (maskA.L6 && maskB.L6) return true;
			else if (maskA.L7 && maskB.L7) return true;
			else return false;
		}

		// check if specified layer matches
		public static bool CompareOne(LayerMask maskA, LayerMask maskB, int index) {
			switch (index) {
				case 0: return maskA.L0 && maskB.L0;
				case 1: return maskA.L1 && maskB.L1;
				case 2: return maskA.L2 && maskB.L2;
				case 3: return maskA.L3 && maskB.L3;
				case 4: return maskA.L4 && maskB.L4;
				case 5: return maskA.L5 && maskB.L5;
				case 6: return maskA.L6 && maskB.L6;
				case 7: return maskA.L7 && maskB.L7;
				default: throw new System.IndexOutOfRangeException();
			}
		}

		// check if all layers match
		public static bool CompareAll(LayerMask maskA, LayerMask maskB) {
			return (maskA.L0 && maskB.L0) 
				&& (maskA.L1 && maskB.L1) 
				&& (maskA.L2 && maskB.L2) 
				&& (maskA.L3 && maskB.L3)
				&& (maskA.L4 && maskB.L4) 
				&& (maskA.L5 && maskB.L5) 
				&& (maskA.L6 && maskB.L6) 
				&& (maskA.L7 && maskB.L7);
		}

	}
}
