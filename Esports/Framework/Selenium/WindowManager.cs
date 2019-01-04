using System;
using System.Collections.ObjectModel;
using System.Drawing;

namespace Framework.Selenium
{
    public class WindowManager
    {
        public ReadOnlyCollection<string> CurrentWindows => Driver.Current.WindowHandles;

        public Size ScreenSize
        {
            get
            {
                var js = "var dimensions = [];" +
                    "dimensions.push(window.screen.availWidth);" +
                    "dimensions.push(window.screen.availHeight);" +
                    "return dimensions;";
                var dimensions = Driver.ExecuteScript<ReadOnlyCollection<object>>(js, null);
                var x = Convert.ToInt32(dimensions[0]);
                var y = Convert.ToInt32(dimensions[1]);

                return new Size(x, y);
            }
        }

        public void SwitchTo(int windowIndex)
        {
            Driver.Current.SwitchTo().Window(CurrentWindows[windowIndex]);
        }

        public void Maximize()
        {
            Driver.Current.Manage().Window.Position = new Point(0, 0);
            var size = ScreenSize;
            Driver.Current.Manage().Window.Size = size;
        }
    }
}
