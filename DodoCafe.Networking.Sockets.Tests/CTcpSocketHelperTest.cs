using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DodoCafe.Networking.Sockets.Tests
{
    [ TestClass() ]
    public class CTcpSocketHelperTest
    {
        [ TestMethod() ]
        public void test_is_tcp_port_number()
        {
            Assert.IsFalse( CTcpSocketHelper.IsTcpPortNumber( -1 ) );
            Assert.IsFalse( CTcpSocketHelper.IsTcpPortNumber( 65536 ) );
            Assert.IsTrue( CTcpSocketHelper.IsTcpPortNumber( 0 ) );
            Assert.IsTrue( CTcpSocketHelper.IsTcpPortNumber( 65535 ) );
        }
    }
}