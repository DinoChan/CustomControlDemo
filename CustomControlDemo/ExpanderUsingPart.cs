using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomControlDemo
{
    [TemplatePart(Name =ContentPresenterName,Type =typeof(UIElement))]
    public class ExpanderUsingPart : MyExpander
    {
        private const string ContentPresenterName = "ContentPresenter";

        protected UIElement ContentPresenter { get; private set; }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ContentPresenter = GetTemplateChild(ContentPresenterName) as UIElement;
            UpdateContentPresenter();
        }

        protected override void OnIsExpandedChanged(bool oldValue, bool newValue)
        {
            base.OnIsExpandedChanged(oldValue, newValue);
            UpdateContentPresenter();
        }

        private void UpdateContentPresenter()
        {
            if (ContentPresenter == null)
                return;

            ContentPresenter.Visibility = IsExpanded ? Visibility.Visible : Visibility.Collapsed;
        }



    }
}
