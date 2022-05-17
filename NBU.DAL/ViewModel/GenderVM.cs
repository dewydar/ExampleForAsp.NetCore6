using NBU.DAL.Common;
using NBU.DAL.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBU.DAL.ViewModel
{
    public class GenderVM :BaseEntityVM 
    {
        public string NameEn { get; set; } = String.Empty;
        public string NameAr { get; set; } = String.Empty;
        public string Name
        {
            get {
                if (AppSetting.CurrentLanguage == "ar")
                    {
                        return NameAr;
                    }
                    else
                    {
                        return NameEn;
                    }
                }
            //set { name = value; }
        }
    }
}
