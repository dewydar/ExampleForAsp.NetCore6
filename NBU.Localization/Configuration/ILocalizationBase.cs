using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.Localization.Configuration
{
    public interface ILocalizationBase<T> where T : class
    {
        string GetResource(string key);
    }
}
