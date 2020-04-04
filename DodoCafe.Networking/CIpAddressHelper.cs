using System;
using System.Linq;

namespace DodoCafe.Networking
{
    public static class CIpAddressHelper
    {
        public static bool IsIpv4( string strString )
        {
            return !strString.All( char.IsDigit ) && Uri.CheckHostName( strString ) == UriHostNameType.IPv4;
        }
    }
}
