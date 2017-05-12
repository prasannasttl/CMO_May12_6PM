using CMO.MenuController;
using CMO.ServicesClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace CMO.JoinUs
{
    public partial class CMFellowShip : ContentPage
    {
        public CMFellowShip()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            this.Title = AppResources.LCmInternshipProgram.ToUpper();
            Device.StartTimer(TimeSpan.FromSeconds(3), () => {
                loading.IsRunning = false; loading.IsVisible = false;
                return false;
            });
        }
        private string CreateHTML(string webcontent)
        {
            string css = "<!doctype html>" +
                                       "<head>" +
                                       "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no\">" +
                                       "<link href='https://cmo.maharashtra.gov.in/sites/all/themes/maharastracmonew/css/style.css' rel=\"stylesheet\">" +
                                       "<link href='https://cmo.maharashtra.gov.in/sites/all/themes/maharastracmonew/css/responsive.css' rel=\"stylesheet\">" +

                                         "<link href = 'https://cmo.maharashtra.gov.in/sites/all/themes/maharastracmonew/css/mob-app-theme.css' rel = \"stylesheet\">" +

                                       "<script src=\"https://cmo.maharashtra.gov.in/sites/all/themes/maharastracmonew/js/jquery-min.js\">" +
                                       "</script>" +
                                       "<script>" +
                                       "$(document).ready(function(){ if( $(\".tableData\").length > 0){$('.tableData').each(function(){$(this).find('tr').each(function(){$(this).find('td:first').addClass('firstTd'); $(this).find('th:first').addClass('firstTh');$(this).find('th:last').addClass('lastTh');});$(this).find('tr:last').addClass('lastTr');$(this).find('tr:even').addClass('evenRow');$(this).find('tr:nth-child(2)').find('th:first').removeClass('firstTh');});};if( $(\".responsiveTable, .Responsivetable, .views-table\").length){$(\".responsiveTable, .Responsivetable, .views-table\").each(function(){$(this).wrap('<div class=\"tableOut\"></div>');$(this).find('td').removeAttr('width');var head_col_count =  $(this).find('tr th').size();for ( i=0; i <= head_col_count; i++ )  {var head_col_label = $(this).find('tr th:nth-child('+ i +')').text();$(this).find('tr td:nth-child('+ i +')').attr(\"data-label\", head_col_label);}});};if( $(\".tableScroll\").length){$(\".tableScroll\").each(function(){$(this).wrap('<div class=\"tableOut\"></div>');});};});</script><style>.bgColorWhite { padding: 10px; background-color: #fff; }.respImg img { width: 100%%!important; height: auto!important; }.respImg img.pdfIcon { width: auto!important; }.respImg img.extIcon { width: auto!important; }.respImg img.file-icon { width: auto!important; }.respImg img.rtecenter { width: auto!important; } " +
                                       "</style>" +
                                       "</head>" +
                                       "<body class=\"respImg\">" +
                                      
                                       webcontent +
                                      "</body>" +
                "</html>";

            return css;
        }
        protected async override void OnAppearing()
        {
            Application.Current.Properties["CurrentPage"] = "cminternship";
            if (!App.CheckInternetConnection())
            {
                loading.IsRunning = false; loading.IsVisible = false;
                await DisplayAlert(AppResources.LNetworkError, AppResources.LNoInternetConnection, AppResources.LOk);
            }
            else
            {
                await CallWebService();
            }
        }
        private async Task CallWebService()
        {
            if (!App.CheckInternetConnection())
            {
                loading.IsRunning = false; loading.IsVisible = false;
                await DisplayAlert(AppResources.LNetworkError, AppResources.LNoInternetConnection, AppResources.LOk);
            }
            else
            {
                try
                {
                    List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
                    string lang = "";
                    if (Application.Current.Properties.ContainsKey("Language"))
                    { lang = Application.Current.Properties["Language"] as string; }

                    if (lang == "en")
                        values.Add(new KeyValuePair<string, string>("page_id", "639"));
                    else
                        values.Add(new KeyValuePair<string, string>("page_id", "640"));

                    var response = await GeneralClass.GetResponse<RootObject>(CMO.ServiceLayer.ServiceLinks.webviewPageContentURL, values);
                    if (response != null)
                    {
                        if (response._resultflag == 1)
                        {
                            var webcontent = response.page_content;
                            var HTMLString = CreateHTML(webcontent);
                            //  Title = response.page_title;
                            var html = new HtmlWebViewSource
                            {
                                Html = HTMLString
                            };
                            web.Source = html;

                            web.Navigating += async (s, e) =>
                            {
                                if (e.Url.StartsWith("http"))
                                {
                                    try
                                    {
                                        var uri = new Uri(e.Url);
                                        Device.OpenUri(uri);
                                    }
                                    catch (Exception)
                                    {
                                        if (App.CurrentPage() == "cminternship")
                                            await DisplayAlert(AppResources.LError, AppResources.LWebserverNotResponding, AppResources.LOk);
                                    }
                                    e.Cancel = true;
                                }
                            };
                        }
                        else
                        {
                            if (App.CurrentPage() == "cminternship")
                                await DisplayAlert(AppResources.LError, AppResources.LSomethingWentWrong, AppResources.LOk);
                        }
                    }
                    else
                    {
                        if (App.CurrentPage() == "cminternship")
                            await DisplayAlert(AppResources.LError, AppResources.LSomethingWentWrong, AppResources.LOk);
                    }
                }
                catch (WebException ex)
                {
                    if (App.CurrentPage() == "cminternship")
                    {
                        if (ex.Message.Contains("Network"))
                            await DisplayAlert(AppResources.LError, AppResources.LWebserverNotResponding, AppResources.LOk);
                    }
                }
            }
        }

        #region Exit Application
        private bool _canClose = true;

        protected override bool OnBackButtonPressed()
        {
            //if (_canClose)
            //{
            //    ShowExitDialog();
            //}
            //return _canClose;
            if (Navigation.NavigationStack.Count == 1)
            {
                Application.Current.MainPage = new SideMenu();
                return true;
            }
            else
            {
                return false;
            }
        }

        private async void ShowExitDialog()
        {
            var answer = await DisplayAlert(AppResources.LExit, AppResources.LExitApp, AppResources.LYes, AppResources.LNo);
            if (answer)
            {
                if (Device.OS == TargetPlatform.Android)
                {
                    DependencyService.Get<IAndroidMethods>().CloseApp();
                }
                _canClose = false;
                OnBackButtonPressed();
            }
        }
        #endregion
    }
}
