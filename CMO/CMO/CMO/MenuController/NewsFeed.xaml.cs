using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CMO.MenuController
{
    public partial class NewsFeed : ContentPage
    {
        public NewsFeed()
        {
           InitializeComponent();
            #region twitter
           
            var anchortagtwitter = "<a class=\"twitter - timeline\" data-widget-id=\"586430104324026369\" href='https://twitter.com/CMOMaharashtra/favorites'>Favorite Tweets by @CMOMaharashtra</a>" +
                "<script>!function(d, s, id){ var js, fjs = d.getElementsByTagName(s)[0], p =/^ http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + \"://platform.twitter.com/widgets.js\"; fjs.parentNode.insertBefore(js, fjs); } } (document,\"script\",\"twitter-wjs\");</script>";
            var twitiframe = "<iframe id=\"rufous-sandbox\" scrolling = \"no\" frameborder = \"0\" allowtransparency = \"true\" allowfullscreen = \"true\" style = \"position: absolute; visibility: hidden; display: none; width: 0px; height: 0px; padding: 0px; border: none;\" title = \"Twitter analytics iframe\"></iframe>";
            var fbfeed = "<div class=\"flyOutOuter open\" id=\"fb\" style=\"height: 204px; \"><iframe allowtransparency = \"true\" scrolling = \"no\" src = '//www.facebook.com/plugins/likebox.php?href=https%3A%2F%2Fwww.facebook.com%2FCMOMaharashtra&amp;width=260&amp;height=470&amp;colorscheme=light&amp;show_faces=false&amp;header=false&amp;stream=true&amp;show_border=false' style = \"border:none; overflow:hidden; width:260px; height:494px;\" frameborder = \"0\" ></ iframe ></ div >";


            var twitterfeed = "<!doctype html>" +
               "<body>" + fbfeed +
                "</body>";

             var htmtwitter = "<!DOCTYPE html>"
                +"<html>"
                //+"<head>"
                //+"<meta charset=\"UTF-8\">"
                //+"</head>"
                +"<body>"
                +"<a class=\"twitter - timeline\" data-widget-id=\"586430104324026369\" href='https://twitter.com/CMOMaharashtra/favorites'>Favorite Tweets by @CMOMaharashtra</a>"
                +"<script>"
                +"!function(d, s, id){ var js, fjs = d.getElementsByTagName(s)[0], p =/^ http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + \"://platform.twitter.com/widgets.js\"; fjs.parentNode.insertBefore(js, fjs); } }(document,\"script\",\"twitter-wjs\");"
                +"</script>"
                +"</body>"
                +"</html>";




           
            var html = new HtmlWebViewSource
            {
                Html = twitterfeed
            };
            webTwitter.Source = html;

           
            // webTwitter.Source = "https://mobile.twitter.com/CMOMaharashtra/favorites";
            #endregion

            #region facebook
            var facebookfeed = "";
            facebookfeed =
                "<!doctype html> " +
                "<head>" +
                 "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no\">" +
                 
                "<iframe allowtransparency = \"true\" frameborder = \"0\" scrolling = \"no\" src = \"//www.facebook.com/plugins/likebox.php?href=https%3A%2F%2Fwww.facebook.com%2FCMOMaharashtra&amp;width=260&amp;height=470&amp;colorscheme=light&amp;show_faces=false&amp;header=false&amp;stream=true&amp;show_border=false\" style =\"border:none; overflow:hidden; width:260px; height:494px;\"></iframe>"+
            "</head>";
            var htmlfb = new HtmlWebViewSource
            {
                Html = facebookfeed
            };
            webFB.Source = "https://m.facebook.com/CMOMaharashtra";
            #endregion

            #region Youtube
            webYoutube.Source = "https://twitter.com/CMOMaharashtra/favorites";
            #endregion
            var t = new TapGestureRecognizer();
            t.Tapped += Stacktap_Tapped;
            stckTab1.GestureRecognizers.Add(t);
            stckTab2.GestureRecognizers.Add(t);
            stckTab3.GestureRecognizers.Add(t);
        }
        void Stacktap_Tapped(object sender, EventArgs e)
        {
            var obj = sender as StackLayout;
            var objClassId = obj.ClassId;

            if (objClassId.Equals("Tab1"))
            {
                stckTab1.BackgroundColor = Color.Transparent;
                ImgTwitter.Source = "ico_call.png";
                LblTwitter.TextColor = Color.FromHex("f15a23");

                stckTab2.BackgroundColor = Color.FromHex("f15a23");
                ImgFB.Source = "ico_call.png";
                LblFB.TextColor = Color.White;

                stckTab3.BackgroundColor = Color.FromHex("f15a23");
                ImgYoutube.Source = "ico_call.png";
                LblYoutube.TextColor = Color.White;

                webTwitter.IsVisible = true;
                webFB.IsVisible = false;
                webYoutube.IsVisible = false;
            }
            else if (objClassId.Equals("Tab2"))
            {
                stckTab2.BackgroundColor = Color.Transparent;
                ImgFB.Source = "ico_call.png";
                LblFB.TextColor = Color.FromHex("f15a23");

                stckTab1.BackgroundColor = Color.FromHex("f15a23");
                ImgTwitter.Source = "ico_call.png";
                LblTwitter.TextColor = Color.White;

                stckTab3.BackgroundColor = Color.FromHex("f15a23");
                ImgYoutube.Source = "ico_call.png";
                LblYoutube.TextColor = Color.White;

                webTwitter.IsVisible = false;
                webFB.IsVisible = true;
                webYoutube.IsVisible = false;
            }
            else
            {
                stckTab3.BackgroundColor = Color.Transparent;
                ImgYoutube.Source = "ico_call.png";
                LblYoutube.TextColor = Color.FromHex("f15a23");

                stckTab2.BackgroundColor = Color.FromHex("f15a23");
                ImgFB.Source = "ico_call.png";
                LblFB.TextColor = Color.White;

                stckTab1.BackgroundColor = Color.FromHex("f15a23");
                ImgTwitter.Source = "ico_call.png";
                LblTwitter.TextColor = Color.White;

                webTwitter.IsVisible = false;
                webFB.IsVisible = false;
                webYoutube.IsVisible = true;
            }

        }

    }
}
