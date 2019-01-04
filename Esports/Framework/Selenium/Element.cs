using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Framework.Selenium
{
    public class Element
    {
        public Element(IWebElement element)
        {
            Current = element;
        }

        public Element(IWebElement element, string name)
        {
            Current = element;
            Name = name;
        }

        /// <summary>
        /// Gets the current instance of <see cref="T:OpenQA.Selenium.IWebElement"/>.
        /// </summary>
        public IWebElement Current { get; }

        /// <summary>
        /// Gets or sets the <see cref="T:Framework.DriverCore.FindBy"/> mechanism used
        /// to find this <see cref="T:Framework.DriverCore.Element"/>.
        /// </summary>
        /// <value>The <see cref="T:OpenQA.Selenium.By"/> mechanism used to find this element.</value>
        public By FoundBy { get; set; }

        /// <summary>
        /// Gets or sets the name of this <see cref="T:Framework.DriverCore.Element"/>.
        /// This is used for logging.
        /// </summary>
        /// <value>The name of this element.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets the text within this element.
        /// This is equivalent to using .innerText on an element in javascript.
        /// </summary>
        /// <value>The text of this element.</value>
        public string Text => Current.Text;

        /// <summary>
        /// Gets the tag name of this element.
        /// </summary>
        /// <value>The tag name of this element.</value>
        public string TagName => Current.TagName;

        /// <summary>
        /// Gets the input value of this element.
        /// This is equivalent to using .value on an element in javascript.
        /// </summary>
        /// <value>The input value of this element.</value>
        public string InputValue => GetAttribute("value");

        /// <summary>
        /// Gets a value indicating whether this element is displayed.
        /// This means that it is present on the DOM, but not necessarily visible.
        /// </summary>
        /// <value><c>true</c> if displayed; otherwise, <c>false</c>.</value>
        public bool Displayed => Current.Displayed;

        /// <summary>
        /// Gets a value indicating whether this element is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled => Current.Enabled;

        /// <summary>
        /// Gets a value indicating whether this element is clickable.
        /// It must be visible and enabled, meaning that it has a size greater than zero pixels.
        /// </summary>
        /// <value><c>true</c> if clickable; otherwise, <c>false</c>.</value>
        public bool Clickable => Displayed
                    && Enabled
                    && Size.Height > 0
                    && Size.Width > 0;

        /// <summary>
        /// Gets the value of the specified attribute on this element.
        /// <para>Example: &lt;a id="foo"/&gt; -- element.GetAttribute("id");</para>
        /// </summary>
        /// <returns>The value of the attribute.</returns>
        /// <param name="attrName">Name of the attribute. This is case-sensitive.</param>
        public string GetAttribute(string attrName)
        {
            return Current.GetAttribute(attrName);
        }

        /// <summary>
        /// Simulates typing text into the element.
        /// This can also be used upload files by passing in the URL/path to the file(s).
        /// </summary>
        /// <param name="text">The text to enter into this element.</param>
        public void SendKeys(object text)
        {
            var str = text.ToString();
            Console.WriteLine(string.IsNullOrEmpty(Name)
                        ? $"Enter '{str}' into input field"
                        : $"Enter '{str}' into {Name}");

            try
            {
                if (string.IsNullOrEmpty(InputValue))
                {
                    Current.SendKeys(str);
                }
                else if (InputValue == str)
                {
                    // Do nothing since the expected string is already there
                }
                else
                {
                    Clear();
                    Current.SendKeys(str);
                }
            }
            catch (Exception e)
            {
                Driver.TakeScreenshot($"failed_to_sendkeys_{Name.Replace(' ', '_')}");
                throw e;
            }
        }

        /// <summary>
        /// Clicks this element.
        /// </summary>
        public void Click()
        {
            Console.WriteLine(string.IsNullOrEmpty(Name)
                        ? $"Click element"
                        : $"Click on {Name}");

            var tries = 0;

            while (tries < 3)
            {
                try
                {
                    Current.Click();
                    break;
                }
                catch (Exception e)
                {
                    tries++;

                    if (e.Message.Contains("Other element would receive the click"))
                    {
                        continue;
                    }
                    else
                    {
                        Driver.TakeScreenshot($"failed_to_click_{Name.Replace(' ', '_')}");
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// Simulates hovering the element with your mouse.
        /// </summary>
        public void Hover()
        {
            var actions = new Actions(Driver.Current);
            actions.MoveToElement(Current);
            actions.Build().Perform();
        }

        /// <summary>
        /// Clears the input value or content of this element.
        /// </summary>
        public void Clear()
        {
            Current.Clear();
        }

        /// <summary>
        /// Submits this element to the web server.
        /// </summary>
        public void Submit()
        {
            Current.Submit();
        }

        /// <summary>
        /// Gets the parent <see cref="T:Framework.DriverCore.Element"/> of this element.
        /// </summary>
        /// <value>The parent element.</value>
        public Element Parent
        {
            get
            {
                var js = "return arguments[0].parentElement";
                var parent = Driver.ExecuteScript<IWebElement>(js, Current);
                return new Element(parent);
            }
        }

        /// <summary>
        /// Gets an <see cref="T:Framework.DriverCore.Elements"/> object of the children of this element.
        /// </summary>
        /// <value>The child elements.</value>
        public Elements Children
        {
            get
            {
                var js = "var children = arguments[0].children; " +
                    "var array = []; " +
                    "for (var i = 0; i < children.length; i++) { array.push(children[i]); } " +
                    "return array;";
                var children = Driver.ExecuteScript<IReadOnlyCollection<IWebElement>>(js, Current);

                return new Elements(children.ToList());
            }
        }

        /// <summary>
        /// Gets an <see cref="T:Framework.DriverCore.Elements"/> object of the siblings of this element.
        /// </summary>
        /// <value>The sibling elements.</value>
        public Elements Siblings
        {
            get
            {
                var js = "var children = arguments[0].parentElement.children; " +
                    "var array = []; " +
                    "for (var i = 0; i < children.length; i++) { array.push(children[i]); } " +
                    "return array;";
                var siblings = Driver.ExecuteScript<IReadOnlyCollection<IWebElement>>(js, Current);

                return new Elements(siblings.ToList());
            }
        }

        /// <summary>
        /// Gets a value indicating whether this element is selected. Great for checkboxes or switches.
        /// </summary>
        /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
        public bool Selected => Current.Selected;

        /// <summary>
        /// Gets a <see cref="T:System.Drawing.Point"/> object containing the coordinates of the upper-left corner
        /// of this element relative to the upper-left corner of the page.
        /// </summary>
        /// <value>The coordinates of this element.</value>
        public Point Location => Current.Location;

        /// <summary>
        /// Gets the <see cref="T:System.Drawing.Size"/> object containing the height and width of this element.
        /// </summary>
        /// <value>The size of the element.</value>
        public Size Size => Current.Size;

        /// <summary>
        /// Gets the value of a javascript property of this element.
        /// </summary>
        /// <returns>The property value.</returns>
        /// <param name="propertyName">Property name to get the value from.</param>
        public string GetProperty(string propertyName)
        {
            return Current.GetProperty(propertyName);
        }

        /// <summary>
        /// Gets the value of a CSS property of this element.
        /// </summary>
        /// <returns>The CSS property's value.</returns>
        /// <param name="cssProperty">CSS property name.</param>
        public string GetCssValue(string cssProperty)
        {
            return Current.GetCssValue(cssProperty);
        }

        /// <summary>
        /// Finds the first <see cref="T:Framework.DriverCore.Element"/> using the 
        /// <see cref="T:Framework.DriverCore.FindBy"/> mechanism given.
        /// </summary>
        /// <returns>The first element found.</returns>
        /// <param name="by"><see cref="T:Framework.DriverCore.FindBy"/> mechanism.</param>
        public Element FindElement(By by)
        {
            return new Element(Current.FindElement(by))
            {
                FoundBy = by
            };
        }

        /// <summary>
        /// Finds the first <see cref="T:Framework.DriverCore.Element"/> using the 
        /// <see cref="T:Framework.DriverCore.FindBy"/> mechanism given.
        /// </summary>
        /// <returns>The first element found.</returns>
        /// <param name="by"><see cref="T:Framework.DriverCore.FindBy"/> mechanism.</param>
        /// <param name="name">Name to assign the element.</param>
        public Element FindElement(By by, string name)
        {
            return new Element(Current.FindElement(by))
            {
                FoundBy = by,
                Name = name
            };
        }

        /// <summary>
        /// Finds all <see cref="T:Framework.DriverCore.Element"/> using the 
        /// <see cref="T:Framework.DriverCore.FindBy"/> mechanism given.
        /// </summary>
        /// <returns>The elements found.</returns>
        /// <param name="by"><see cref="T:Framework.DriverCore.FindBy"/> mechanism.</param>
        public Elements FindElements(By by)
        {
            var elements = new Elements(Current.FindElements(by))
            {
                FoundBy = by
            };

            return elements;
        }
    }
}
