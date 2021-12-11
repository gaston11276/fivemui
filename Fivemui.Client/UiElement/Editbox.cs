namespace Gaston11276.Fivemui
{
	public class Editbox : Textbox
	{
		public Editbox()
		{
			
		}

		public void OnKey(int state, int keycode)
		{
			if ((flags & SELECTED) != 0)
			{				
				if (state == 3 && keycode >= 48 && keycode <= 57)
				{
			
				}
				else if (state == 3 && keycode >= 65 && keycode <= 90)
				{		
					string input = ((char)keycode).ToString();

					if (text.Length == 0)
					{
						text += input.ToUpper();
					}
					else
					{
						text += input.ToLower();
					}	
					TextChanged();
				}
				
				else if (state == 3 && keycode == 8)
				{
					// Backspace
					if (text.Length > 0)
					{
						text = text.Remove(text.Length - 1, 1);
						TextChanged();
					}
				}
			}
		}
	}
}
