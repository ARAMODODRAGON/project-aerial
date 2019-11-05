
namespace Astro {
	public class Time {
		// Singleton //  private for now
		private static Time Singleton { get; set; }

		/// <summary> Delta affected by ScalarA </summary>
		public static float DeltaA { get; private set; }
		/// <summary> Delta affected by ScalarB </summary>
		public static float DeltaB { get; private set; }
		/// <summary> Delta affected by ScalarC </summary>
		public static float DeltaC { get; private set; }
		/// <summary> Delta affected by ScalarD </summary>
		public static float DeltaD { get; private set; }
		/// <summary> Delta not affected by any scalar </summary>
		public static float RealDelta { get; private set; }

		/// <summary> Scales DeltaA </summary>
		public static float ScalarA { get; set; }
		/// <summary> Scales DeltaB </summary>
		public static float ScalarB { get; set; }
		/// <summary> Scales DeltaC </summary>
		public static float ScalarC { get; set; }
		/// <summary> Scales DeltaD </summary>
		public static float ScalarD { get; set; }
		/// <summary> Scales ABCD deltas on top of thier own scalars </summary>
		public static float AllScalar { get; set; }

		public Time() {
			// set singleton
			if (Singleton == null) Singleton = this;
			else Debug.ErrorLog("Time.Singleton was not null");

			// init deltas
			DeltaA = 0f;
			DeltaB = 0f;
			DeltaC = 0f;
			DeltaD = 0f;
			RealDelta = 0f;

			ScalarA = 1f;
			ScalarB = 1f;
			ScalarC = 1f;
			ScalarD = 1f;
			AllScalar = 1f;
		} 
		~Time() {
			// remove singleton
			if (Singleton == this) Singleton = null;
		}

		public void UpdateDeltas(float delta) {
			DeltaA = delta * ScalarA * AllScalar;
			DeltaB = delta * ScalarB * AllScalar;
			DeltaC = delta * ScalarC * AllScalar;
			DeltaD = delta * ScalarD * AllScalar;
			RealDelta = delta;
		}
	}
}
