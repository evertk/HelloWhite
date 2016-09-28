using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

			var app = Application.Launch(location + "..\\..\\..\\White-Test\\bin\\Debug\\White-Test.exe");
			var win = app.GetWindow("MainWindow");


			var button = win.Get<Button>(SearchCriteria.ByAutomationId("Knopje"));
			button.Click();

			var lbl = win.Get<WPFLabel>(SearchCriteria.ByAutomationId("Textje"));

			Assert.AreEqual("Task Finished!", lbl.Text);

			app.Kill();
		}

	}
}
