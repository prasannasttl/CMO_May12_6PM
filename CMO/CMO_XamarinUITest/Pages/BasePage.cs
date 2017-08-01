using System;
using NUnit.Framework;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Linq;

namespace CMO_UITest
{
	public class BasePage
	{
		protected readonly IApp app;
		protected readonly bool OnAndroid;
		protected readonly bool OniOS;

		protected BasePage(IApp app, Platform platform)
		{
			this.app = app;
			OnAndroid = platform == Platform.Android;
			OniOS = platform == Platform.iOS;
		}

		///Android 
		protected BasePage(IApp app, Platform platform, Func<AppQuery, AppQuery> androidTrait, Func<AppQuery, AppQuery> iOSTrait)
			: this(app, platform)
		{
			if (OnAndroid)
				Assert.DoesNotThrow(() => app.WaitForElement(androidTrait), "Unable to verify on page: " + this.GetType().Name);
			if (OniOS)
				Assert.DoesNotThrow(() => app.WaitForElement(iOSTrait), "Unable to verify on page: " + this.GetType().Name);
			app.Screenshot("On " + this.GetType().Name);
		}

		///iOS
		protected BasePage(IApp app, Platform platform, string androidTrait, string iOSTrait)
			: this(app, platform, x => x.Marked(androidTrait), x => x.Marked(iOSTrait))
		{
		}

		/// <summary>
		/// Gets the name of the text.
		/// </summary>
		/// <returns>The text name.</returns>
		/// <param name="queryText">Query text.</param>
		/// <param name="index">Index.</param>
		public string GetTextName(Func<AppQuery, AppQuery> queryText, int index)
		{
			string textName = string.Empty;
			try
			{
				AppResult[] lstItemText = app.Query(queryText);
				if (lstItemText.Count() > 0)
				{
					textName = lstItemText[index].Text;
				}
			}
			catch (Exception ex)
			{
				app.WaitForNoElement("Wait till scroll down");
				app.Screenshot("Exception Error - GetTextName");
				Assert.Fail("Exception Error - GetTextName " + ex.Message);
			}
			return textName;
		}

		/// <summary>
		/// Selectd the item in list.
		/// </summary>
		/// <param name="queries">Queries.</param>
		/// <param name="selectedItem">selected item.</param>
		public void SelectItemInList(Func<AppQuery, AppQuery> queries, string selectedItem, string scrollSide)
		{
			String afterScroll, beforeScroll;
			try
			{
				if (selectedItem != string.Empty)
				{
					AppResult[] lstItemList = app.Query(queries);
					if (lstItemList.Count() > 0)
					{
						do
						{
							beforeScroll = lstItemList[0].Text;
							afterScroll = lstItemList[0].Text;
							if (lstItemList.Any(p => p.Text == selectedItem))
							{
								app.Tap(selectedItem);
								app.Screenshot("Item with name (" + selectedItem + ") is tapped in list");
							}
							else
							{
								if (scrollSide == "Down")
								{
									app.ScrollDown();
								}
								else
								{
									app.ScrollUp();
								}
								app.WaitForNoElement("Waiting for item list");
								lstItemList = app.Query(queries);
								afterScroll = lstItemList[0].Text;
							}
						}
						while (beforeScroll != afterScroll);
					}
				}
			}
			catch (Exception ex)
			{
				app.WaitForNoElement("Waiting for item found");
				app.Screenshot("Exception Error - SelectItemInList");
				Assert.Fail("Exception Error - SelectItemInList " + ex.Message);
			}
		}

		/// <summary>
		/// Waits the till load.
		/// </summary>
		/// <param name="queries">Queries.</param>
		public void WaitTillLoad(Func<AppQuery, AppQuery> queries)
		{
			try
			{
				int index = 0;
				bool needWait = true;
				while (needWait)
				{
					AppResult[] lstRes = app.Query(queries);
					if (lstRes.Count() > 0)
					{
						needWait = false;
					}
					else
					{
						app.WaitForNoElement("Waiting for control");
					}
					//Wait for 5 times in loop
					index++;
					if (index > 4)
					{
						break;
					}
				}
			}
			catch (Exception)
			{
				app.WaitForNoElement("Waiting for control");
				app.Screenshot("Exception Error - WaitTillLoad " + queries.ToString());
				Assert.Fail("Exception Error - WaitTillLoad " + queries.ToString());
			}
		}
	}
}