using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;

using Foundation;
using TechApp2;
using TechApp2.iOS;
using UIKit;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace TechApp2.iOS
{

    public class CustomWebViewRenderer : ViewRenderer<CustomWebView, WKWebView>
    {
        //public CustomWebViewRenderer(Context context) : base(context)
        //{
        //}

        protected override void OnElementChanged(ElementChangedEventArgs<CustomWebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
               // Control.Settings.AllowUniversalAccessFromFileURLs = true;
                UpdateContent();
            }

            if (Control == null)
            {
                NSCoder coder = new NSCoder();
                //coder.
                //View
                SetNativeControl(new WKWebView(coder));
            }
            if (e.OldElement != null)
            {
                // Cleanup
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
           
            //u.url
            if (customWebView != null && customWebView.Path != null)
            {
                Control.LoadRequest(new NSUrlRequest(new NSUrl(customWebView.Path, false)));
                //Control.ScalesPageToFit = true;
                Console.WriteLine(customWebView.Path);
            }
        }
    }
}