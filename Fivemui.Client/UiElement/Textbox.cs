using System.Collections.Generic;
using static CitizenFX.Core.Native.API;
using Gaston11276.SimpleUi;

namespace Gaston11276.Fivemui
{
	public class Textbox : UiElementFiveM
	{		
		Argb textColor;
		Argb textColorDefault;
		Argb textColorDisabled;
		private int fontIndex = 0;
		private float fontSize = 0.3f;
		protected int textFlags;
		protected string text;
		private float textWidth;
		private float textHeight;
		private bool needRefresh;

		List<fpVoid> callbacksOnTextChanged;

		public Textbox()
		{
			Type = UiElementType.Textbox;
			textFlags = 0;
			textColor = new Argb(0xFFFFFFFF);
			textColorDefault = textColor;
			textColorDisabled = new Argb(0x80FFFFFF);
			text = "";
			needRefresh = true;

			callbacksOnTextChanged = new List<fpVoid>();
		}

		public void SetTextFlags(int flags)
		{
			textFlags |= flags;
		}

		public void ClearTextFlags(int flags)
		{
			textFlags &= ~flags;
		}

		public void RegisterOnTextChanged(fpVoid OnTextChanged)
		{
			callbacksOnTextChanged.Add(OnTextChanged);
		}

		private void RunOnTextChangedCallbacks()
		{
			foreach (fpVoid OnTextChanged in callbacksOnTextChanged)
			{
				OnTextChanged();
			}
		}

		protected void TextChanged()
		{
			needRefresh = true;
			Refresh();
			Redraw();
			RunOnTextChangedCallbacks();
		}
		
		public void SetFont(string fontName, int fontSize)
		{
			SetTextFont(0);
			TextChanged();
		}

		public void SetFontSize(float fontSize)
		{
			this.fontSize = fontSize;
		}

		public void SetFont(Font font)
		{
			this.fontIndex = (int)font;
			TextChanged();
		}

		public override void SetText(string text)
		{
			this.text = text;
			TextChanged();
		}

		public string GetText()
		{
			return this.text;
		}

		public void ClearText()
		{
			this.text = "";
			TextChanged();
		}


		public void SetTextColor(int ARGB)
		{
			textColor.SetARGB(ARGB);
		}

		public override void OnDisabled()
		{
			textColor = textColorDisabled;
			colorBackground = colorDisabled;

			foreach (fpVoid OnDisable in onDisableCallbacks)
			{
				OnDisable();
			}
		}

		public override void OffDisabled()
		{
			textColor = textColorDefault;
			colorBackground = color;

			foreach (fpVoid OffDisable in offDisableCallbacks)
			{
				OffDisable();
			}
		}

		protected override float GetContentWidth()
		{
			BeginTextCommandWidth("STRING");
			SetTextScale(1f, fontSize);
			SetTextFont(fontIndex);
			AddTextComponentString(this.text);
			textWidth = EndTextCommandGetWidth(false);
			return textWidth;
		}
		protected override float GetContentHeight()
		{
			float sy = screenResolutionX / screenResolutionY;
			textHeight = (1f/sy)*GetTextScaleHeight(fontSize, (int)fontIndex);
			return textHeight;
		}

		public override void Draw()
		{
			UiRectangle textRectangle = new UiRectangle();

			base.Draw();

			if ((flags & HIDDEN) != 0)// || (textFlags & TRANSPARENT) != 0)
			{
				return;
			}
			
			BeginTextCommandDisplayText("STRING");
			SetTextScale(1f, fontSize);
			SetTextFont(fontIndex);

			if ((textFlags & UiElementTextbox.TEXT_OUTLINE) != 0)
			{
				SetTextOutline();
			}

			SetTextCentre(true);

			float textX = 0f;
			if (this.hGravity == HGravity.Left)
			{
				textX = drawingRectangle.Left() - (Padding.Left() * screenBoundaries.Width());
				SetTextJustification(1);//0 center, 1 left, 2 right
			}
			else if (this.hGravity == HGravity.Center)
			{
				SetTextJustification(0);
				textX = drawingRectangle.CenterX();
			}
			else if (this.hGravity == HGravity.Right)
			{
				//SetTextRightJustify(true);
				SetTextJustification(2);
				SetTextWrap(drawingRectangle.Left(), drawingRectangle.Right());
				textX = drawingRectangle.Right() - (Padding.Right() * screenBoundaries.Width());
			}

			float text_x = textX;
			float text_y = drawingRectangle.Top() + (textHeight * 0.15f);

			SetTextColour(textColor.GetRed(), textColor.GetGreen(), textColor.GetBlue(), textColor.GetAlpha());
			AddTextComponentString(this.text);
			EndTextCommandDisplayText(text_x, text_y);
			//ResetScriptGfxAlign();

			if (this.needRefresh)
			{
				needRefresh = false;
			}
		}
	}
}
