using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.GuidHelper
{
    public class GuidHelperr
    {
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
