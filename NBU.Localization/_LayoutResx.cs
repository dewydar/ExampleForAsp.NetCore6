using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.Resources.cs
{
    public class _LayoutResx: I_LayoutResx
    {
        private IStringLocalizer<_LayoutResx> _localizer;
        public _LayoutResx(IStringLocalizer<_LayoutResx> localizer)
        {
            _localizer = localizer;
        }

        public string GetResource(string key)
        {
            return _localizer[key];
        }
    }
}
