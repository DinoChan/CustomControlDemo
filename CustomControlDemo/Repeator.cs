using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace CustomControlDemo
{
    [StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(RepeaterItem))]
    public class Repeater : ItemsControl
    {
        public Repeater()
        {
            DefaultStyleKey = typeof(Repeater);
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is RepeaterItem;
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            var item = new RepeaterItem();
            return item;
        }


        public string LabelMemberPath
        {
            get => (string)GetValue(LabelMemberPathProperty);
            set => SetValue(LabelMemberPathProperty, value);
        }

        public static readonly DependencyProperty LabelMemberPathProperty =
            DependencyProperty.Register(nameof(LabelMemberPath), typeof(string), typeof(Repeater), new PropertyMetadata(default(string), OnLabelMemberPathChanged));

        private static void OnLabelMemberPathChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (string)args.OldValue;
            var newValue = (string)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as Repeater;
            target?.OnLabelMemberPathChanged(oldValue, newValue);
        }

        protected virtual void OnLabelMemberPathChanged(string oldValue, string newValue)
        {
            // refresh the label member template.
            _labelMemberTemplate = null;
            var newTemplate = LabelMemberPath;

            int count = Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (ItemContainerGenerator.ContainerFromIndex(i) is RepeaterItem RepeaterItem)
                    PrepareRepeaterItem(RepeaterItem, Items[i]);
            }
        }

        private DataTemplate _labelMemberTemplate;

        private DataTemplate LabelMemberTemplate
        {
            get
            {
                if (_labelMemberTemplate == null)
                {
                    _labelMemberTemplate = (DataTemplate)XamlReader.Parse(@"
                    <DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                                xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
                    		<TextBlock Text=""{Binding " + LabelMemberPath + @"}"" VerticalAlignment=""Center""/>
                    </DataTemplate>");
                }

                return _labelMemberTemplate;
            }
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);

            if (element is RepeaterItem RepeaterItem )
            {
                PrepareRepeaterItem(RepeaterItem,item);
            }
        }

        private void PrepareRepeaterItem(RepeaterItem RepeaterItem, object item)
        {
            if (RepeaterItem == item)
                return;

            RepeaterItem.LabelTemplate = LabelMemberTemplate;
            RepeaterItem.Label = item;
        }
    }
}
