using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DodoCafe.Networking.Tests
{
    [ TestClass() ]
    public class CIpAddressHelperTest
    {
        [ TestMethod() ]
        public void test_is_ipv4()
        {
            // Is not IPv4.
            Assert.IsFalse( CIpAddressHelper.IsIpv4( "38e7:17b8:84f:2a8a:41db:e96a:a160:4355" ) ); // IPv6.
            Assert.IsFalse( CIpAddressHelper.IsIpv4( "" ) ); // Empty string.
            Assert.IsFalse( CIpAddressHelper.IsIpv4( "Bill Computer" ) ); // Host name.
            Assert.IsFalse( CIpAddressHelper.IsIpv4( "3" ) ); // Integer.
            Assert.IsFalse( CIpAddressHelper.IsIpv4( "256.255.255.255" ) ); // IP that is out of upper bound limit.
            Assert.IsFalse( CIpAddressHelper.IsIpv4( "-1.0.0.0" ) ); // IP that is out of lower bound limit.
            Assert.IsFalse( CIpAddressHelper.IsIpv4( "..." ) ); // IPv4 format.
            // Is IPv4.
            Assert.IsTrue( CIpAddressHelper.IsIpv4( "0.0.0.0" ) ); // Smallest IPv4.
            Assert.IsTrue( CIpAddressHelper.IsIpv4( "255.255.255.255" ) ); // Biggest IPv4.
            Assert.IsTrue( CIpAddressHelper.IsIpv4( "169.244.217.149" ) ); // Random IPv4.
        }
    }
}
