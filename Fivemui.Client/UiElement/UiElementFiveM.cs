using System;
using System.Collections.Generic;
using CitizenFX.Core.Native;
using NFive.SDK.Core.Diagnostics;
using Gaston11276.SimpleUi;

namespace Gaston11276.Fivemui
{
	public class UiElementFiveM: UiElement, IUiElement
	{
		static public ILogger Logger;
		public Guid Id;
		public delegate void fpGuid(Guid id);
		protected List<fpGuid> callbacksOnSelectId = new List<fpGuid>();
		protected List<fpVoid> callbacksOffSelect = new List<fpVoid>();
		protected List<fpVoid> onDisableCallbacks = new List<fpVoid>();
		protected List<fpVoid> offDisableCallbacks = new List<fpVoid>();

		protected Argb color;
		protected Argb colorFocus;
		protected Argb colorSelected;
		protected Argb colorDisabled;

		public UiElementFiveM()
		{
			Type = UiElementType.Rectangle;

			color = new Argb(100, 20, 20, 20);
			colorFocus = new Argb(100, 200, 200, 100);
			colorSelected = new Argb(100, 100, 100, 200);
			colorDisabled = new Argb(50, 20, 20, 20);
		}

		public void SetLogger(ILogger Logger)
		{
			UiElementFiveM.Logger = Logger;
		}

		public override void AddElement(UiElement element)
		{
			((UiElementFiveM)element).SetLogger(Logger);
			base.AddElement(element);
		}

		public void RegisterOnSelectIdCallback(fpGuid OnSelectId)
		{
			callbacksOnSelectId.Add(OnSelectId);
		}

		public void RegisterOffSelect(fpVoid OffSelect)
		{
			callbacksOffSelect.Add(OffSelect);
		}

		public override void OnFocus()
		{
			if ((flags & SELECTED) == 0)
			{
				colorBackground = colorFocus;
			}
		}

		public override void OffFocus()
		{
			if ((flags & SELECTED) == 0)
			{
				colorBackground = color;
			}
		}

		public override void OnSelect()
		{
			colorBackground = colorSelected;
			OnSelectId(Id);
		}

		public override void OffSelect()
		{
			colorBackground = color;
			foreach (fpVoid OffSelect in callbacksOffSelect)
			{
				OffSelect();
			}
		}

		public override void OnDisabled()
		{
			colorBackground = colorDisabled;
			foreach (fpVoid OnDisable in onDisableCallbacks)
			{
				OnDisable();
			}
		}

		public override void OffDisabled()
		{
			colorBackground = color;
			foreach (fpVoid OffDisable in offDisableCallbacks)
			{
				OffDisable();
			}
		}

		public void OnSelectId(Guid Id)
		{
			foreach (fpGuid  OnSelectId in callbacksOnSelectId)
			{
				OnSelectId(Id);
			}
		}

		public bool GetSelection(ref UiElement selectedElement)
		{
			foreach (UiElement element in elements)
			{
				if ((element.GetFlags() & SELECTED) != 0)
				{
					selectedElement = (UiElementFiveM)element;
					return true;
				}
			}
			return false;
		}

		public void Enable()
		{
			ClearFlags(DISABLED);
			OffDisabled();
		}

		public void Disable()
		{
			SetFlags(DISABLED);
			OnDisabled();
		}

		public void Select()
		{
			SetFlags(SELECTED);
		}

		public void Deselect()
		{
			ClearFlags(SELECTED);
		}

		public override void Draw()
		{
			if ((flags & HIDDEN) != 0)
			{
				return;
			}

			if ((flags & TRANSPARENT) == 0)
			{
				API.DrawRect(drawingRectangle.CenterX(),
							drawingRectangle.CenterY(),
							drawingRectangle.Width(),
							drawingRectangle.Height(),
							colorBackground.GetRed(),
							colorBackground.GetGreen(),
							colorBackground.GetBlue(),
							colorBackground.GetAlpha());
			}
			

			foreach (UiElement element in elements)
			{
				element.Draw();
			}
		}
	} 
}
