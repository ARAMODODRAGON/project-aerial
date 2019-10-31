using Microsoft.Xna.Framework;

namespace Astro {
	class Screen {
		private static Screen Singleton { get; set; }

		// graphics
		private GraphicsDeviceManager graDevManager;

		// screen
		private readonly Point displaySize;
		public static Point ScreenSize {
			get => new Point(Singleton.graDevManager.PreferredBackBufferWidth,
							 Singleton.graDevManager.PreferredBackBufferHeight);
			set {
				Singleton.graDevManager.PreferredBackBufferWidth = value.X;
				Singleton.graDevManager.PreferredBackBufferHeight = value.Y;
			}
		}
		private int ScreenWidth => graDevManager.PreferredBackBufferWidth;
		private int ScreenHeight => graDevManager.PreferredBackBufferHeight;
		public static bool IsFullscreen { get; private set; }
		public static Point WindowSize;

		// world view
		private Rectangle cameraRect;
		public static Rectangle CameraRect => Singleton.cameraRect;
		public static Vector2 CameraSize {
			get => new Vector2(Singleton.cameraRect.Width, Singleton.cameraRect.Height);
			set {
				Vector2 position = CameraPosition;
				Singleton.cameraRect.Width = (int)value.X;
				Singleton.cameraRect.Height = (int)value.Y;
				CameraPosition = position;
			}
		}
		public static Vector2 CameraPosition {
			get => new Vector2(Singleton.cameraRect.X, Singleton.cameraRect.Y);
			set {
				Singleton.cameraRect.X = (int)value.X + Singleton.cameraRect.Width / 2;
				Singleton.cameraRect.Y = (int)value.Y + Singleton.cameraRect.Height / 2;
			}
		}
		public static Matrix TransformMatrix { get; private set; }

		public Screen(GraphicsDeviceManager devManager, bool isFullscren, Point? windowSize = null) {
			// set singleton
			if (Singleton == null) Singleton = this;
			else Debug.ErrorLog("Screen.Singleton was not null");

			// set device manager
			graDevManager = devManager;

			// set the camera
			cameraRect = new Rectangle(0, 0, 1600, 900);

			// get the display size
			int dispWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
			int dispHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
			displaySize = new Point(dispWidth, dispHeight);
			// set screen size
			if (windowSize.HasValue) ScreenSize = windowSize.Value;
			else ScreenSize = new Point(1280, 720);

			WindowSize = ScreenSize;

			ToggleFullscreen(isFullscren);
			UpdateTransform();
		}
		~Screen() {
			// remove singleton
			if (Singleton == this) Singleton = null;
		}

		// Toggles between fullscreen and not
		public static void ToggleFullscreen(bool? fullscreen = null) {
			if (!fullscreen.HasValue) {
				Singleton.graDevManager.ToggleFullScreen();
				IsFullscreen = Singleton.graDevManager.IsFullScreen;
			} else if (fullscreen.Value) {
				if (!Singleton.graDevManager.IsFullScreen) {
					Singleton.graDevManager.ToggleFullScreen();
					IsFullscreen = true;
				}
			} else {
				if (Singleton.graDevManager.IsFullScreen) {
					Singleton.graDevManager.ToggleFullScreen();
					IsFullscreen = false;
				}
			}

		}

		public void UpdateTransform() {
			Vector3 scale = new Vector3(CameraSize, 0f);
			scale.X /= ScreenWidth;
			scale.Y /= ScreenHeight;
			TransformMatrix = Matrix.CreateTranslation(new Vector3(-CameraPosition.X, -CameraPosition.Y, 0f)) * Matrix.CreateScale(scale);
		}

	}
}
