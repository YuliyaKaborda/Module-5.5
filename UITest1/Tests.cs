using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest1
{
	[TestFixture(Platform.Android)]
	public class Tests
	{
		IApp app;
		Platform platform;
		public const string item = "Michael Kors Type 8 for iPhone 5/5S";
		public const string searchTerm = "Iphone 8";
		public const string elementId = "toolbar";

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
		public void AppLaunches()
		{
			app.WaitForElement(c => c.Marked("Добро пожаловать!"));
			app.Tap(c => c.Id("nextView"));
			app.Tap(c => c.Id("nextView"));
			app.Tap(c => c.Id("nextView"));
			app.Tap(c => c.Id("nextView"));
			app.Tap(c => c.Id("nextView"));
			var element = app.WaitForElement(c => c.Id(elementId), "Timed out waiting for element");
			Assert.IsTrue(element.Length == 1 && element[0].Id == elementId);
		}

		[Test]
		public void AppSearch()
		{
			app.WaitForElement(c => c.Marked("Добро пожаловать!"));
			app.Tap(c => c.Id("nextView"));
			app.Tap(c => c.Id("nextView"));
			app.Tap(c => c.Id("nextView"));
			app.Tap(c => c.Id("nextView"));
			app.Tap(c => c.Id("nextView"));
			app.WaitForElement(c => c.Id("toolbar"));
			app.Tap(c => c.Id("menu_search"));
			app.EnterText(c => c.Id("search_src_text"), searchTerm);
			app.DismissKeyboard();
			app.ScrollDownTo(c => c.Marked(item));
			app.Tap(c => c.Marked(item));
			var label = app.WaitForElement(c => c.Marked(item));
			app.Back();
			Assert.IsTrue(label[0].Text == item);
		}
	}
}

