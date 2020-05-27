using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using TechApp2;
using TechApp2.Droid;
using System.ComponentModel;
using Android.Content;
using System.IO;
using Android.Content.Res;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace TechApp2.Droid
{
    public class CustomWebViewRenderer : WebViewRenderer
    {
        public CustomWebViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
                UpdateContent();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CustomWebView.PathProperty.PropertyName)
            {
                UpdateContent();
            }
        }

        private void UpdateContent()
        {
            var customWebView = Element as CustomWebView;
            if (customWebView != null && customWebView.Path != null)
            {

                Control.LoadUrl(string.Format("file:///android_asset/viewer.html?file={0}", string.Format("file:///{0}", WebUtility.UrlEncode(customWebView.Path))));
            }
        }
    }
}