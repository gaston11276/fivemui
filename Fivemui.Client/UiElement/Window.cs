using System.Collections.Generic;
using System.Threading.Tasks;
using NFive.SDK.Client.Input;
using NFive.SDK.Core.Input;
using Gaston11276.SimpleUi;

namespace Gaston11276.Fivemui
{
	public abstract class Window : UiElementFiveM
	{
		protected List<fpVoid> onOpenCallbacks = new List<fpVoid>();
		protected List<fpVoid> onCloseCallbacks = new List<fpVoid>();

		protected float defaultPadding = 0.0025f;

		public int hotkey;
		public Hotkey HotkeyToggle;
		public bool isRefreshingUi = false;

		public Window()
		{

		}

		protected virtual void OnOpen()
		{
			WindowManager.OpenNui();
			
			foreach (fpVoid onOpen in onOpenCallbacks)
			{
				onOpen();
			}
		}

		protected virtual void OnClose()
		{
			ClearFlags(HASFOCUS | SELECTED);

			WindowManager.CloseNui();

			foreach (fpVoid onClose in onCloseCallbacks)
			{
				onClose();
			}
		}

		public void RegisterOnOpenCallback(fpVoid OnOpen)
		{
			onOpenCallbacks.Add(OnOpen);
		}

		public void RegisterOnCloseCallback(fpVoid OnClose)
		{
			onCloseCallbacks.Add(OnClose);
		}

		public void SetHotkey(InputControl ic)
		{
			HotkeyToggle = new Hotkey(ic);
			hotkey = (int)UiInput.ConvertKeycode(HotkeyToggle.UserKeyboardKey);
		}

		public void OnInputKey(int state, int keycode)
		{
			if (IsOpen())
			{
				if (state == 3 && keycode == 27)// Escape
				{
					Close();
				}

				if (state == 3 && keycode == hotkey)
				{
					Close();
				}
			}
			else
			{
				if (state == 3 && keycode == hotkey)
				{
					Open();
				}
			}
		}

		public override void OnMouseMove(float cursorX, float cursorY)
		{
			base.OnMouseMove(cursorX, cursorY);
		}

		public override void OnMouseButton(int state, int button, float CursorX, float CursorY)
		{
			base.OnMouseButton(state, button, CursorX, CursorY);
		}

		public bool IsOpen()
		{
			return ((GetFlags() & HIDDEN) == 0);
		}

		public virtual void Open()
		{
			ClearFlags(HIDDEN);
			OnOpen();
		}

		public virtual void Close()
		{
			SetFlags(HIDDEN);
			OnClose();
		}

		public virtual void Toggle()
		{
			if (IsOpen())
			{
				Close();
			}
			else
			{
				Open();
			}
		}

		public virtual void CreateUi()
		{
			screenBoundaries = new UiRectangle(0f, 0f, 1f, 1f);
			WindowManager.RegisterOnKeyCallback(OnInputKey);
			WindowManager.RegisterOnMouseButtonCallback(OnMouseButton);
			WindowManager.RegisterOnMouseMoveCallback(OnMouseMove);
		}
	}
}
