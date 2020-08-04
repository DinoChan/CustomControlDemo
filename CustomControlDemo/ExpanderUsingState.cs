using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomControlDemo
{
    [TemplateVisualState(Name = StateExpanded, GroupName = GroupExpansion)]
    [TemplateVisualState(Name = StateCollapsed, GroupName = GroupExpansion)]
    public class ExpanderUsingState : MyExpander
    {
        public const string GroupExpansion = "ExpansionStates";

        public const string StateExpanded = "Expanded";

        public const string StateCollapsed = "Collapsed";

        public ExpanderUsingState()
        {
            DefaultStyleKey = typeof(ExpanderUsingState);
        }

        protected override void OnIsExpandedChanged(bool oldValue, bool newValue)
        {
            base.OnIsExpandedChanged(oldValue, newValue);
            UpdateVisualStates(true);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UpdateVisualStates(false);
        }

        protected virtual void UpdateVisualStates(bool useTransitions)
        {
            VisualStateManager.GoToState(this, IsExpanded ? StateExpanded : StateCollapsed, useTransitions);
        }

    }
}
