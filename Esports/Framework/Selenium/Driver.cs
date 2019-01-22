using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace Framework.Selenium
{
    public static class Driver
    {
        [ThreadStatic] static IWebDriver _driver;
        [ThreadStatic] public static WebDriverWait Wait;
        [ThreadStatic] public static WindowManager Window;

        public static void Init(string type, string browser, int setWait)
        {
            _driver = DriverFactory.Build(type, browser);
            Wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(setWait));
            Window = new WindowManager();
            // Window.Maximize();
        }

        /// <summary>
        /// Gets the current instance of IWebDriver.
        /// </summary>
        public static IWebDriver Current =>
            _driver ?? throw new Exception("Driver is null. Call Driver.Init() first.");

        /// <summary>
        /// Gets the title of the current page.
        /// </summary>
        public static string Title => Current.Title;

        /// <summary>
        /// Gets the url of the current page.
        /// </summary>
        public static string Url => Current.Url;

        /// <summary>
        /// Navigates back one page in page history.
        /// </summary>
        public static void Back()
        {
            Current.Navigate().Back();
        }

        /// <summary>
        /// Drags an element from it's current position to the location of another element. 
        /// </summary>
        /// <param name="dragElement">Drag element.</param>
        /// <param name="dropOnElement">Drop element.</param>
        public static void DragAndDrop(Element dragElement, Element dropOnElement)
        {
            var actions = new Actions(Current);
            actions.DragAndDrop(dragElement.Current, dropOnElement.Current);
            actions.Build().Perform();
        }

        /// <summary>
        /// Navigates to the specified url.
        /// </summary>
        /// <param name="url">URL must start with https or http protocol.</param>
        public static void Goto(string url)
        {
            Current.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Finds the element based on the locator provided.
        /// </summary>
        /// <param name="by">FindBy mechanism.</param>
        /// <param name="elementName">Name of element for logging purposes.</param>
        public static Element FindElement(By by, string elementName = "")
        {
            //return Wait.ForElement(by, elementName);
            var element = Current.FindElement(by);
            return new Element(element, elementName);
        }

        /// <summary>
        /// Finds the elements based on the locator provided.
        /// </summary>
        /// <param name="by">FindBy mechanism.</param>
        public static Elements FindElements(By by)
        {
            //return Wait.ForElements(by);
            var elements = Current.FindElements(by);
            return new Elements(elements);
        }

        /// <summary>
        /// Closes all tabs and windows of current instance and disposes unused resources.
        /// </summary>
        public static void Quit()
        {
            if (_driver != null)
            {
                Current.Quit();
                Current.Dispose();
            }
        }

        /// <summary>
        /// Refreshes the current page.
        /// </summary>
        public static void Refresh()
        {
            Current.Navigate().Refresh();
        }

        /// <summary>
        /// Selects the dropdown option. This only works for 'select' elements.
        /// </summary>
        /// <param name="by">Select option by: INDEX | TEXT | VALUE.</param>
        /// <param name="element">The Select element.</param>
        /// <param name="value">Value to select the option.</param>
        public static void SelectDropdownOption(DropdownBy by, Element element, dynamic value)
        {
            var dropdown = new SelectElement(element.Current);

            switch (by)
            {
                case DropdownBy.INDEX:
                    dropdown.SelectByIndex((int)value);
                    break;
                case DropdownBy.TEXT:
                    dropdown.SelectByText((string)value);
                    break;
                case DropdownBy.VALUE:
                    dropdown.SelectByValue((string)value);
                    break;
            }
        }

        /// <summary>
        /// Takes a screenshot of the current page as a .png file.
        /// <para>Example: Driver.TakeScreenshot("~/pics/ss", "example")</para>
        /// <para>This saves the screenshot as ~/pics/ss/example.png</para>
        /// </summary>
        /// <param name="directory">Directory to save the file to.</param>
        /// <param name="imgName">Image name without .png extension.</param>
        public static void TakeScreenshot(string directory, string imgName)
        {
            var ss = ((ITakesScreenshot)Current).GetScreenshot();
            var ssFileName = Path.Combine(directory, imgName);
            ss.SaveAsFile($"{ssFileName}.png", ScreenshotImageFormat.Png);
        }

        /// <summary>
        /// Takes a screenshot of the current page as a .png file and
        /// saves it in the current test's auto-generated directory.
        /// </summary>
        /// <param name="imgName">Image name without .png extension.</param>
        public static void TakeScreenshot(string imgName)
        {
            var ss = ((ITakesScreenshot)Current).GetScreenshot();
            var ssFileName = Path.Combine("", imgName);
            ss.SaveAsFile($"{ssFileName}.png", ScreenshotImageFormat.Png);
        }

        /// <summary>
        /// Executes the javascript against the current page and returns an object.
        /// Access the args by indexing into the "arguments" array.
        /// <para>Example: var five = Driver.ExecuteScript&lt;int&gt;("return 3 + arguments[0]", 2);</para>
        /// </summary>
        /// <returns>An object of type T.</returns>
        /// <param name="js">Javascript to execute.</param>
        /// <param name="args">Arguments to be passed to script.</param>
        /// <typeparam name="T">The return type of the script.</typeparam>
        public static T ExecuteScript<T>(string js, params object[] args)
        {
            return Current.ExecuteJavaScript<T>(js, args);
        }

        /// <summary>
        /// Executes the javascript against the current page.
        /// Access the args by indexing into the "arguments" array.
        /// <para>Example: Driver.ExecuteScript("console.log(arguments[0])", "foo");</para>
        /// </summary>
        /// <param name="js">Javascript to execute.</param>
        /// <param name="args">Arguments to be passed to script.</param>
        public static void ExecuteScript(string js, params object[] args)
        {
            Current.ExecuteJavaScript(js, args);
        }
    }

    public enum DropdownBy
    {
        INDEX = 0,
        TEXT = 1,
        VALUE = 2
    }
}
