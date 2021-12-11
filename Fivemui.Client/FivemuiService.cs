using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using NFive.SDK.Client.Commands;
using NFive.SDK.Client.Communications;
using NFive.SDK.Client.Events;
using NFive.SDK.Client.Interface;
using NFive.SDK.Client.Services;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Models.Player;

using Gaston11276.Fivemui.Client.Overlays;

namespace Gaston11276.Fivemui.Client
{
	[PublicAPI]
	public class FivemuiService : Service
	{
		public FivemuiService(ILogger logger, ITickManager ticks, ICommunicationManager comms, ICommandManager commands, IOverlayManager overlay, User user) : base(logger, ticks, comms, commands, overlay, user) { }
		
		public override async Task Started()
		{
			UiElementFiveM.Logger = Logger;
			WindowManager.Delay = Delay;
			WindowManager.OnResolutionChanged(); // Should be called if resolution (or screen size) is changed.

			this.Ticks.On(new Action(WindowManager.OnFiveMInput));
			this.Ticks.On(new Action(WindowManager.OnDraw));

			WindowManager.overlay = new FivemuiOverlay(OverlayManager);
			WindowManager.Init();

			await Delay(10);
		}
	}
}
