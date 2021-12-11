using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core.Native;
using NFive.SDK.Client.Interface;
using Gaston11276.Fivemui.Client.Overlays;
using Gaston11276.SimpleUi;

namespace Gaston11276.Fivemui
{
	public delegate Task fpDelay(int ms);
	public delegate void fpVoid();
	public delegate void fpGuid(Guid Id);
	public delegate void fpOnMouseMove(float x, float y);
	public delegate void fpOnMouseButton(int state, int button, float x, float y);
	public delegate void fpOnKey(int state, int keycode);

	public static class WindowManager
	{
		static public int delayMs = 10;
		//static public List<Window> windows = new List<Window>();

		public static List<fpOnKey> inputsOnKey = new List<fpOnKey>();
		public static List<fpOnMouseMove> inputsOnMouseMove = new List<fpOnMouseMove>();
		public static List<fpOnMouseButton> inputsOnMouseButton = new List<fpOnMouseButton>();

		static public fpDelay Delay;

		//static public IOverlayManager overlayManager;
		static public FivemuiOverlay overlay;
		static UiElementFiveM mainElement = new UiElementFiveM();

		//static bool holdFocus;

		public static void Init()
		{
			mainElement.SetFlags(UiElement.TRANSPARENT);
			mainElement.SetPadding(new UiRectangle(0.0025f));
			mainElement.SetHDimension(Dimension.Max);
			mainElement.SetVDimension(Dimension.Max);
			//RegisterOnKeyCallback(OnKey);
			mainElement.Refresh();

			overlay.OnKey += OnNuiKey;
			overlay.OnMouseButton += OnNuiMouseButton;
			overlay.OnMouseMove += OnNuiMouseMove;
		}

		static public void OnResolutionChanged()
		{
			int screenWidth = new int();
			int screenHeight = new int();
			API.GetActiveScreenResolution(ref screenWidth, ref screenHeight);
			UiElement.SetResolution(screenWidth, screenHeight);
		}

		static public void AddWindow(Window window)
		{
			mainElement.AddElement(window);
		}

		static public void Refresh()
		{
			mainElement.Refresh();
		}

		/*
		static void OnKey(int state, int keycode)
		{
			if(state == 3 && keycode == 32)
			{
				Refresh();
			}
		}
		*/

		static public void RegisterOnKeyCallback(fpOnKey OnKey)
		{
			inputsOnKey.Add(OnKey);
		}
		static public void RegisterOnMouseButtonCallback(fpOnMouseButton OnMouseButton)
		{
			inputsOnMouseButton.Add(OnMouseButton);
		}
		static public void RegisterOnMouseMoveCallback(fpOnMouseMove OnMouseMove)
		{
			inputsOnMouseMove.Add(OnMouseMove);
		}

		static private void OnNuiKey(object sender, OnKeyOverlayEventArgs args)
		{
			OnInputKey(args.state, args.keycode);
		}

		static private void OnNuiMouseButton(object sender, OnMouseButtonOverlayEventArgs args)
		{
			int x = 0; int y = 0;
			API.GetNuiCursorPosition(ref x, ref y);
			OnMouseButton(args.state, args.button, x, y);
		}

		static private void OnNuiMouseMove(object sender, OverlayEventArgs args)
		{
			int x = 0; int y = 0;
			API.GetNuiCursorPosition(ref x, ref y);
			OnMouseMove(x, y);
		}

		static public void OnInputKey(int state, int keycode)
		{
			foreach (fpOnKey OnKey in inputsOnKey)
			{
				OnKey(state, keycode);
			}
		}

		static public void OnMouseMove(float cursorX, float cursorY)
		{
			foreach (fpOnMouseMove OnMouseMove in inputsOnMouseMove)
			{
				OnMouseMove(cursorX, cursorY);
			}
		}

		static public void OnMouseButton(int state, int button, float CursorX, float CursorY)
		{
			foreach (fpOnMouseButton OnMouseButton in inputsOnMouseButton)
			{
				OnMouseButton(state, button, CursorX, CursorY);
			}
		}

		static public void OnFiveMInput()
		{
			List<UiElement> elements = mainElement.GetElements();
			foreach (Window window in elements)
			{
				if (window.HotkeyToggle != null && window.HotkeyToggle.IsJustReleased())
				{
					if (window.IsOpen())
					{
						window.Close();
					}
					else
					{
						window.Open();
					}
				}
			}
		}

		static public void OnDraw()
		{
			mainElement.Draw();
		}

		static public void OpenNui()
		{
			overlay.Focus(true);
			overlay.Show(true, true);
		}
	
		static public void CloseNui()
		{
			List<UiElement> elements = mainElement.GetElements();
			foreach (Window window in elements)
			{
				if (window.IsOpen())
				{
					return;
				}
			}

			overlay.Hide(true);
		}
	}
}
