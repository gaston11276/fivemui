using System;
using NFive.SDK.Client.Interface;

namespace Gaston11276.Fivemui.Client.Overlays
{
	public class FivemuiOverlay : Overlay
	{
		public event EventHandler<OnKeyOverlayEventArgs> OnKey;
		public event EventHandler<OnMouseButtonOverlayEventArgs> OnMouseButton;
		public event EventHandler<OverlayEventArgs> OnMouseMove;

		public FivemuiOverlay(IOverlayManager manager) : base(manager)
		{
			On<int>("OnKeyPress", (keycode) => this.OnKey?.Invoke(this, new OnKeyOverlayEventArgs(1, keycode, this)));
			On<int>("OnKeyDown", (keycode) => this.OnKey?.Invoke(this, new OnKeyOverlayEventArgs(2, keycode, this)));
			On<int>("OnKeyUp", (keycode) => this.OnKey?.Invoke(this, new OnKeyOverlayEventArgs(3, keycode, this)));
			On<int>("OnMouseButtonDown", (button) => this.OnMouseButton?.Invoke(this, new OnMouseButtonOverlayEventArgs(1, button, this)));
			On<int>("OnMouseButtonRelease", (button) => this.OnMouseButton?.Invoke(this, new OnMouseButtonOverlayEventArgs(3, button, this)));
			On("OnMouseMove", () => this.OnMouseMove?.Invoke(this, new OverlayEventArgs(this)));
		}
	}

	public class OnKeyOverlayEventArgs : OverlayEventArgs
	{
		public int state { get; set; }
		public int keycode { get; set; }

		public OnKeyOverlayEventArgs(int state, int keycode, Overlay overlay) : base(overlay)
		{
			this.state = state;
			this.keycode = keycode;
		}
	}

	public class OnMouseButtonOverlayEventArgs : OverlayEventArgs
	{
		public int state { get; set; }
		public int button { get; set; }

		public OnMouseButtonOverlayEventArgs(int state, int button, Overlay overlay) : base(overlay)
		{
			this.state = state;
			this.button = button;
		}
	}

	public class OnMouseMoveOverlayEventArgs : OverlayEventArgs
	{
		public int x { get; set; }
		public int y { get; set; }

		public OnMouseMoveOverlayEventArgs(int x, int y, Overlay overlay) : base(overlay)
		{
			this.x = x;
			this.y = y;
		}
	}
	
}
