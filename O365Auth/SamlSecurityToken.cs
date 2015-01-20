using System;

namespace O365Auth
{
    internal class SamlSecurityToken
    {
        public byte[] Token
        {
            get;
            set;
        }

        public DateTime Expires
        {
            get;
            set;
        }
    }
}
