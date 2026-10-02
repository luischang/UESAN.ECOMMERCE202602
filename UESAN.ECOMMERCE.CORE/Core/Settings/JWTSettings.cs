using System;
using System.Collections.Generic;
using System.Text;

namespace UESAN.ECOMMERCE.CORE.Core.Settings
{
    public class JWTSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double ExpirationInMinutes { get; set; }
    }
}
