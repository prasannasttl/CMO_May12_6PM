using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace CMO_UITest
{
	public class ProfileTest : AbstractSetup
	{
		private string errMessage = string.Empty;

		public ProfileTest(Platform platform) : base(platform) { }

        
		[Category("HomePage")]
		[Test]
		public void A_Home_Page_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new HomePage(app, platform).AppLaunches();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur - Loading the Application First Page " + ex.Message);
			}
		}

		
		#region Navigation Menu
		[Category("Team COM")]
		[Test]
		public void B_Team_COM_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new CMOffice(app, platform).TeamCMO();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur - Team CMO Page Navigation" + ex.Message);

			}
		}

		[Category("Former Maharashtra Chief Minister ")]
		[Test]
		public void C_Former_Maharashtra_Chief_Minister_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new CMOffice(app, platform).FormerMaharashtraCM();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur - Former Maharashtra Chief Minister Page Navigation" + ex.Message);


			}
		}

		[Category("Contact The CMO ")]
		[Test]
		public void D_Contact_The_CMO_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new CMOffice(app, platform).ContactTheCMO();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur - Contact the CMO Page Navigation" + ex.Message);

			}
		}

		[Category("Meet The Chief Minister")]
		[Test]
		public void E_Meet_The_Chief_Minister_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new MeetTheCM(app, platform).MeetTheCMNav();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur - Meet The Chief Minister  Page Navigation" + ex.Message);

			}
		}


		[Category("Initiatives")]
		[Test]
		public void F_Initiatives_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new Initiatives(app, platform).InitiativesNav();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur - Initiatives Page Navigation" + ex.Message);

			}		}

		[Category("Team Maharashtra")]
		[Test]
		public void G_Team_Maharashtra_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new Team_Maharashtra(app, platform).TeamMaharashtraNav();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur - Team Maharashtra Page Navigation" + ex.Message);

			}		}

		[Category("Chief Minister In Action")]
		[Test]
		public void H_Chief_Minister_In_Action_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new CM_In_Action(app, platform).CMInActionNav();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur - Chief Minister In Action Page Navigation" + ex.Message);

			}		}

		[Category("NEWS Updates")]
		[Test]
		public void I_NEWS_Updates_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new Media_Library(app, platform).NEWSUpdates();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur - NEWS UPDATES Page Navigation" + ex.Message);

			}
		}


		[Category("Press Releases")]
		[Test]
		public void J_Press_Releases_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new Media_Library(app, platform).PressReleases();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur - Press Releases Page Navigation" + ex.Message);
			}
		}


		[Category("Photo Gallery")]
		[Test]
		public void K_Photo_Gallery_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new Media_Library(app, platform).PhotoGallery();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur -Photo Gallery Page Navigation" + ex.Message);

			}
		}

		[Category("Video Gallery")]
		[Test]
		public void L_Video_Gallery_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new Media_Library(app, platform).VideoGallery();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur - Video Gallery Page Navigation" + ex.Message);
			}
		}

		[Category("Publication Gallery")]
		[Test]
		public void O_Publication_Gallery_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new Media_Library(app, platform).PublicationGallery();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur -Publication Gallery Page Navigation" + ex.Message);

			}
		}

		[Category("Events Calendar")]
		[Test]
		public void M_Events_Calendar_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new Media_Library(app, platform).EventsCalendar();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur -Events Calendar Page Navigation" + ex.Message);


			}
		}


		[Category("Join US")]
		[Test]
		public void N_Join_US_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new JoinUS(app, platform).JoinUsNav();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur -Join US Page Navigation" + ex.Message);
			}
		}


		[Category("Change Language")]
		[Test]
		public void O_Change_Language_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new ChangeLanguage(app, platform).ChangeLang();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur -Change Language Page Navigation" + ex.Message);
			}
		}

		#endregion







		/// <summary>
		/// /////////
		/// </summary>






		[Category("Main Application Page")]
		[Test]
		public void P_Main_Application_Page_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new MainPage(app, platform).Main();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur - Home Page" + ex.Message);
			}		}

		[Category("Meet the CM Page")]
		[Test]
		public void Q_Meet_the_CM_Page_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new MeetTheCM(app, platform).MeetCM();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur - Meet the CM Page" + ex.Message);

			}
		}

		[Category("CM In Action")]
		[Test]
		public void R_CM_In_Action_Page_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new CM_In_Action(app, platform).CMInAction();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur - CM In Action Page" + ex.Message);
			}
		}

		[Category("Team Maharashtra Page")]
		[Test]
		public void S_Team_Maharashtra_Page_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new Team_Maharashtra(app, platform).TeamMaharashtra();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur - Team Maharashtra Page " + ex.Message);
			}
		}

		[Category("Initiative Page")]
		[Test]
		public void T_Initiative_Page_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new Initiatives(app, platform).Initiative();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur - Initiatives Page " + ex.Message);

			}
		}

		[Category("Join US Page")]
		[Test]
		public void U_Join_US_Page_Test()
		{
			try
			{
				CheckInternetConnection();

				errMessage = new JoinUS(app, platform).JoinUs();
				ErrorMessageDisplay(errMessage);
			}
			catch (Exception ex)
			{
				Assert.Fail("Exception occur -Join US Page " + ex.Message);
			}
		}

	}
}