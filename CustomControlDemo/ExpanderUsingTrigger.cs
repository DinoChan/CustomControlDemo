using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControlDemo
{
   public class ExpanderUsingTrigger:MyExpander
    {
        public ExpanderUsingTrigger()
        {
            DefaultStyleKey = typeof(ExpanderUsingTrigger);
        }
    }
}
