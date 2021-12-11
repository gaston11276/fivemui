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
		protected List<fpGuid> callbacksOnSelectId;

		public UiElementFiveM()
		{
			Type = UiElementType.Rectangle;
			callbacksOnSelectId = new List<fpGuid>();
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

		protected override void OnFocus()
		{
			if ((flags & SELECTED) == 0)
			{
				currentColorBackground = colorFocus;
			}
		}

		protected override void OffFocus()
		{
			if ((flags & SELECTED) == 0)
			{
				currentColorBackground = colorBackground;
			}
		}

		protected override void OnSelect()
		{
			currentColorBackground = colorSelected;
		}

		protected override void OffSelect()
		{
			currentColorBackground = colorBackground;
		}

		public new void OnDisabled()
		{
			currentColorBackground = colorDisabled;
		}

		public new void OffDisabled()
		{
			currentColorBackground = colorBackground;
		}

		protected override void RunOnSelectCallbacks()
		{
			base.RunOnSelectCallbacks();

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
		}

		public void Disable()
		{
			SetFlags(DISABLED);
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
							currentColorBackground.GetRed(),
							currentColorBackground.GetGreen(),
							currentColorBackground.GetBlue(),
							currentColorBackground.GetAlpha());
			}
			

			foreach (UiElement element in elements)
			{
				element.Draw();
			}
		}
	} 
}
