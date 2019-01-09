using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoktor.Common
{
    public class DefaultCommon : ICommon
    {//heryerden erişim için
        public string GetCurrentUsername()
        {
            return "system";
        }
    }
}
