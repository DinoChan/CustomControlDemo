using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CustomControlDemo
{
    public class MyExpander : HeaderedContentControl
    {
        public MyExpander()
        {
            DefaultStyleKey = typeof(MyExpander);
        }

        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }

        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register(nameof(IsExpanded), typeof(bool), typeof(MyExpander), new PropertyMetadata(default(bool), OnIsExpandedChanged));

        private static void OnIsExpandedChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (bool)args.OldValue;
            var newValue = (bool)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as MyExpander;
            target?.OnIsExpandedChanged(oldValue, newValue);
        }

        protected virtual void OnIsExpandedChanged(bool oldValue, bool newValue)
        {
            if (newValue)
                OnExpanded();
            else
                OnCollapsed();
        }

        protected virtual void OnCollapsed()
        {
        }

        protected virtual void OnExpanded()
        {
        }
    }

}
