using System.Collections.Generic;
using NFive.SDK.Core.Input;
using NFive.SDK.Client.Input;

namespace Gaston11276.Fivemui
{
	public abstract class UiInput
	{
		public class KeyData
		{
			public int keycode;
			public Hotkey hotkey;
			public KeyData(int keycode, InputControl control)
			{
				this.keycode = keycode;
				hotkey = new Hotkey(control);
			}
		}

		/*
		static void AddKeyData(int keycode, InputControl control, ref List<KeyData> keys)
		{
			KeyData keydata = new KeyData(keycode, control);
			keydata.keycode = keycode;
			keys.Add(keydata);
		}

		static public void InitInput(ref List<KeyData> keys)
		{
			keys = new List<KeyData>();
			AddKeyData(65, InputControl.MoveLeftOnly, ref keys); // A
			AddKeyData(66, InputControl.SpecialAbilitySecondary, ref keys); // B
			AddKeyData(67, InputControl.CreatorRT, ref keys); // C
			AddKeyData(68, InputControl.MoveRightOnly, ref keys); // D
			AddKeyData(69, InputControl.Context, ref keys); // E
			AddKeyData(70, InputControl.Arrest, ref keys); // F
			AddKeyData(71, InputControl.Detonate, ref keys); // G
			AddKeyData(72, InputControl.VehicleRoof, ref keys); // H
			AddKeyData(73, 0, ref keys); // I
			AddKeyData(74, 0, ref keys); // J
			AddKeyData(75, InputControl.ReplayShoHotkey, ref keys); // K
			AddKeyData(76, InputControl.CinematicSlowMo, ref keys);               // L
			AddKeyData(77, InputControl.InteractionMenu, ref keys); // M
			AddKeyData(78, InputControl.PushToTalk, ref keys); // N
			AddKeyData(79, 0, ref keys); // O
			AddKeyData(80, InputControl.FrontendPause, ref keys); // P
			AddKeyData(81, InputControl.Cover, ref keys); // Q
			AddKeyData(82, InputControl.Reload, ref keys); // R
			AddKeyData(83, InputControl.MoveDownOnly, ref keys); // S
			AddKeyData(84, InputControl.MpTextChatAll, ref keys); // T
			AddKeyData(85, InputControl.ReplayScreenshot, ref keys); // U
			AddKeyData(86, InputControl.NextCamera, ref keys); // V
			AddKeyData(87, InputControl.MoveUpOnly, ref keys); // W
			AddKeyData(88, InputControl.VehicleDuck, ref keys); // X
			AddKeyData(89, InputControl.WeaponSpecial, ref keys); // Y
			AddKeyData(90, InputControl.MultiplayerInfo, ref keys); // Z
			AddKeyData(8, InputControl.PhoneCancel, ref keys); // Backspace
		}
		*/


