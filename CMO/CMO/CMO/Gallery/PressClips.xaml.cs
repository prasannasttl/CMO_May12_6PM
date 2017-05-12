using CMO.MenuController;
using CMO.ServicesClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CMO.Gallery
{
    public partial class PressClips : ContentPage
    {
        #region Month Year Declarations
        DateTime StartDate = DateTime.Now;
        Dictionary<string, int> Months = new Dictionary<string, int>
        {
            {"January",1},{"February",2},{"March",3},{"April",4},{"May",5},{"June",6},{"July",7}
            ,{"August",8},{"September",9},{"October",10},{"November",11},{"December",12}
        };
        Dictionary<string, int> Years = new Dictionary<string, int>();
        #endregion

        #region declaration
        public int CallServiceFlag=1;
        public string SearchFilterText = "";
        public int SearchMonth ;
        public string SearchYear = "";
        int widthdevice;
        int deviceheight;
        int index = 0;
        int totalItems = 0;
        int totalListItems = 0;
        decimal MaxIndex = 0;
        ObservableCollection<PressClipobjClass> PressClipList;
        #endregion
        public PressClips()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            widthdevice = App.DeviceWidth;
            deviceheight = App.DeviceHeight;
            FilterPressClip.FontSize = App.GetFontSizeMedium();
            lblNoRecord.FontSize = App.GetFontSizeMedium();
            this.Title = AppResources.LPressClip.ToUpper();
            pickers();
            lstPressClip.ItemAppearing += LstPressClip_ItemAppearing;
            lstPressClip.ItemTapped += LstPressClip_ItemTapped;
            lstPressClip.Refreshing += LstPressClip_Refreshing;
        }
        private void LstPressClip_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedMaharashtraListItem = sender as Xamarin.Forms.ListView;
            selectedMaharashtraListItem.SelectedItem = null;
        }
        private async void LstPressClip_Refreshing(object sender, EventArgs e)
        {
            index = 0;
            loadingIndicator.IsVisible = false;
            loading.IsVisible = false;
            loading.IsRunning = false;
            SearchFilterText = FilterPressClip.Text;
            if (MonthPicker.SelectedIndex != -1)
                SearchMonth = Months.FirstOrDefault(x => x.Key == MonthPicker.Items[MonthPicker.SelectedIndex]).Value;
            else
                SearchMonth = 0;

            if (YearPicker.SelectedIndex != -1)
                SearchYear = Years.FirstOrDefault(x => x.Key == YearPicker.Items[YearPicker.SelectedIndex]).Key;
            else
                SearchYear = "";
            if (lblNoRecord.IsVisible == true)
            {
                SearchFilterText = "";
                SearchMonth = 0;
                SearchYear = "";
                FilterPressClip.Text = "";
                MonthPicker.SelectedIndex = -1;
                YearPicker.SelectedIndex = -1;
            }
            lblNoRecord.IsVisible = false;
            await CallWebServiceForPressClip(index);
        }
        private async void LstPressClip_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            try
            {
                if (totalItems != 0)
                {
                    MaxIndex = Math.Ceiling(((decimal)totalListItems) / 5);

                    if (index < MaxIndex)
                    {
                        if (PressClipList != null && e.Item != null && e.Item == PressClipList[PressClipList.Count - 1])
                        {
                            index++;
                            if (index != MaxIndex)
                            {
                                lstPressClip.IsRefreshing = false;
                                loadingIndicator.IsVisible = true;
                                loading.IsVisible = true;
                                loading.IsRunning = true;
                                await CallWebServiceForPressClip(index);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (App.CurrentPage() == "pressclip")
                {
                    if (ex.Message.Contains("Network"))
                        await DisplayAlert(AppResources.LError, AppResources.LWebserverNotResponding, AppResources.LOk);
                }
            }
        }
        public async void TapSearchImage(object sender, EventArgs args)
        {
                int _monthpicker = 0; string _yearpicker = "";

                if (MonthPicker.SelectedIndex == -1) _monthpicker = 0;
                else _monthpicker = Months.FirstOrDefault(x => x.Key == MonthPicker.Items[MonthPicker.SelectedIndex]).Value;
                if (YearPicker.SelectedIndex == -1) _yearpicker = "";
                else _yearpicker = Years.FirstOrDefault(x => x.Key == YearPicker.Items[YearPicker.SelectedIndex]).Key;

                if ((SearchFilterText != FilterPressClip.Text) || (SearchYear != _yearpicker) || (SearchMonth != _monthpicker))
                {
                    lblNoRecord.IsVisible = false;
                    if (loading.IsRunning == false)
                    {
                        if (!App.CheckInternetConnection())
                        {
                            await DisplayAlert(AppResources.LNetworkError, AppResources.LNoInternetConnection, AppResources.LOk);
                        }
                        else
                        {
                            if (FilterPressClip.Text == "" || FilterPressClip.Text == null)
                            { SearchFilterText = ""; }
                            else
                                SearchFilterText = FilterPressClip.Text;
                            index = 0;
                            loadingIndicator.IsVisible = true;
                            loading.IsRunning = true;
                            loading.IsVisible = true;
                            // GalleryList.IsVisible = false; u
                            PressClipList.Clear();
                            if (MonthPicker.SelectedIndex != -1)
                                SearchMonth = Months.FirstOrDefault(x => x.Key == MonthPicker.Items[MonthPicker.SelectedIndex]).Value;
                            else
                                SearchMonth = 0;

                            if (YearPicker.SelectedIndex != -1)
                                SearchYear = Years.FirstOrDefault(x => x.Key == YearPicker.Items[YearPicker.SelectedIndex]).Key;
                            else
                                SearchYear = "";

                            await CallWebServiceForPressClip(index);
                        }
                    }
                }
        }
        #region Month year events
             private void pickers()
        {
            for (int i = 2014; i <= StartDate.Year; i++)
                Years.Add(i.ToString(), i);
            foreach (string MonthName in Months.Keys)
                MonthPicker.Items.Add(MonthName);
            foreach (string YearName in Years.Keys)
                YearPicker.Items.Add(YearName);
        }
        #endregion
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            if (App.CheckInternetConnection())
            {
              if(CallServiceFlag == 1)
                    index = 0;
                await CallWebServiceForPressClip(index);
            }
            else
            {
                await DisplayAlert(AppResources.LNetworkError, AppResources.LNoInternetConnection, AppResources.LOk);
            }
            Application.Current.Properties["CurrentPage"] = "pressclip";
        }
        protected override void OnDisappearing()
        {
          
        }
        private async void LeftStackTaped(object sender, EventArgs e)
        {
                var StackID = sender as Grid;
                if (StackID.ClassId != null)
                {
                     CallServiceFlag = 0;
                     await Navigation.PushAsync(new CMO.Gallery.PressClipImagePage(StackID.ClassId));
                }
        }
        private async void RightStackTaped(object sender, EventArgs e)
        {
                var StackID = sender as Grid;
                if (StackID.ClassId != null)
                {
                    CallServiceFlag = 0;
                    await Navigation.PushAsync(new CMO.Gallery.PressClipImagePage(StackID.ClassId));
                }
        }
        //public async Task CallWebServiceForPressClip(int index)
        //{
        //    FilterPressClip.IsEnabled = false;
        //    if (!App.CheckInternetConnection())
        //    {
        //        await DisplayAlert(AppResources.LNetworkError, AppResources.LNoInternetConnection, AppResources.LOk);
        //    }
        //    else
        //    {
        //        try
        //        {
        //            #region Service Parameters
        //            string lang = "";
        //            if (Application.Current.Properties.ContainsKey("Language"))
        //            { lang = Application.Current.Properties["Language"] as string; }

        //            List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
        //            values.Add(new KeyValuePair<string, string>("lang", lang));
        //            values.Add(new KeyValuePair<string, string>("title", SearchFilterText));
        //            if (SearchMonth < 10)
        //                values.Add(new KeyValuePair<string, string>("month", "0" + SearchMonth.ToString()));
        //            else
        //                values.Add(new KeyValuePair<string, string>("month", SearchMonth.ToString()));
        //            values.Add(new KeyValuePair<string, string>("year", SearchYear));
        //            values.Add(new KeyValuePair<string, string>("index", Convert.ToString(index)));
        //            values.Add(new KeyValuePair<string, string>("limit", "8"));
        //            #endregion

        //            var response = await GeneralClass.GetResponse<CMO.ServicesClasses.RootObjectPressClip>(CMO.ServiceLayer.ServiceLinks.PressCLip_ListURL, values);
        //            if (response != null)
        //            {
        //                if (response._resultflag == 1)
        //                {
        //                    totalItems = response.total_results;
        //                    totalListItems = response.search_results;
        //                    if (PressClipList == null || index == 0)
        //                    {
        //                        PressClipList = new ObservableCollection<PressClip>();
        //                    }
        //                    for (int i = 0; i < response.pressClip.Count; i++)
        //                    {
        //                        var ObjectCmVisitList = new PressClip();
        //                        //   ObjectCmVisitList.SetFontSize = App.GetFontSizeMedium();
        //                        DateTime dt = DateTime.ParseExact(response.pressClip[i].press_date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //                        response.pressClip[i].press_date = dt.ToString("MMM. dd, yyyy");
        //                        ObjectCmVisitList.press_date = response.pressClip[i].press_date;
        //                        ObjectCmVisitList.original_path = response.pressClip[i].original_path;
        //                        ObjectCmVisitList.ipad_thumb_path = response.pressClip[i].ipad_thumb_path;
        //                        ObjectCmVisitList.thumb_path = response.pressClip[i].thumb_path;
        //                        ObjectCmVisitList.press_name = response.pressClip[i].press_name;
        //                        ObjectCmVisitList.title = response.pressClip[i].title.ToUpper();
        //                        #region (Text) Specific Design implemention for phone and tablet
        //                        if (Device.Idiom == TargetIdiom.Phone)
        //                        {
        //                           // ObjectCmVisitList.TitleWidth = new GridLength(3, GridUnitType.Star);
        //                         //   ObjectCmVisitList.ImageWidth = new GridLength(2, GridUnitType.Star);
        //                            //	ObjectCmVisitList.TitleFontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
        //                        }
        //                        else if (Device.Idiom == TargetIdiom.Tablet)
        //                        {
        //                       //     ObjectCmVisitList.TitleWidth = new GridLength(4, GridUnitType.Star);
        //                       //     ObjectCmVisitList.ImageWidth = new GridLength(2, GridUnitType.Star);
        //                            //     ObjectCmVisitList.TitleFontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
        //                        }
        //                        else
        //                        {
        //                      //      ObjectCmVisitList.TitleWidth = new GridLength(4, GridUnitType.Star);
        //                      //      ObjectCmVisitList.ImageWidth = new GridLength(2, GridUnitType.Star);
        //                            //  ObjectCmVisitList.TitleFontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
        //                        }
        //                        #endregion
        //                        PressClipList.Add(ObjectCmVisitList);
        //                    }
        //                    #region (Row Height) Specific Design implemention for phone and tablet
        //                    if (Device.Idiom == TargetIdiom.Phone)
        //                    {
        //                        lstPressClip.RowHeight = 250;
        //                    }
        //                    else if (Device.Idiom == TargetIdiom.Tablet)
        //                    {
        //                        lstPressClip.RowHeight = 500;
        //                    }
        //                    else
        //                    {
        //                        lstPressClip.RowHeight = 400;
        //                    }
        //                    #endregion
        //                    lstPressClip.ItemsSource = PressClipList;
        //                }
        //                else
        //                {
        //                    if (index == 0)
        //                    {
        //                        lblNoRecord.IsVisible = true;
        //                        PressClipList.Clear();
        //                    }
        //                }
        //            }
        //        }
        //        catch (WebException exception)
        //        {
        //            if (App.CurrentPage() == "pressclip")
        //                await DisplayAlert(AppResources.LError, AppResources.LWebserverNotResponding, AppResources.LOk);
        //        }
        //    }
        //    loading.IsVisible = false;
        //    loading.IsRunning = false;
        //    loadingIndicator.IsVisible = false;
        //    lstPressClip.IsRefreshing = false;
        //    FilterPressClip.IsEnabled = true;
        //}

        public async Task CallWebServiceForPressClip(int index)
        {
            FilterPressClip.IsEnabled = false;
            if (!App.CheckInternetConnection())
            {
                await DisplayAlert(AppResources.LNetworkError, AppResources.LNoInternetConnection, AppResources.LOk);
            }
            else
            {
                try
                {
                    #region Service Parameters
                    string lang = "";
                    if (Application.Current.Properties.ContainsKey("Language"))
                    { lang = Application.Current.Properties["Language"] as string; }

                    List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
                    values.Add(new KeyValuePair<string, string>("lang", lang));
                    values.Add(new KeyValuePair<string, string>("title", SearchFilterText));
                    if (SearchMonth < 10)
                        values.Add(new KeyValuePair<string, string>("month", "0" + SearchMonth.ToString()));
                    else
                    values.Add(new KeyValuePair<string, string>("month", SearchMonth.ToString()));
                    values.Add(new KeyValuePair<string, string>("year", SearchYear));
                    values.Add(new KeyValuePair<string, string>("index", Convert.ToString(index)));
                    values.Add(new KeyValuePair<string, string>("limit", "6"));
                    #endregion

                    var response = await GeneralClass.GetResponse<CMO.ServicesClasses.RootObjectPressClip>(CMO.ServiceLayer.ServiceLinks.PressCLip_ListURL, values);

                    if (response != null)
                    {
                        if (response._resultflag == 1)
                        {
                            totalItems = response.total_results;
                            totalListItems = response.search_results;
                            if (PressClipList == null || index == 0)
                            {
                                PressClipList = new ObservableCollection<PressClipobjClass>();
                            }

                            for (int i = 0; i < response.pressClip.Count; i++)
                            {
                                DateTime dt = DateTime.ParseExact(response.pressClip[i].press_date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                response.pressClip[i].press_date = dt.ToString("MMM. dd, yyyy");
                            }

                            for (int i = 0; i < response.pressClip.Count; i++)
                            {
                                var Pressitem = new PressClipobjClass();
                                Pressitem.FontSizeTitle = App.GetFontSizeMedium();
                                Pressitem.FontSizeDate_PressName = App.GetFontSizeSmall();

                                Pressitem.leftId = response.pressClip[i].id;
                                Pressitem.leftImage = response.pressClip[i].thumb_path;
                                Pressitem.leftDate = response.pressClip[i].press_date;
                                Pressitem.leftOrignal_image = response.pressClip[i].original_path;
                                Pressitem.leftTitle = response.pressClip[i].title;
                                Pressitem.leftPress_name = response.pressClip[i].press_name;
                                i++;

                                if (i < response.pressClip.Count)
                                {
                                    Pressitem.rightId = response.pressClip[i].id;
                                    Pressitem.rightImage = response.pressClip[i].thumb_path;
                                    Pressitem.rightDate = response.pressClip[i].press_date;
                                    Pressitem.rightOrignal_image = response.pressClip[i].original_path;
                                    Pressitem.rightTitle = response.pressClip[i].title;
                                    Pressitem.rightPress_name = response.pressClip[i].press_name;
                                    Pressitem.RighItemVisible = true;
                                }
                                else
                                {
                                    Pressitem.rightId = null;
                                    Pressitem.rightImage = null;
                                    Pressitem.rightDate = null;
                                    Pressitem.rightOrignal_image = null;
                                    Pressitem.rightTitle = null;
                                    Pressitem.rightPress_name = null;
                                    Pressitem.RighItemVisible = false;
                                    PressClipList.Add(Pressitem);
                                    break;
                                }
                                PressClipList.Add(Pressitem);
                            }
                            lstPressClip.ItemsSource = PressClipList;
                            lstPressClip.IsRefreshing = false;

                            if (Device.Idiom == TargetIdiom.Tablet)
                                lstPressClip.RowHeight = 400;
                            if (Device.Idiom == TargetIdiom.Phone)
                            {
                                if (Device.OS == TargetPlatform.iOS)
                                    lstPressClip.RowHeight = 200;
                                else
                                    lstPressClip.RowHeight = 250;
                            }
                        }
                        else
                        {
                            if (index == 0)
                            {
                                lblNoRecord.IsVisible = true;
                                PressClipList.Clear();
                                
                            }
                        }
                    }
                    else
                    {
                        if (App.CurrentPage() == "pressclip")
                            await DisplayAlert(AppResources.LError, AppResources.LSomethingWentWrong, AppResources.LOk);
                    }
                }
                catch (WebException exception)
                {
                    if (App.CurrentPage() == "pressclip")
                    {
                        if (exception.Message.Contains("Network"))
                            await DisplayAlert(AppResources.LError, AppResources.LWebserverNotResponding, AppResources.LOk);
                    }
                }
            }
            loading.IsVisible = false;
            loading.IsRunning = false;
            loadingIndicator.IsVisible = false;
            lstPressClip.IsRefreshing = false;
            FilterPressClip.IsEnabled = true;
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
            Application.Current.MainPage = new SideMenu();
            return true;
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
    public class PressClipobjClass
    {
        public string leftId { get; set; }
        public string leftImage { get; set; }
        public string leftTitle { get; set; }
        public string leftDate { get; set; }
        public string leftPress_name { get; set; }
        public string leftOrignal_image { get; set; }

        public string rightId { get; set; }
        public string rightImage { get; set; }
        public string rightTitle { get; set; }
        public string rightDate { get; set; }
        public string rightPress_name { get; set; }
        public string rightOrignal_image { get; set; }

        public bool RighItemVisible { get; set; }
        public int FontSizeDate_PressName { get; set; }
        public int FontSizeTitle { get; set; }
    }
}
