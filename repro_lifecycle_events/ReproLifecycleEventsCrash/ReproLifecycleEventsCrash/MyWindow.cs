using System;
using System.Diagnostics;

namespace ReproLifecycleEventsCrash
{

    public class MyWindow : Window
    {
        public MyWindow() : base()
        {
            Activated += MyWindow_Activated;
        }

        private void MyWindow_Activated(object sender, EventArgs e)
        {
            Debug.WriteLine("SWEEKY ACTIVATED");
        }

        public MyWindow(Page page) : base(page)
        {
        }
    }
}