		static public KeycodesVK ConvertKeycode(KeyCode nfiveKeycode)
		{
			switch (nfiveKeycode)
			{
				case KeyCode.Unknown:
					return 0;
				case KeyCode.None:
					return 0;
				case KeyCode.Backspace:
					return KeycodesVK.Backspace;
				case KeyCode.Tab:
					return KeycodesVK.Tab;
				case KeyCode.Pause:
					return KeycodesVK.Pause;
				case KeyCode.Escape:
					return KeycodesVK.Escape;
				case KeyCode.Space:
					return KeycodesVK.Space;
				case KeyCode.Digit1:
					return KeycodesVK.Key1;
				case KeyCode.Digit2:
					return KeycodesVK.Key2;
				case KeyCode.Digit3:
					return KeycodesVK.Key3;
				case KeyCode.Digit4:
					return KeycodesVK.Key4;
				case KeyCode.Digit5:
					return KeycodesVK.Key5;
				case KeyCode.Digit6:
					return KeycodesVK.Key6;
				case KeyCode.Digit7:
					return KeycodesVK.Key7;
				case KeyCode.Digit8:
					return KeycodesVK.Key8;
				case KeyCode.Digit9:
					return KeycodesVK.Key9;
				case KeyCode.Digit0:
					return KeycodesVK.Key0;
				case KeyCode.KeyA:
					return KeycodesVK.KeyA;
				case KeyCode.KeyB:
					return KeycodesVK.KeyB;
				case KeyCode.KeyC:
					return KeycodesVK.KeyC;
				case KeyCode.KeyD:
					return KeycodesVK.KeyD;
				case KeyCode.KeyE:
					return KeycodesVK.KeyE;
				case KeyCode.KeyF:
					return KeycodesVK.KeyF;
				case KeyCode.KeyG:
					return KeycodesVK.KeyG;
				case KeyCode.KeyH:
					return KeycodesVK.KeyH;
				case KeyCode.KeyI:
					return KeycodesVK.KeyI;
				case KeyCode.KeyJ:
					return KeycodesVK.KeyJ;
				case KeyCode.KeyK:
					return KeycodesVK.KeyK;
				case KeyCode.KeyL:
					return KeycodesVK.KeyL;
				case KeyCode.KeyM:
					return KeycodesVK.KeyM;
				case KeyCode.KeyN:
					return KeycodesVK.KeyN;
				case KeyCode.KeyO:
					return KeycodesVK.KeyO;
				case KeyCode.KeyP:
					return KeycodesVK.KeyP;
				case KeyCode.KeyQ:
					return KeycodesVK.KeyQ;
				case KeyCode.KeyR:
					return KeycodesVK.KeyR;
				case KeyCode.KeyS:
					return KeycodesVK.KeyS;
				case KeyCode.KeyT:
					return KeycodesVK.KeyT;
				case KeyCode.KeyU:
					return KeycodesVK.KeyU;
				case KeyCode.KeyV:
					return KeycodesVK.KeyV;
				case KeyCode.KeyW:
					return KeycodesVK.KeyW;
				case KeyCode.KeyX:
					return KeycodesVK.KeyX;
				case KeyCode.KeyY:
					return KeycodesVK.KeyY;
				case KeyCode.KeyZ:
					return KeycodesVK.KeyZ;
				case KeyCode.Backquote:
					return 0;
				case KeyCode.Minus:
					return KeycodesVK.OEMMinus;
				case KeyCode.Equal:
					return 0;
				case KeyCode.BracketLeft:
					return KeycodesVK.OEM4;
				case KeyCode.BracketRight:
					return KeycodesVK.OEM6;
				case KeyCode.Semicolon:
					return KeycodesVK.OEM1;
				case KeyCode.Quote:
					return KeycodesVK.OEM7;
				case KeyCode.Backslash:
					return KeycodesVK.OEM5;
				case KeyCode.Comma:
					return KeycodesVK.OEMComma;
				case KeyCode.Period:
					return KeycodesVK.OEMPeriod;
				case KeyCode.Slash:
					return KeycodesVK.OEM2;
				case KeyCode.IntlBackslash:
					return 0;
				case KeyCode.Numpad0:
					return KeycodesVK.Numpad0;
				case KeyCode.Numpad1:
					return KeycodesVK.Numpad1;
				case KeyCode.Numpad2:
					return KeycodesVK.Numpad2;
				case KeyCode.Numpad3:
					return KeycodesVK.Numpad3;
				case KeyCode.Numpad4:
					return KeycodesVK.Numpad4;
				case KeyCode.Numpad5:
					return KeycodesVK.Numpad5;
				case KeyCode.Numpad6:
					return KeycodesVK.Numpad6;
				case KeyCode.Numpad7:
					return KeycodesVK.Numpad7;
				case KeyCode.Numpad8:
					return KeycodesVK.Numpad8;
				case KeyCode.Numpad9:
					return KeycodesVK.Numpad9;
				case KeyCode.NumpadDecimal:
					return KeycodesVK.NumpadDecimal;
				case KeyCode.NumpadDivide:
					return KeycodesVK.NumpadDivide;
				case KeyCode.NumpadMultiply:
					return KeycodesVK.NumpadMultiply;
				case KeyCode.NumpadSubtract:
					return KeycodesVK.NumpadSubtract;
				case KeyCode.NumpadAdd:
					return KeycodesVK.NumpadAdd;
				case KeyCode.NumpadEnter:
					return KeycodesVK.Enter;
				case KeyCode.NumpadEqual:
					return 0;
				case KeyCode.NumLock:
					return KeycodesVK.NumLock;
				case KeyCode.ArrowUp:
					return KeycodesVK.ArrowUp;
				case KeyCode.ArrowDown:
					return KeycodesVK.ArrowDown;
				case KeyCode.ArrowRight:
					return KeycodesVK.ArrowRight;
				case KeyCode.ArrowLeft:
					return KeycodesVK.ArrowLeft;
				case KeyCode.Insert:
					return KeycodesVK.Insert;
				case KeyCode.Delete:
					return KeycodesVK.Delete;
				case KeyCode.Home:
					return KeycodesVK.Home;
				case KeyCode.End:
					return KeycodesVK.End;
				case KeyCode.PageUp:
					return KeycodesVK.PageUp;
				case KeyCode.PageDown:
					return KeycodesVK.PageDown;
				case KeyCode.F1:
					return KeycodesVK.F1;
				case KeyCode.F2:
					return KeycodesVK.F2;
				case KeyCode.F3:
					return KeycodesVK.F3;
				case KeyCode.F4:
					return KeycodesVK.F4;
				case KeyCode.F5:
					return KeycodesVK.F5;
				case KeyCode.F6:
					return KeycodesVK.F6;
				case KeyCode.F7:
					return KeycodesVK.F7;
				case KeyCode.F8:
					return KeycodesVK.F8;
				case KeyCode.F9:
					return KeycodesVK.F9;
				case KeyCode.F10:
					return KeycodesVK.F10;
				case KeyCode.F11:
					return KeycodesVK.F11;
				case KeyCode.F12:
					return KeycodesVK.F12;
				case KeyCode.F13:
					return KeycodesVK.F13;
				case KeyCode.F14:
					return KeycodesVK.F14;
				case KeyCode.F15:
					return KeycodesVK.F15;
				case KeyCode.F16:
					return KeycodesVK.F16;
				case KeyCode.F17:
					return KeycodesVK.F17;
				case KeyCode.F18:
					return KeycodesVK.F18;
				case KeyCode.F19:
					return KeycodesVK.F19;
				case KeyCode.F20:
					return KeycodesVK.F20;
				case KeyCode.F21:
					return KeycodesVK.F21;
				case KeyCode.F22:
					return KeycodesVK.F22;
				case KeyCode.F23:
					return KeycodesVK.F23;
				case KeyCode.F24:
					return KeycodesVK.F24;
				case KeyCode.CapsLock:
					return KeycodesVK.CapsLock;
				case KeyCode.ScrollLock:
					return KeycodesVK.ScrollLock;
				case KeyCode.PrintScreen:
					return KeycodesVK.PrintScreen;
				case KeyCode.ShiftLeft:
					return KeycodesVK.Shift;
				case KeyCode.ShiftRight:
					return KeycodesVK.Shift;
				case KeyCode.ControlLeft:
					return KeycodesVK.Control;
				case KeyCode.ControlRight:
					return KeycodesVK.Control;
				case KeyCode.AltLeft:
					return KeycodesVK.AltLeft;
				case KeyCode.AltRight:
					return KeycodesVK.AltRight;
				case KeyCode.MetaLeft:
					return KeycodesVK.MetaLeft;
				case KeyCode.MetaRight:
					return KeycodesVK.MetaRight;
				case KeyCode.ContextMenu:
					return KeycodesVK.Menu;
				case KeyCode.MouseLeftClick:
					return KeycodesVK.LeftMouseButton;
				case KeyCode.MouseRightClick:
					return KeycodesVK.RightMouseButton;
				case KeyCode.MouseMiddleClick:
					return KeycodesVK.MiddleMouseButton;
				case KeyCode.MouseWheelUp:
					return KeycodesVK.MouseButton4;
				case KeyCode.MouseWheelDown:
					return KeycodesVK.MouseButton5;
				case KeyCode.MouseWheelUpDown:
					return 0;
				case KeyCode.MouseMoveUp:
					return 0;
				case KeyCode.MouseMoveDown:
					return 0;
				case KeyCode.MouseMoveUpDown:
					return 0;
				case KeyCode.MouseMoveLeft:
					return 0;
				case KeyCode.MouseMoveRight:
					return 0;
				case KeyCode.MouseMoveLeftRight:
					return 0;
				case KeyCode.KeyWKeyS:
					return 0;
				case KeyCode.KeyAKeyD:
					return 0;
				case KeyCode.LeftShiftLeftControl:
					return 0;
				case KeyCode.Numpad4Numpad6:
					return 0;
				case KeyCode.Numpad8Numpad5:
					return 0;
				default:
					return 0;
			}
		}

