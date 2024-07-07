using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8Mvc.NLayerArchitecture.Shared
{
    public static class DevCode
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return String.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }
    }
}
