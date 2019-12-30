using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using RtlApp;
using RtlApp.iOS.Renders;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(AppShell), typeof(AppShellRenderer))]
namespace RtlApp.iOS.Renders
{
    public class AppShellRenderer : ShellRenderer
    {
        protected override IShellFlyoutRenderer CreateFlyoutRenderer()
        {
            var result = new ShellFlyoutRenderer()
            {

                FlyoutTransition = new SlideFlyoutTransitionRtl(),
            };


            return result;
        }
    }

    public class SlideFlyoutTransitionRtl : IShellFlyoutTransition
    {

        public void LayoutViews(CGRect bounds, nfloat openPercent, UIView flyout, UIView shell, FlyoutBehavior behavior)
        {
            if (behavior == FlyoutBehavior.Locked)
                openPercent = 1;

            nfloat flyoutWidth = (nfloat)(Math.Min(bounds.Width, bounds.Height) * 0.8);
            nfloat openLimit = flyoutWidth;
            nfloat openPixels = openLimit * openPercent;

            if (behavior == FlyoutBehavior.Locked)
                shell.Frame = new CGRect(bounds.X + flyoutWidth, bounds.Y, bounds.Width - flyoutWidth, bounds.Height);
            else
                shell.Frame = bounds;

            var shellWidth = shell.Frame.Width;

            var positionY = shellWidth - openPixels;

            flyout.Frame = new CGRect(positionY, 0, flyoutWidth, bounds.Height);


            if (behavior != FlyoutBehavior.Locked)
            {
                var shellOpacity = (nfloat)(0.5 + (0.5 * (1 - openPercent)));
                shell.Layer.Opacity = (float)shellOpacity;
            }


        }
    }
}