		public enum KeycodesVK
		{
			LeftMouseButton = 0x01,					//	Left mouse button
			RightMouseButton = 0x02,				//	Right mouse button
			Cancel = 0x03,							//	Control-break processing
			MiddleMouseButton = 0x04,				//	Middle mouse button (three-button mouse)
			MouseButton4 = 0x05,					//	X1 mouse button
			MouseButton5 = 0x06,					//	X2 mouse button
			Backspace = 0x08,						//	BACKSPACE key
			Tab = 0x09,								//	TAB key
			Clear = 0x0C,							//	CLEAR key
			Enter = 0x0D,							//	ENTER key
			Shift = 0x10,							//	SHIFT key
			Control = 0x11,							//	CTRL key
			Menu = 0x12,							//	ALT key
			Pause = 0x13,							//	PAUSE key
			CapsLock = 0x14,						//	CAPS LOCK key
			Escape = 0x1B,							//	ESC key
			Space = 0x20,							//	SPACEBAR
			PageUp = 0x21,                          //	PAGE UP key
			PageDown = 0x22,                        //	PAGE DOWN key
			End = 0x23,								//	END key
			Home = 0x24,                            //	HOME key
			ArrowLeft = 0x25,						//	LEFT ARROW key
			ArrowUp = 0x26,                         //	UP ARROW key
			ArrowRight = 0x27,                      //	RIGHT ARROW key
			ArrowDown = 0x28,                       //	DOWN ARROW key
			Select = 0x29,                          //	SELECT key
			Print = 0x2A,							//	PRINT key
			Execute = 0x2B,							//	EXECUTE key
			PrintScreen = 0x2C,						//	PRINT SCREEN key
			Insert = 0x2D,                          //	INS key
			Delete = 0x2E,                          //	DEL key
			Help = 0x2F,							//	HELP key
			Key0 = 0x30,							//	0 key
			Key1 = 0x31,							//	1 key
			Key2 = 0x32,							//	2 key
			Key3 = 0x33,							//	3 key
			Key4 = 0x34,							//	4 key
			Key5 = 0x35,							//	5 key
			Key6 = 0x36,							//	6 key
			Key7 = 0x37,							//	7 key
			Key8 = 0x38,							//	8 key
			Key9 = 0x39,							//	9 key
			KeyA = 0x41,							//	A key
			KeyB = 0x42,							//	B key
			KeyC = 0x43,							//	C key
			KeyD = 0x44,							//	D key
			KeyE = 0x45,							//	E key
			KeyF = 0x46,							//	F key
			KeyG = 0x47,							//	G key
			KeyH = 0x48,							//	H key
			KeyI = 0x49,							//	I key
			KeyJ = 0x4A,							//	J key
			KeyK = 0x4B,							//	K key
			KeyL = 0x4C,							//	L key
			KeyM = 0x4D,							//	M key
			KeyN = 0x4E,							//	N key
			KeyO = 0x4F,							//	O key
			KeyP = 0x50,							//	P key
			KeyQ = 0x51,							//	Q key
			KeyR = 0x52,							//	R key
			KeyS = 0x53,							//	S key
			KeyT = 0x54,							//	T key
			KeyU = 0x55,							//	U key
			KeyV = 0x56,							//	V key
			KeyW = 0x57,							//	W key
			KeyX = 0x58,							//	X key
			KeyY = 0x59,							//	Y key
			KeyZ = 0x5A,							//	Z key
			MetaLeft = 0x5B,                        //	Left Windows key(Natural keyboard)
			MetaRight = 0x5C,                       //	Right Windows key(Natural keyboard)
			Sleep = 0x5F,							//	Computer Sleep key
			Numpad0 = 0x60,							//	Numeric keypad 0 key
			Numpad1 = 0x61,							//	Numeric keypad 1 key
			Numpad2 = 0x62,							//	Numeric keypad 2 key
			Numpad3 = 0x63,							//	Numeric keypad 3 key
			Numpad4 = 0x64,							//	Numeric keypad 4 key
			Numpad5 = 0x65,							//	Numeric keypad 5 key
			Numpad6 = 0x66,							//	Numeric keypad 6 key
			Numpad7 = 0x67,							//	Numeric keypad 7 key
			Numpad8 = 0x68,							//	Numeric keypad 8 key
			Numpad9 = 0x69,							//	Numeric keypad 9 key
			NumpadMultiply = 0x6A,					//	Multiply key
			NumpadAdd = 0x6B,                       //	Add key
			NumpadSubtract = 0x6D,                  //	Subtract key
			NumpadDecimal = 0x6E,                   //	Decimal key
			NumpadDivide = 0x6F,                    //	Divide key
			F1 = 0x70,								//	F1 key
			F2 = 0x71,								//	F2 key
			F3 = 0x72,								//	F3 key
			F4 = 0x73,								//	F4 key
			F5 = 0x74,								//	F5 key
			F6 = 0x75,								//	F6 key
			F7 = 0x76,								//	F7 key
			F8 = 0x77,								//	F8 key
			F9 = 0x78,								//	F9 key
			F10 = 0x79,								//	F10 key
			F11 = 0x7A,								//	F11 key
			F12 = 0x7B,								//	F12 key
			F13 = 0x7C,								//	F13 key
			F14 = 0x7D,								//	F14 key
			F15 = 0x7E,								//	F15 key
			F16 = 0x7F,								//	F16 key
			F17 = 0x80,								//	F17 key
			F18 = 0x81,								//	F18 key
			F19 = 0x82,								//	F19 key
			F20 = 0x83,								//	F20 key
			F21 = 0x84,								//	F21 key
			F22 = 0x85,								//	F22 key
			F23 = 0x86,								//	F23 key
			F24 = 0x87,								//	F24 key
			NumLock = 0x90,							//	NUM LOCK key
			ScrollLock = 0x91,						//	SCROLL LOCK key
			ShiftLeft = 0xA0,						//	Left SHIFT key
			ShiftRight = 0xA1,						//	Right SHIFT key
			ControlLeft = 0xA2,						//	Left CONTROL key
			ControlRight = 0xA3,					//	Right CONTROL key
			AltLeft = 0xA4,							//	Left MENU key
			AltRight = 0xA5,						//	Right MENU key

