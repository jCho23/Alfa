using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;

namespace Alfa
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void Repl()
		{
			app.Repl();
		}

		[Test]
		public void FirstTest()
		{
			app.Tap(x => x.Class("android.widget.Button").Index(5));
			app.Screenshot("Let's start by Tapping on the 'Toolkit'");

			app.Tap(x => x.Class("android.widget.Button").Index(0));
			app.Screenshot("Then we Tapped on the 'Find It' Button");

			app.Tap("Alfa Office");
			app.Screenshot("Next we Tapped on 'Alfa Office'");
			app.Tap("OK");
			app.Screenshot("We Tapped 'OK' to dismiss the message");
			app.Back();
			app.Screenshot("We Tapped the 'Back' Button");
			app.Tap(x => x.Class("android.widget.Button").Index(2));
			app.Screenshot("Then we Tapped on the Home Button");

			app.Tap(x => x.Class("android.widget.Button").Index(1));
			app.Screenshot("We Tapped on 'My Alfa Policies'");

			Thread.Sleep(8000);
			app.Tap(x => x.Class("android.widget.Button").Index(2));
			app.Screenshot("Then we Tapped on the Home Button to return");

			app.Tap(x => x.Class("android.widget.ImageView").Index(0));
			app.Screenshot("Next we Tapped on 'Click Here'");
			app.Tap("Cancel");
			app.Screenshot("We Tapped Cancel to stay within the app");

		}
	}
}
