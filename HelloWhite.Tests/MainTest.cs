using System;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace HelloWhite.Tests
{
	[TestFixture]
	class MainTest
	{
		[Test]
		public void TheTest()
		{
			string location = AppDomain.CurrentDomain.BaseDirectory;

			var app = Application.Launch(location + "..\\..\\..\\HelloWhite\\bin\\Debug\\HelloWhite.exe");
			var win = app.GetWindow("MainWindow");


			var button = win.Get<Button>(SearchCriteria.ByAutomationId("Knopje"));
			button.Click();

			var lbl = win.Get<WPFLabel>(SearchCriteria.ByAutomationId("Textje"));

			Assert.AreEqual("Task Finished!", lbl.Text);

			app.Kill();
		}

	}
}