			OEM1 = 0xBA,							//	Used for miscellaneous characters; it can vary by keyboard.For the US standard keyboard, the ';:' key
			OEMPlus = 0xBB,							//	For any country/region, the '+' key
			OEMComma = 0xBC,						//	For any country/region, the ',' key
			OEMMinus = 0xBD,						//	For any country/region, the '-' key
			OEMPeriod = 0xBE,						//	For any country/region, the '.' key
			OEM2 = 0xBF,							//	Used for miscellaneous characters; it can vary by keyboard.For the US standard keyboard, the '/?' key
			OEM3 = 0xC0,							//	Used for miscellaneous characters; it can vary by keyboard.For the US standard keyboard, the '`~' key
			OEM4 = 0xDB,							//	Used for miscellaneous characters; it can vary by keyboard.For the US standard keyboard, the '[{' key
			OEM5 = 0xDC,							//	Used for miscellaneous characters; it can vary by keyboard.For the US standard keyboard, the '\|' key
			OEM6 = 0xDD,							//	Used for miscellaneous characters; it can vary by keyboard.For the US standard keyboard, the ']}' key
			OEM7 = 0xDE,							//	Used for miscellaneous characters; it can vary by keyboard.For the US standard keyboard, the 'single-quote/double-quote' key
			OEM8 = 0xDF,							//	Used for miscellaneous characters; it can vary by keyboard.
			OEM102 = 0xE2,							//	Either the angle bracket key or the backslash key on the RT 102-key keyboard
		}
	}
}
