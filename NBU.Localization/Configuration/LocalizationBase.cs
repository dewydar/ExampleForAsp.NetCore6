using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.Localization.Configuration
{
    public class LocalizationBase<T> : ILocalizationBase<T> where T : class, new()
    {
        private IStringLocalizer<T> _localizer;
        public LocalizationBase(IStringLocalizer<T> localizer)
        {
            _localizer = localizer;
        }

        public string GetResource(string key)
        {
            return _localizer[key];
        }
    }
    
}
