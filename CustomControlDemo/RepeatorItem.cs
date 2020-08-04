using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CustomControlDemo
{
    public class RepeaterItem : ContentControl
    {
        public RepeaterItem()
        {
            DefaultStyleKey = typeof(RepeaterItem);
        }

        public object Label
        {
            get => GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public DataTemplate LabelTemplate
        {
            get => (DataTemplate)GetValue(LabelTemplateProperty);
            set => SetValue(LabelTemplateProperty, value);
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(nameof(Label), typeof(object), typeof(RepeaterItem), new PropertyMetadata(default(object), OnLabelChanged));

        private static void OnLabelChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = args.OldValue;
            var newValue = args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as RepeaterItem;
            target?.OnLabelChanged(oldValue, newValue);
        }

        protected virtual void OnLabelChanged(object oldValue, object newValue)
        {
        }



      

        /// <summary>
        /// 标识 LabelTemplate 依赖属性。
        /// </summary>
        public static readonly DependencyProperty LabelTemplateProperty =
            DependencyProperty.Register(nameof(LabelTemplate), typeof(DataTemplate), typeof(RepeaterItem), new PropertyMetadata(default(DataTemplate), OnLabelTemplateChanged));

        private static void OnLabelTemplateChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (DataTemplate)args.OldValue;
            var newValue = (DataTemplate)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as RepeaterItem;
            target?.OnLabelTemplateChanged(oldValue, newValue);
        }

        protected virtual void OnLabelTemplateChanged(DataTemplate oldValue, DataTemplate newValue)
        {
        }
    }
}
