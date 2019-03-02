// Copyright 2019, Danny Hacker, Apache License 2.0, Soli Deo Gloria

using System;
using CPTest.Shared;
using UIKit;

namespace CPTest.iOS
{
    public partial class ViewController : UIViewController
    {
        Calculate calc = new Calculate(1); //int count = 1;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            Button.AccessibilityIdentifier = "myButton";
            Button.TouchUpInside += delegate
            {
                var title = string.Format("{0} clicks!", calc.PostAdd(1)); //count++);
                Button.SetTitle(title, UIControlState.Normal);
            };

            SharedButton mySharedButton = new SharedButton();
            mySharedButton.Init(0, 100, 200, 20, "My Shared Button", ButtonHandler);

        }

        void ButtonHandler(float x, float y, float width, float height, string text)
        {

            var myButton = UIButton.FromType(UIButtonType.System);
            myButton.SetTitle(text, UIControlState.Normal);
            myButton.Frame = new CoreGraphics.CGRect(x, y, width, height);
            View.Add(myButton);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}
