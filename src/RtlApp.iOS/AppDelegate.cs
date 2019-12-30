using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace RtlApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        [System.Runtime.InteropServices.DllImport(ObjCRuntime.Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
        internal extern static IntPtr IntPtr_objc_msgSend(IntPtr receiver, IntPtr selector, UISemanticContentAttribute arg1);

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init();


            //force to app to run  RTL layout
            ObjCRuntime.Selector selector = new ObjCRuntime.Selector("setSemanticContentAttribute:");
            AppDelegate.IntPtr_objc_msgSend(UIView.Appearance.Handle, selector.Handle,UISemanticContentAttribute.ForceRightToLeft);

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
