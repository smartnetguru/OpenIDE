using System;
using System.Windows.Forms;

namespace OpenIDE.Core.Contracts.Builders
{
    public class ControlBuilder<T>
        where T : Control, new()
    {
        internal T _control;

        public ControlBuilder()
        {
            _control = new T();
        }

        public ControlBuilder<T> Name(string name)
        {
            _control.Name = name;

            return this;
        }

        public ControlBuilder<T> Text(string text)
        {
            _control.Text = text;

            return this;
        }

        public ControlBuilder<T> Width(int width)
        {
            _control.Width = width;

            return this;
        }

        public ControlBuilder<T> Heigth(int height)
        {
            _control.Height = height;

            return this;
        }

        public ControlBuilder<T> Property(Action<T> callback)
        {
            callback(_control);

            return this;
        }

        public T Build()
        {
            return _control;
        }
    }
}