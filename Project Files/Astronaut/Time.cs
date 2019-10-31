
namespace Astro {
	class Time {
		// Singleton
		public static Time Singleton { get; private set; }

		public float deltaTime;
		/// <summary> DeltaTime not multiplied by the TimeScale </summary>
		public static float RealDeltaTime => Singleton.deltaTime;
		/// <summary> DeltaTime multiplied by the TimeScale </summary>
		public static float ScaledDeltaTime => Singleton.deltaTime * TimeScale;
		
		private float timeSale;
		/// <summary> The multiplier for ScaledDeltaTime </summary>
		public static float TimeScale {
			get => Singleton.timeSale;
			// prevents setting the timescale to negative
			set => Singleton.timeSale = (value >= 0f ? value : 0f);
		}

		public Time() {
			// set singleton
			if (Singleton == null) Singleton = this;
			else Debug.ErrorLog("Time.Singleton was not null");	

			// init values
			deltaTime = 0f;
			TimeScale = 0f;
		} 
		~Time() {
			// remove singleton
			if (Singleton == this) Singleton = null;
		}
	}
}
