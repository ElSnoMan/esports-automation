using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace Framework.Selenium
{
    public class Elements : IList<Element>
    {
        readonly IList<IWebElement> _list;
        readonly List<Element> _elements;

        public Elements(IList<IWebElement> list)
        {
            _list = list;
            _elements = new List<Element>();

            foreach (var element in list)
            {
                _elements.Add(new Element(element));
            }
        }

        public Element this[int index]
        {
            get => _elements[index];
            set => _elements[index] = value;
        }

        public By FoundBy { get; set; }

        public bool IsEmpty => Count == 0;

        public int Count => _elements.Count;

        public bool IsReadOnly => _list.IsReadOnly;

        public void Add(Element element)
        {
            _elements.Add(element);
        }

        public void Clear()
        {
            _elements.Clear();
        }

        public bool Contains(Element element)
        {
            return _elements.Contains(element);
        }

        public void CopyTo(Element[] array, int arrayIndex)
        {
            _elements.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Element> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        public int IndexOf(Element element)
        {
            return _elements.IndexOf(element) + 1;
        }

        public void Insert(int index, Element element)
        {
            _elements.Insert(index, element);
        }

        public bool Remove(Element element)
        {
            return _elements.Remove(element);
        }

        public void RemoveAt(int index)
        {
            _elements.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
