using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.Localization.ResorcesConfigure
{
    public class _Layout: I_Layout
    {
        private IStringLocalizer<_Layout> _localizer;
        public _Layout(IStringLocalizer<_Layout> localizer)
        {
            _localizer = localizer;
        }

        public string GetResource(string key)
        {
            return _localizer[key];
        }
    }
}
