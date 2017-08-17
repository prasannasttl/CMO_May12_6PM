using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMO.ServiceLayer
{
    public class ServiceLinks
    {
        public static string BaseUrl = "http://14.142.138.72/maharastracmo/api/";
       // public static string BaseUrl = "https://103.8.188.82/api/";
        //public static string BaseUrl = "https://cmo.maharashtra.gov.in/api/";
        public static string webviewPageContentURL = BaseUrl + "getpagecontent";
        public static string webviewBlockContentURL = BaseUrl + "getblockcontent";
        #region CM'S OFFICE
        //team cmo = webview
        //former cm = webview
        public static string ContactCMOURL = BaseUrl + "contactusform";
        #endregion

        #region MEET THE CHIEF MINISTER
        //biography = webview
        //vission mission = webview
        #endregion

        #region JOIN US
        //Sahabhag - Social Responsibility Cell = webview
        //Chief Minister's Fellowship Program = webview
        //Chief Minister's Relief Fund = webview
        //MyGov = webview
        #endregion

        #region CM'S ACTIVITY ROSTER
            public static string international_ListPageUrl = BaseUrl + "cmForeignVisit";
            public static string international_DetailUrl = BaseUrl + "cmforeignvisits";
            public static string domestic_ListUrl = BaseUrl + "cmmaharastravisits";
        #endregion

        #region INITIATIVES
        #endregion

        #region TEAM MAHARASHTRA
        // all webview
        #endregion

        #region MEDIA LIBRARY
        public static string NewUpdates_ListURL = BaseUrl + "getnewslist";
        public static string PressRelease_ListURL = BaseUrl + "getpressreleaselist";
        public static string PhotoGallery_ListURL = BaseUrl + "getphotogallerylist";
        public static string Photos_DetailURL = BaseUrl + "getphotogallerylistbyid";
        public static string VideoGallery_ListURL = BaseUrl + "getvideoslist";
        //publication
        public static string Events_ListURL = BaseUrl + "eventslisting";
        public static string PressCLip_ListURL = BaseUrl + "pressClipping";
        #endregion
    }
}
